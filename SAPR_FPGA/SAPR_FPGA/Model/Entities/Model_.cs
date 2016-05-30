using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using SAPR_FPGA.Model.Entities;

namespace SAPR_FPGA
{
    class Model_
    {
        String ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FPGADATABASE.accdb"; //Строка соединения
        private List<ProjectExploler> _exprojects; // объект хранящий проекты для просмотра
        OleDbConnection connect;
        private OleDbCommand MyCommand;
        private String SqlString; // строка для запросов
        FPGA fpga; // данные о модели ПЛИС
        Scheme scheme; // Номер схемы и наименование
        List<Route> routes;  // маршруты
        private List<Element> elements; //список элементов схемы

        public List<ProjectExploler> Exprojects
        {
            get { return _exprojects; }
        }

        public void ShowProjects(ref string ErrorMessage) // показать все проекты
        {
            try
            {
                connect = new OleDbConnection(ConnectionString);// Создание объекта соединения
                connect.Open();// Открытие соединения
                SqlString = "SELECT Проект.Номер_проекта,Проект.Наименование,ПЛИС.Модель,Схема.Наименование,Схема.Размещена,Схема.Трассирована " +
                            "FROM ((Проект INNER JOIN ПЛИС ON Проект.Номер_ПЛИС = ПЛИС.Номер_ПЛИС) " +
                            "INNER JOIN Схема ON Проект.Номер_Схемы = Схема.Номер_Схемы);"; // SQL-запрос показа всех проектов
                MyCommand = new OleDbCommand(SqlString, connect); // Формирование команды запроса
                OleDbDataReader myDataReader = MyCommand.ExecuteReader();//Выполнение SQL-команды
                _exprojects = new List<ProjectExploler>();
                while (myDataReader.Read())
                {
                    _exprojects.Add(new ProjectExploler(myDataReader["Номер_проекта"].ToString(), myDataReader["Проект.Наименование"].ToString()
                        , myDataReader["Модель"].ToString(), myDataReader["Схема.Наименование"].ToString(), myDataReader["Размещена"].ToString()
                        , myDataReader["Трассирована"].ToString()));// извлечение данных о проекте и инициализация элементов списка ProjectExploler
                    //MessageBox.Show(myDataReader["Проект.Наименование"].ToString());
                }

            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            connect.Close();
        }
        public string ImportFromDB(int index)
        {
            string ErrorMessage = "";
            try
            {
                connect = new OleDbConnection(ConnectionString);// Создание объекта соединения
                connect.Open();// Открытие соединения
                routes = new List<Route>();
                fpga = new FPGA();
                scheme = new Scheme();

                // Заполнение данных о ПЛИС и о схеме
                SqlString = "SELECT ПЛИС.Модель,ПЛИС.Количество_КЛБ,ПЛИС.Ширина_канала,Схема.Номер_схемы," +
                            "Схема.Наименование FROM ((Проект INNER JOIN ПЛИС ON Проект.Номер_ПЛИС = ПЛИС.Номер_ПЛИС) " +
                            "INNER JOIN Схема ON Проект.Номер_схемы = Схема.Номер_схемы) WHERE Проект.Номер_проекта = @index;"; // SQL-запрос показа всех проектов
                MyCommand = new OleDbCommand(SqlString, connect); // Формирование команды запроса
                OleDbParameter Parameter1 = new OleDbParameter();
                Parameter1.OleDbType = OleDbType.VarChar;
                Parameter1.ParameterName = "@index"; // задание параметра для запроса
                Parameter1.Value = index;
                MyCommand.Parameters.Add(Parameter1);
                OleDbDataReader myDataReader = MyCommand.ExecuteReader();//Выполнение SQL-команды   
                while (myDataReader.Read())
                {
                    fpga.Model = myDataReader["Модель"].ToString();
                    fpga.CountCPD = Convert.ToInt32(myDataReader["Количество_КЛБ"].ToString());
                    fpga.ChannelWidth = Convert.ToInt32(myDataReader["Ширина_канала"].ToString());
                    scheme.NumScheme = Convert.ToInt32(myDataReader["Номер_схемы"].ToString());
                    scheme.name = myDataReader["Наименование"].ToString();
                }

                //Заполнение данных об элементах
                SqlString = "SELECT Элемент.Логическое_значение,Элемент.Индекс_КЛБ_поГоризонтали," +
                            "Элемент.Индекс_КЛБ_поВертикали FROM Элемент WHERE Элемент.Номер_схемы = @SchemeNum;"; // SQL-запрос показа всех проектов
                MyCommand = new OleDbCommand(SqlString, connect); // Формирование команды запроса
                Parameter1 = new OleDbParameter();
                Parameter1.OleDbType = OleDbType.VarChar;
                Parameter1.ParameterName = "@SchemeNum"; // задание параметра для запроса
                Parameter1.Value = scheme.NumScheme;
                MyCommand.Parameters.Add(Parameter1);
                myDataReader = MyCommand.ExecuteReader();//Выполнение SQL-команды   
                elements = new List<Element>();
                while (myDataReader.Read())
                {
                    elements.Add(new Element(myDataReader["Логическое_значение"].ToString(),myDataReader["Индекс_КЛБ_поГоризонтали"].ToString(),
                        myDataReader["Индекс_КЛБ_поВертикали"].ToString()));
                }

                //Заполнение данных о маршрутах
                SqlString = "SELECT Маршрут.Элемент_источник,Маршрут.Элемент_приемник,Маршрут.Длина_маршрута " +
                            "FROM Маршрут WHERE Маршрут.Номер_схемы = @SchemeNum;"; // SQL-запрос показа всех проектов
                MyCommand = new OleDbCommand(SqlString, connect); // Формирование команды запроса
                Parameter1 = new OleDbParameter();
                Parameter1.OleDbType = OleDbType.VarChar;
                Parameter1.ParameterName = "@SchemeNum"; // задание параметра для запроса
                Parameter1.Value = scheme.NumScheme;
                MyCommand.Parameters.Add(Parameter1);
                myDataReader = MyCommand.ExecuteReader();//Выполнение SQL-команды  
                routes = new List<Route>();
                int i, j, length;
                while (myDataReader.Read())
                {
                    i = Convert.ToInt32(myDataReader["Элемент_источник"].ToString()) - 1;
                    j = Convert.ToInt32(myDataReader["Элемент_приемник"].ToString()) - 1;
                    length = myDataReader["Длина_маршрута"].ToString().Trim() == String.Empty ? 0 : Convert.ToInt32(myDataReader["Длина_маршрута"].ToString());
                    routes.Add(new Route(elements[i], elements[j], length));
                }


                //Заполнение данных о путях
                SqlString = "SELECT Путь.Номер_маршрута,Путь.Элемент_начало,Путь.Элемент_конец,Путь.Длина_пути FROM Путь WHERE Путь.Номер_маршрута between @min AND @max;"; // SQL-запрос показа всех проектов
                MyCommand = new OleDbCommand(SqlString, connect); // Формирование команды запроса
                Parameter1 = new OleDbParameter();
                Parameter1.OleDbType = OleDbType.VarChar;
                Parameter1.ParameterName = "@min"; // задание параметра для запроса
                Parameter1.Value = 1;
                MyCommand.Parameters.Add(Parameter1);
                OleDbParameter Parameter2 = new OleDbParameter();
                Parameter2.OleDbType = OleDbType.VarChar;
                Parameter2.ParameterName = "@max"; // задание параметра для запроса
                Parameter2.Value = routes.Count;
                MyCommand.Parameters.Add(Parameter2);
                myDataReader = MyCommand.ExecuteReader();//Выполнение SQL-команды 
                int k,Pathlength;
                while (myDataReader.Read())
                {
                    i = Convert.ToInt32(myDataReader["Номер_маршрута"].ToString()) - 1;
                    j = Convert.ToInt32(myDataReader["Элемент_начало"].ToString()) - 1;
                    k = Convert.ToInt32(myDataReader["Элемент_конец"].ToString()) - 1;
                    Pathlength = myDataReader["Длина_пути"].ToString().Trim() == String.Empty ? 0 : Convert.ToInt32(myDataReader["Длина_пути"].ToString());
                    routes[i].paths.Add(new Path(elements[j],elements[k],Pathlength));
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            return String.Empty;

        }
    }
}
