using MCC71.Models;
using MCC71.Repositories.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MCC71
{
    class Program
    {
        SqlConnection sqlConnection;
        string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MCC71;User ID=mcc71;Password=1234567890;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        static void Main(string[] args)
        {
            //DivisionRepository divisionRepository = new DivisionRepository();
            //var data = divisionRepository.Get();
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item.Id);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine();
            //}

            //Queue<int> listOfQueue = new Queue<int>();
            //listOfQueue.Enqueue(1);
            //listOfQueue.Enqueue(2);
            //listOfQueue.Dequeue();
            //listOfQueue.Enqueue(3);

            //Stack<int> listOfStack = new Stack<int>();
            //listOfStack.Push(1); // [0] [1] [0] [1]
            //listOfStack.Push(2); // [.] [0] 
            //listOfStack.Pop();
            //listOfStack.Push(3); // [.] [.] [.] [0]

            Dictionary<string, int> listOfDict = new Dictionary<string, int>();
            listOfDict.Add("satu", 1);
            listOfDict.Add("dua", 2);
            listOfDict.Add("tiga", 3);

            foreach (var item in listOfDict)
            {
                Console.WriteLine(item.Value);
            }
        }

        public void Get(int id)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            try
            {
                // membuat instance SqlCommand untuk mendefinisikan connection dan perintah untuk di eksekusi
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Division WHERE Id = @id";

                SqlParameter ParameterId = new SqlParameter();
                ParameterId.ParameterName = "@id";
                ParameterId.SqlDbType = SqlDbType.Int;
                ParameterId.Value = id;

                sqlCommand.Parameters.Add(ParameterId);

                // membuka koneksi
                sqlConnection.Open();

                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    // mengecek apakah ada data atau tidak
                    if (sqlDataReader.HasRows)
                    {
                        // jika ada, maka melakukan looping untuk menampilkan data
                        while (sqlDataReader.Read())
                        {
                            Console.WriteLine("Id: " + sqlDataReader[0]);
                            Console.WriteLine("Name: " + sqlDataReader[1]);
                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        // jika tidak ada, maka menampilkan kalimat dibawah ini
                        Console.WriteLine("No Data Found");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        public int Insert(Division division)
        {
            int result = 0;
            using (sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;
                try
                {
                    sqlCommand.CommandText = "INSERT INTO Division (Name) VALUES (@name);";
                    SqlParameter parameterName = new SqlParameter();
                    parameterName.ParameterName = "@name";
                    parameterName.SqlDbType = SqlDbType.NVarChar;
                    parameterName.Value = division.Name;
                    sqlCommand.Parameters.Add(parameterName);
                    result = sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();

                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    try
                    {
                        sqlTransaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Console.WriteLine(exRollback.Message);
                    };
                }
                return result;
            }
        }

        // update

        // delete
    }

    /*
     * SILAHKAN DILANJUT UNTUK INSERT, UPDATE, DELETE DAN GET BY ID
     * ISTIRAHAT JAM 12.00
     * KEMBALI PUKUL 13.00
     */
}
