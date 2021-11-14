using System;
using System.Data;
using System.Data.SqlClient;

namespace Automanager.Core
{
    public class DatabaseHelper
    {
        #region ExcuteDataReader thi hành lệnh - trả về đối tượng giao diện IDataReader như SqlDataReader, từ đó đọc được dữ liệu trả về
        /// <summary>
        ///     Trả về datareader với trường hợp CommandType=CommandType.StoreProcedure
        /// </summary>
        /// <param name="connection">connection</param>
        /// <param name="commandText"></param>
        /// <param name="sqlparam">sqlparametrer</param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(string connection, string commandText, SqlParameter[] sqlparam)
        {
            try
            {
                var con = new SqlConnection(connection);
                var com = new SqlCommand
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = commandText
                };
                con.Open();
                if (sqlparam != null)
                    com.Parameters.AddRange(sqlparam);
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (DataException)
            {
                //Logger.Instance.Equals(Logger.ErrConnect + e);
                return null;
            }
        }

        public static IDataReader ExecuteReader(string connection, string commandText, SqlParameter[] sqlparam,
            out SqlCommand comx)
        {
            try
            {
                var con = new SqlConnection(connection);
                var com = new SqlCommand
                {
                    Connection = con,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = commandText
                };
                con.Open();
                if (sqlparam != null)
                    com.Parameters.AddRange(sqlparam);
                comx = com;
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (DataException)
            {
                //Logger.Instance.Equals(Logger.ErrConnect + e);
                comx = null;
                return null;
            }
        }

        public static DataTable GetDataTable(SqlCommand sqlCommand, string connection)
        {
            var con = new SqlConnection(connection);
            try
            {
                sqlCommand.Connection = con;

                var myDataAdapter = new SqlDataAdapter(sqlCommand);
                var myDataSet = new DataSet();
                myDataAdapter.Fill(myDataSet);
                return myDataSet.Tables[0];
            }
            catch (SqlException myException)
            {
                throw myException;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        /// <summary>
        ///     Trả về datareader với trường hợp CommandType=CommandType.Textr
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commndText"></param>
        /// <returns></returns>
        public static IDataReader ExecuteReader(string connection, string commndText)
        {
            try
            {
                var con = new SqlConnection(connection);
                var com = new SqlCommand
                {
                    CommandText = commndText,
                    CommandType = CommandType.Text,
                    Connection = con
                };
                con.Open();
                return com.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (DataException)
            {
                //Logger.Instance.Error(Logger.ErrConnect + e);
                return null;
            }
        }

        #endregion
        #region ExecuteNonQuery thi hành truy vấn - không cần trả về dữ liệu gì, phù hợp thực hiện các truy vấn như Update, Delete
        /// <summary>
        ///     ExecuteNonQuery trường hợp sử dụng storeprocedure
        /// </summary>
        /// <param name="connection">Config.Connectstring</param>
        /// <param name="commandText"></param>
        /// <param name="sqlparam">nếu store không có tham số truyền vào null</param>
        /// <returns>số bản ghi ảnh hưởng</returns>
        public static int ExecuteNonQuery(string connection, string commandText, SqlParameter[] sqlparam)
        {
            try
            {
                var conn = new SqlConnection(connection);
                using(conn)
                {
                    var com = new SqlCommand
                    {
                        CommandText = commandText,
                        CommandType = CommandType.StoredProcedure,
                        Connection = conn
                    };
                    conn.Open();
                    if(sqlparam != null)
                    {
                        com.Parameters.AddRange(sqlparam);
                    }
                    return com.ExecuteNonQuery();
                }
            }
            catch(DataException ex)
            {
                return -1;
            }
        }

        public static int ExecuteNonQuery(string connection, string commandText, SqlParameter[] sqlparam,
            out SqlCommand comx)
        {
            try
            {
                var con = new SqlConnection(connection);
                using (con)
                {
                    var com = new SqlCommand
                    {
                        CommandText = commandText,
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    con.Open();
                    if (sqlparam != null)
                        com.Parameters.AddRange(sqlparam);
                    comx = com;
                    return com.ExecuteNonQuery();
                }
            }
            catch (DataException)
            {
                //Logger.Instance.Error(Logger.ErrConnect + e);
                comx = null;
                return -1;
            }
        }

        /// <summary>
        ///     Trường hợp sử dụng commandText
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string connection, string commandText)
        {
            try
            {
                var con = new SqlConnection(connection);
                using (con)
                {
                    var com = new SqlCommand
                    {
                        CommandText = commandText,
                        CommandType = CommandType.Text,
                        Connection = con
                    };
                    con.Open();
                    return com.ExecuteNonQuery();
                }
            }
            catch (DataException)
            {
                //Logger.Instance.Error(Logger.ErrConnect + e);
                return -1;
            }
        }
        #endregion
        #region ExecuteScalar thi hành và trả về một giá trị duy nhất - ở hàng đầu tiên, cột đầu tiên

        public static object ExecuteScalar(string connection, string commandText, SqlParameter[] sqlparam)
        {
            try
            {
                var con = new SqlConnection(connection);
                using (con)
                {
                    var com = new SqlCommand
                    {
                        CommandText = commandText,
                        CommandType = CommandType.StoredProcedure,
                        Connection = con
                    };
                    con.Open();
                    if (sqlparam != null)
                        com.Parameters.AddRange(sqlparam);
                    return com.ExecuteScalar();
                }
            }
            catch (DataException)
            {
                //Logger.Instance.Error(Logger.ErrConnect + e);
                return -1;
            }
        }

        public static object ExecuteScalar(string connection, string commandText)
        {
            try
            {
                var con = new SqlConnection(connection);
                using (con)
                {
                    var com = new SqlCommand
                    {
                        CommandText = commandText,
                        CommandType = CommandType.Text,
                        Connection = con
                    };
                    con.Open();
                    return com.ExecuteScalar();
                }
            }
            catch (DataException)
            {
                //Logger.Instance.Error(Logger.ErrConnect + e);
                return -1;
            }
        }

        #endregion
        
    }
}
