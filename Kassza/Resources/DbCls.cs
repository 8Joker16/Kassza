using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Kassza.Resources
{
    public static class DbCls
    {
        public static SqlConnection GetDbConn()
        {
            string conn_string = Properties.Settings.Default.conn_string;
            SqlConnection sqlconn = new SqlConnection(conn_string);
            if (sqlconn.State != ConnectionState.Open)
                sqlconn.Open();
            return sqlconn;
        }

        public static DataTable GetDataTable(string sql_comm)
        {
            SqlConnection sqlconn = GetDbConn();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql_comm, sqlconn);
            adapter.Fill(table);
            return table;
        }

        public static void ExecSql(string sql_comm)
        {
            SqlConnection sqlconn = GetDbConn();
            SqlCommand command = new SqlCommand(sql_comm, sqlconn);
            command.ExecuteNonQuery();
        }

        public static void CLoseDbConn()
        {
            string conn_string = Properties.Settings.Default.conn_string;
            SqlConnection connection = new SqlConnection(conn_string);
            if (connection.State != ConnectionState.Closed)
                connection.Close();
        }

    }
}
