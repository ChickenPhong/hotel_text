using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//using System.Windows.Forms;

namespace DataLayer
{
    public class function
    {
        protected SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=PHONGTRAN;Database=hoteldb;Trusted_Connection=True;TrustServerCertificate=Yes;MultipleActiveResultSets=true";
            return con;
        }
        public DataSet getData(String query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query, String message)
        {
            SqlConnection con = GetConnection();// Lấy kết nối SQL hợp lệ
            SqlCommand cmd = new SqlCommand();// Tạo đối tượng command

            con.Open();

            cmd.Connection = con;  // Gán kết nối cho command
            cmd.CommandText = query;// Gán câu lệnh SQL
            cmd.ExecuteNonQuery(); // Thực thi câu lệnh

            con.Close();

            //MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public SqlDataReader getForCombo(String query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            return sdr;
        }
    }
}
