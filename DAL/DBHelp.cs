using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class DBHelp
    {
        /// <summary>
        /// 连接字符串
        /// </summary>
        private static string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        /// <summary>
        /// 此方法运用于数据的增删改
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="list">sql语句中的参数集合</param>
        /// <returns>返回的受影响行数</returns>
        public static int ExecuteCUD(string sql, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr)) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddRange(list != null && list.Count > 0 ? list.ToArray() : new List<SqlParameter> { }.ToArray());
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 此方法用于返回第一行第一列的值
        /// </summary>
        /// <param name="sql">用于执行的sql语句</param>
        /// <param name="list">sql语句中的参数集合</param>
        /// <returns>返回查询出来的值</returns>
        public static object ExecuteSingle(string sql, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr)) 
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(list != null && list.Count > 0 ? list.ToArray() : new List<SqlParameter> { }.ToArray());
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// 此方法用于返回一个阅读器对象
        /// </summary>
        /// <param name="sql">数据库语句</param>
        /// <param name="list">参数集</param>
        /// <returns>阅读器对象</returns>
        public static SqlDataReader ExecuteReader(string sql, List<SqlParameter> list)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql,conn);
                cmd.Parameters.AddRange(list != null && list.Count > 0 ? list.ToArray() : new List<SqlParameter> { }.ToArray());
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 此方法用于返回多行多列的DataTable
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="list">语句中的参数集合</param>
        /// <returns>返回查询出来的值</returns>
        public static DataTable ExecuteDT(string sql, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(list != null && list.Count > 0 ? list.ToArray() : new List<SqlParameter> { }.ToArray());
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable ();
                sda.Fill(dt);
                return dt;
            }
        }

        /// <summary>
        /// 此方法用于执行存储过程
        /// </summary>
        /// <param name="sql">要执行的sql语句</param>
        /// <param name="list">语句中的参数集合</param>
        /// <returns>返回查询出来的值</returns>
        public static SqlDataReader ExecuteReaderProc(string sql, List<SqlParameter> list)
        {
            try
            {
                SqlConnection conn = new SqlConnection(connStr);
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddRange(list != null && list.Count > 0 ? list.ToArray() : new List<SqlParameter> { }.ToArray());
                cmd.CommandType = CommandType.StoredProcedure;
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
