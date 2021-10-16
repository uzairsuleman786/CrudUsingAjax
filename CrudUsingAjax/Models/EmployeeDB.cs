using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CrudUsingAjax.Models
{
    public class EmployeeDB
    {
        string cs = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

        public List<Employee> ListAll()
        {
            List<Employee> listOfEmployee = new List<Employee>();

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("SelectEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    listOfEmployee.Add(
                        new Employee
                        {
                            EmployeeID = Convert.ToInt32(sdr["EmployeeId"]),
                            Name = sdr["Name"].ToString(),
                            Age = Convert.ToInt32(sdr["Age"])
                        });
                }


                con.Close();
            }

                return listOfEmployee;
        }

        public int Add(Employee emp)
        {
            int i;

            using(SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Action", "Insert");
                i = cmd.ExecuteNonQuery();
                con.Close();
            }

            return i;
        }

        public int Update(Employee emp)
        {
            int i;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("InsertUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeID);
                cmd.Parameters.AddWithValue("@Name", emp.Name);
                cmd.Parameters.AddWithValue("@Age", emp.Age);
                cmd.Parameters.AddWithValue("@Action", "Update");
                i = cmd.ExecuteNonQuery();
                con.Close();
            }

            return i;
        }

        public int Delete(int Id)
        {
            int i;

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                i = cmd.ExecuteNonQuery();
                con.Close();
            }

            return i;
        }
    }
}