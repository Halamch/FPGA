using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows;

namespace SAPR_FPGA
{
    class Model_
    {
        String ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FPGADATABASE.accdb"; //Строка соединения
        private List<ProjectExploler> _exprojects; // объект хранящий проекты для просмотра
        OleDbConnection connect;
        private OleDbCommand MyCommand;
        private String SqlString; // строка для запросов
        FPGA fpga = new FPGA();
        Scheme scheme = new Scheme();

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
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }
            return String.Empty;

        }
    }
}
