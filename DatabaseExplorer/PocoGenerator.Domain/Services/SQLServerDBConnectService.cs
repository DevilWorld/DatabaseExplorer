using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PocoGenerator.Domain.Interfaces;
using PocoGenerator.Domain.Models;
using System.Data.SqlClient;
//using PocoGenerator.Common;



namespace PocoGenerator.Domain.Services
{
    public class SQLServerDBConnectService : IDbConnectService
    {
        public bool TestConnection(string strConnectionString)
        {
            var objConn = new SqlConnection();

            try
            {
                objConn.ConnectionString = strConnectionString;
                objConn.Open();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                objConn.Close();
            }
        }

        public void Connect(string strConnectionString)
        {
            using (var objConn = new SqlConnection())
            {
                objConn.ConnectionString = strConnectionString;
                objConn.Open();
            }
        }

        public IEnumerable<DatabaseName> GetDatabases()
        {
            var lstDatabases = new List<DatabaseName>();

            using (var objConnection = new SqlConnection())
            {

                objConnection.ConnectionString = Global.ConnectionString;
                objConnection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = objConnection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Select dbid, name from sys.sysdatabases Where dbid > 4";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var db = new DatabaseName()
                        {
                            DbId = Convert.ToInt32(reader.GetValue(0)),
                            DbName = reader.GetValue(1).ToString()
                        };

                        lstDatabases.Add(db);
                    }
                }
            }

            return lstDatabases;
        }
    }
}
