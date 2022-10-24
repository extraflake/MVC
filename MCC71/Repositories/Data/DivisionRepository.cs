using MCC71.Context;
using MCC71.Models;
using MCC71.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MCC71.Repositories.Data
{
    public class DivisionRepository : IDivisionRepository // ditulis
    {
        SqlConnection sqlConnection; // ditulis
        
        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Division> Get()
        {
            sqlConnection = new SqlConnection(MyContext.GetConnection());
            List<Division> divisions = new List<Division>();
            try
            {
                // membuat instance SqlCommand untuk mendefinisikan connection dan perintah untuk di eksekusi
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Division";

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
                            Division division = new Division(
                                Convert.ToInt32(sqlDataReader[0]), 
                                sqlDataReader[1].ToString());
                            divisions.Add(division);
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
            return divisions;
        }

        public Division Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Division division)
        {
            throw new NotImplementedException();
        }

        public int Update(Division division)
        {
            throw new NotImplementedException();
        }
    }
}
