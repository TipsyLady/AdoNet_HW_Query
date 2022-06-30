using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Console;

namespace AdoNet_CW_Introduction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 1;
            WriteLine("Выберете номер запроса(1-3): ");
            number = Convert.ToInt32(Console.ReadLine());
            string connectionstring = "Data Source=LAPTOP-87PAAV0P\\SQLEXPRESS; Database=CompanyDB; Trusted_Connection=True";
            //1.
            //SqlConnection sql = new SqlConnection();
            //sql.ConnectionString = connectionstring;

            //2.
            //SqlConnection sql = new SqlConnection(connectionstring);

            //3.
            SqlConnection sql = new SqlConnection("Data Source=LAPTOP-87PAAV0P\\SQLEXPRESS; Database=CompanyDB; Trusted_Connection=True");
            //Подключение базы
            sql.Open();
            //string sqlcommand = "SELECT * from[CompanyDB].[dbo].[Customers]";
            //Создание команды
            //SqlCommand sqlCommand = new SqlCommand(sqlcommand, sql);
            //ExecuteNonQuery()- выполняет запрос без возвращение данных
            //удалить, обновить, вставить и тд.
            //ExecuteReader()- вернуть набор данных 
            //в виде нескольких строчек (все записи в таблице)
            //ExecuteScalar() - возвращает 1 результат (сумма, мин, минус и тд)

            //SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            //while (sqlDataReader.Read())
            //{
            //    var f1 = sqlDataReader[0];
            //    var f2 = sqlDataReader[1];
            //    var f3 = sqlDataReader[2];
            //    WriteLine($"{f1} {f2} {f3}");
            //}
            switch(number)
            {
                case 1:
                    WriteLine("Сортировка по фамилиям");
                     string command1 = "Select * from [CompanyDB].[dbo].[Employee] order by LastName";
                    SqlCommand sql1 = new SqlCommand(command1, sql);

                    SqlDataReader sqlDataReader = sql1.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        var f1 = sqlDataReader[0];
                        var f2 = sqlDataReader[1];
                        var f3 = sqlDataReader[2];
                        var f4 = sqlDataReader[3];
                        WriteLine($"{f1} - {f2} - {f3} - {f4}");
                    }
                    break;
                case 2:
                    WriteLine("Cортировка от меньшего к большему по дате рождения");
                    string command2 = "SELECT * FROM [CompanyDB].[dbo].[Employee] ORDER BY BirthDate DESC";
                    SqlCommand sql2 = new SqlCommand(command2, sql);

                    SqlDataReader sqlDataReader2 = sql2.ExecuteReader();

                    while (sqlDataReader2.Read())
                    {
                        var f1 = sqlDataReader2[0];
                        var f2 = sqlDataReader2[1];
                        var f3 = sqlDataReader2[2];
                        var f4 = sqlDataReader2[3];
                        WriteLine($"{f1} - {f2} - {f3} - {f4}");
                    }
                    break;
                case 3:
                    WriteLine("Cортировка по дате рождения сотрудники старше 2000 гр");
                    string command3 = "SELECT * FROM [CompanyDB].[dbo].[Employee] WHERE Year(BirthDate) < '2000'";
                    SqlCommand sql3 = new SqlCommand(command3, sql);

                    SqlDataReader sqlDataReader3 = sql3.ExecuteReader();

                    while (sqlDataReader3.Read())
                    {
                        var f1 = sqlDataReader3[0];
                        var f2 = sqlDataReader3[1];
                        var f3 = sqlDataReader3[2];
                        var f4 = sqlDataReader3[3];
                        WriteLine($"{f1} - {f2} - {f3} - {f4}");
                    }
                    break;
                default:
                    WriteLine("Такого номера запроса нет.");
                    break;
            }

            

        }
    }
}
