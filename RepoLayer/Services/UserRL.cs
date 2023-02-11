using Microsoft.Extensions.Configuration;
using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepoLayer.Services
{
    public class UserRL : IUserRL
    {
        private readonly IConfiguration configuration;
        public UserRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void addEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayRoll")))
            {
                {
                    SqlCommand cmd = new SqlCommand("spAddNewEmployee", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Emp_name", employeeModel.Emp_name);
                    cmd.Parameters.AddWithValue("@Profile_img", employeeModel.Profile_img);
                    cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                    cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                    cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                    cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                    cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();


                }
            }
        }
        //To Update the records of a particluar employee
        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayRoll")))
            {

                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emp_id", employeeModel.Emp_id);
                cmd.Parameters.AddWithValue("@Emp_name", employeeModel.Emp_name);
                cmd.Parameters.AddWithValue("@Profile_img", employeeModel.Profile_img);
                cmd.Parameters.AddWithValue("@Gender", employeeModel.Gender);
                cmd.Parameters.AddWithValue("@Department", employeeModel.Department);
                cmd.Parameters.AddWithValue("@Salary", employeeModel.Salary);
                cmd.Parameters.AddWithValue("@StartDate", employeeModel.StartDate);
                cmd.Parameters.AddWithValue("@Notes", employeeModel.Notes);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


            }


        }
        //To Delete the record on a particular employee
        public void DeleteEmployee(int? id)
        {
            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Emp_id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        //To View all employees details
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();
            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayRoll")))
            {
                SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    EmployeeModel employee = new EmployeeModel();

                    employee.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                    employee.Emp_name = rdr["Emp_name"].ToString();
                    employee.Profile_img = rdr["Profile_img"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToDouble(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();

                    lstemployee.Add(employee);
                }
                con.Close();
            }
            return lstemployee;
        }

        public EmployeeModel GetEmployeeById(int? id)
        {
            EmployeeModel employee = new EmployeeModel();
            using (SqlConnection con = new SqlConnection(this.configuration.GetConnectionString("EmployeePayRoll")))
            {
                string sqlQuery = "SELECT * FROM tblEmployee WHERE Emp_id= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employee.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                    employee.Emp_name = rdr["Emp_name"].ToString();
                    employee.Profile_img = rdr["Profile_img"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToDouble(rdr["Salary"]);
                    employee.StartDate = Convert.ToDateTime(rdr["StartDate"]);
                    employee.Notes = rdr["Notes"].ToString();
                }
                con.Close();
            }
            return employee;
        }
    }
}
