using Cau1.BEL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAL
{
    public class Department_DAL : DbConnection
    {
        public List<Department_BEL> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SelectAllDepartment";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            List<Department_BEL> lstDeps = new List<Department_BEL>();

            while (reader.Read())
            {
                Department_BEL deps = new Department_BEL();
                deps.Id = reader["IdDepartment"].ToString();
                deps.Name = reader["Name"].ToString();
                lstDeps.Add(deps);
            }
            conn.Close();
            return lstDeps;
        }

        public Department_BEL ReadDepartment(string id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SelectAllDepartment";
            cmd.CommandType = CommandType.StoredProcedure;

        
            SqlDataReader reader = cmd.ExecuteReader();

            Department_BEL dmp = new Department_BEL();
            while (reader.Read() && reader.HasRows)
            {
                dmp.Id = reader["IdDepartment"].ToString();
                dmp.Name = reader["Name"].ToString();
            }
            conn.Close();
            return dmp;
        }
    }
}
