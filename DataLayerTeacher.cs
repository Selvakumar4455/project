using System.Data;
using System.Data.SqlClient;
using TestWeb.Models;

namespace TestWeb.Common
{
    public class DataLayerTeacher
    {
        SqlConnection con;
        public DataLayerTeacher()
        {
            con = new SqlConnection("Data Source=LAPTOP-NCVMKQT3;Initial Catalog=School;Persist Security Info=True;User ID=sa;Password=sa");
        }

        public DataTable GetDataFromSP(string spName)
        {
            Teacher teacher = new Teacher();
            DataTable dt = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(spName, con);
            sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDataAdapter.Fill(dt);

            return dt;
        }

        public DataTable GetDataFromSP(string spName, List<SqlParameter> parameterCollection)
        {
            Teacher teacher = new Teacher();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterCollection.ToArray());

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);


            sqlDataAdapter.Fill(dt);

            return dt;

        }
        public DataTable UpdateFromSP(string spName, List<SqlParameter> parameterCollection)
        {

            Teacher teacher = new Teacher();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameterCollection.ToArray());
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return dt;
        }




    }
}

