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
        private List<ProjectExploler> Exprojects; // объект хранящий проекты для просмотра
        OleDbConnection connect;
        private OleDbCommand MyCommand;
        private String SqlString; // строка для запросов
        public OleDbConnection ShowProjects(ref string ErrorMessage) // показать все проекты
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
                Exprojects = new List<ProjectExploler>();
                while (myDataReader.Read())
                {
                    Exprojects.Add(new ProjectExploler(myDataReader["Номер_проекта"].ToString(), myDataReader["Проект.Наименование"].ToString()
                        , myDataReader["Модель"].ToString(), myDataReader["Схема.Наименование"].ToString(), myDataReader["Размещена"].ToString()
                        , myDataReader["Трассирована"].ToString()));// извлечение данных о проекте и инициализация элементов списка ProjectExploler
                    MessageBox.Show(myDataReader["Проект.Наименование"].ToString());
                }

            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return null; // проблемы с установкой соединения
            }
            connect.Close();
            return null;
        }
        public bool ImportFromDB()
        {
            return true;
        }
    }
}
