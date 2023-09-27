using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeRepo : IEmployeeRepo
    {
        string _connectionString;

        public EmployeeRepo(string connectionString)  /*constroctor*/ 
        {
            _connectionString = connectionString;   
        }
        
        public Employee CreateEmployee(Employee employee)
        {
            int numberOfRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                var cmd = new SqlCommand("sp_InsertEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
             
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@mobile", employee.mobile);
                cmd.Parameters.AddWithValue("@email", employee.email);
                cmd.Parameters.AddWithValue("@Address", employee.Address);
                cmd.Parameters.AddWithValue("@State", employee.State);
                cmd.Parameters.AddWithValue("@District", employee.District);
                cmd.Parameters.AddWithValue("@City", employee.City);
                SqlParameter outputParam = cmd.Parameters.Add("@emp_id", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;

                con.Open();
                numberOfRowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                employee.emp_id = (int)outputParam.Value;
            }
            return employee;
        }
        public Employee UpdateEmployee(Employee employee)
        {
            int numberOfRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                var cmd = new SqlCommand("sp_EmployeeInsert/Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emp_id", employee.emp_id);
                cmd.Parameters.AddWithValue("@name", employee.name);
                cmd.Parameters.AddWithValue("@salary", employee.salary);
                cmd.Parameters.AddWithValue("@mobile", employee.mobile);
                cmd.Parameters.AddWithValue("@email", employee.email);
        

                con.Open();
                numberOfRowsAffected = cmd.ExecuteNonQuery();
                con.Close();
               
            }
            return employee;
        }

        public IList<Employee> GetAll()
        {
            List<Employee> empDetails = new List<Employee>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_getEmployeeDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
           

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var emp = new Employee()
                    {

                        emp_id = (int)rdr["emp_id"],
                        name = rdr["name"].ToString(),
                        salary = rdr["salary"].ToString(),
                        mobile = rdr["mobile"].ToString(),
                        email = rdr["email"].ToString(),
                        Address = rdr["Address"].ToString(),
                        State = rdr["State"].ToString(),
                        District = rdr["District"].ToString(),
                        City = rdr["City"].ToString(),
                        CreatedDate =(DateTime) rdr["CreatedDate"],
                        IsActive = (Boolean) rdr["IsActive"]
                    };
                    empDetails.Add(emp);
                }
                return (empDetails);
            }
        }

        public Employee GetById(int id)
        {
            Employee empDetails = new Employee();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_getEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    empDetails = new Employee()
                    {

                        emp_id = (int)rdr["emp_id"],
                        name = rdr["name"].ToString(),
                        salary = rdr["salary"].ToString(),
                        mobile = rdr["mobile"].ToString(),
                        email = rdr["email"].ToString(),
                        CreatedDate = (DateTime)rdr["CreatedDate"],
                        IsActive = (Boolean)rdr["IsActive"]


                    };
            
                }
                return (empDetails);
            }
        }
        public bool DeleteEmployee(int id)
        {
            int numberOfRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("sp_DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.Parameters.AddWithValue("@Id", id);
                numberOfRowsAffected = cmd.ExecuteNonQuery();
                con.Close();
            }
            return numberOfRowsAffected > 0;
        }
    }
}

