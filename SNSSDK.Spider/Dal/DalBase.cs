using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SNSSDK.Spider.Dal
{
    public class DalBase
    {
        #region Connection String & Timeout
        private readonly static ConcurrentDictionary<string, string> ConnectionDic = new ConcurrentDictionary<string, string>();
        public static string GetConnectionString(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
                return ConfigurationManager.ConnectionStrings["default"].ConnectionString;
            else
            {
                if (ConnectionDic.ContainsKey(connectionString))
                {
                    return ConnectionDic[connectionString];
                }
                else if (ConfigurationManager.ConnectionStrings[connectionString].ConnectionString != null)
                {
                    string conn = ConfigurationManager.ConnectionStrings[connectionString].ConnectionString;
                    ConnectionDic.TryAdd(connectionString, conn);
                    return conn;
                }
                else
                {
                    throw new Exception("在Web.config文件中找不到name为" + connectionString + "的connectionStrings");
                }
            }

        }
        public static SqlConnection GetConnection(string connectionString, bool isRead)
        {
            return new SqlConnection(GetConnectionString(connectionString));
        }

        public static IDbConnection GetConnection(string connectionString = null)
        {
            IDbConnection conn = null;

            try
            {
                string connStr = GetConnectionString(connectionString);
                if (connStr.EndsWith(".sqlite"))
                {
                    conn = new SQLiteConnection(connStr);
                }
                else
                {
                    conn = new SqlConnection(connStr);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return conn;
        }



        public static int ConnectionTimeout { get; set; }

        public static int GetTimeout(int? commandTimeout = null)
        {
            if (commandTimeout.HasValue)
                return commandTimeout.Value;

            return ConnectionTimeout;
        }

        #endregion
    }
}
