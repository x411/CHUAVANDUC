
using System.Data.SqlClient;
using System;
using System.Windows.Forms;
using System.Configuration;
using System.IO;

namespace Framework
{
  
    public class ConnectionManager
    {
               
        private static string _connectionString = "";

        private static Framework.ReadConnectInfo ConnectInfo = new Framework.ReadConnectInfo();
       
        public static SqlConnection GetConnection()
        {
            try
            {
                string pathFile = String.Empty;
                pathFile = System.AppDomain.CurrentDomain.BaseDirectory + "Server.ini";

                ConnectInfo.TextFileReading(pathFile);

                if (ConnectInfo.mStrUserName.Trim() != String.Empty && ConnectInfo.mStrPassword.Trim() != String.Empty)
                {
                    _connectionString = "User ID=" + ConnectInfo.mStrUserName + ";" +
                                        "Password=" + ConnectInfo.mStrPassword + ";" +
                                        "Data Source=" + ConnectInfo.mStrServerName + ";" +
                                        "Persist Security Info=True;" +
                                        "Initial Catalog=" + ConnectInfo.mStrDatabaseName + ";";
                }
                else
                {
                    _connectionString = "";
                }
            }
            // web - UI
            catch
            {
            }

            return new SqlConnection(_connectionString);
          
        }
        
    }
}
