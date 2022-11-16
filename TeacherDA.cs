using Microsoft.Extensions.FileSystemGlobbing;
using NuGet.DependencyResolver;
using System.Data;
using System.Data.SqlClient;
using TestWeb.Common;
using TestWeb.Models;

namespace TestWeb.DataAccess
{
    public class TeacherDA
    {
        private SqlDbType ID;

        public List<Teacher> GetTeachers()
        {
            DataLayerTeacher dataLayerTeacher = new DataLayerTeacher();
            string spName = "Usp_Teacher_List";
            DataTable dt = dataLayerTeacher.GetDataFromSP(spName);

            List<Teacher> teachers = new List<Teacher>();

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Teacher teacher = new Teacher();
                    teacher.ID = Convert.ToInt32(dr["ID"]);
                    teacher.FirstName = dr["FirstName"].ToString();
                    teacher.MiddleName = dr["MiddleName"].ToString();
                    teacher.LastName = dr["LastName"].ToString();
                    teacher.Gender = Convert.ToChar(dr["Gender"]);
                    teacher.Address = dr["Address"].ToString();
                    teacher.DOB = DateTime.Now;
                    teachers.Add(teacher);
                }
            }

            return teachers;
        }

        public bool CreateTeacher(Teacher teacher)
        {
            DataLayerTeacher dataLayerTeacher = new DataLayerTeacher();
            string spName = "Usp_Teacher_Insert";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID", teacher.ID));
            sqlParameters.Add(new SqlParameter("@FirstName", teacher.FirstName));
            sqlParameters.Add(new SqlParameter("@MiddleName", teacher.MiddleName));
            sqlParameters.Add(new SqlParameter("@LastName", teacher.LastName));
            sqlParameters.Add(new SqlParameter("@Gender", teacher.Gender));
            sqlParameters.Add(new SqlParameter("@Address", teacher.Address));
            sqlParameters.Add(new SqlParameter("@DOB", teacher.DOB));
            DataTable dt = dataLayerTeacher.UpdateFromSP(spName, sqlParameters);
            Teacher teachers = new Teacher();

            return true;

        }

        public Teacher GetTeacher(int id)
        {
            DataLayerTeacher dataLayerTeacher = new DataLayerTeacher();
            string spName = "Usp_GetTeacherById_Select";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("ID", id));
            DataTable dt = dataLayerTeacher.GetDataFromSP(spName, sqlParameters);

            Teacher teacher = new Teacher();

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                teacher.ID = Convert.ToInt32(dr["ID"]);
                teacher.FirstName = dr["FirstName"].ToString();
                teacher.MiddleName = dr["MiddleName"].ToString();
                teacher.LastName = dr["LastName"].ToString();
                teacher.Gender = Convert.ToChar(dr["Gender"]);
                teacher.Address = dr["Address"].ToString();
                teacher.DOB = DateTime.Now;
            }

            return teacher;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            DataLayerTeacher dataLayerTeacher = new DataLayerTeacher();
            string spName = "Usp_Teacher_Update";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID", teacher.ID));
            sqlParameters.Add(new SqlParameter("@FirstName", teacher.FirstName));
            sqlParameters.Add(new SqlParameter("@MiddleName", teacher.MiddleName));
            sqlParameters.Add(new SqlParameter("@LastName", teacher.LastName));
            sqlParameters.Add(new SqlParameter("@Gender", teacher.Gender));
            sqlParameters.Add(new SqlParameter("@Address", teacher.Address));
            sqlParameters.Add(new SqlParameter("@DOB", teacher.DOB));
            DataTable dt = dataLayerTeacher.UpdateFromSP(spName, sqlParameters);
            Teacher teachers = new Teacher();

            return true;


        }

        public bool DeleteTeacher(int id)
        {
            DataLayerTeacher dataLayerTeacher = new DataLayerTeacher();
            string spName = "Usp_Teacher_Delete";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@ID", id));
            DataTable dt = dataLayerTeacher.UpdateFromSP(spName, sqlParameters);
            return true;
        }
    }
}

