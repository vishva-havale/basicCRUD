using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class EmployeeAddressRepo : IEmployeeAddressRepo
    {
        string _connectionString;

        public EmployeeAddressRepo(string connectionString)  /*constructor*/
        {
            _connectionString = connectionString;
        }
        public EmpAddress addEmployeeAddress(EmpAddress empAddress)
        {
            int numberOfRowsAffected = 0;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                var cmd = new SqlCommand("sp_EmployeeAddressInsert/Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                empAddress.Add_Id = empAddress.Add_Id == 0 ? null : empAddress.Add_Id;
                cmd.Parameters.AddWithValue("@Address", empAddress.Address);
                cmd.Parameters.AddWithValue("@State", empAddress.State);
                cmd.Parameters.AddWithValue("@District", empAddress.District);
                cmd.Parameters.AddWithValue("@City", empAddress.City);
                cmd.Parameters.AddWithValue("@Emp_id", empAddress.Emp_id);
                SqlParameter outputParam = cmd.Parameters.Add("@Add_Id", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;

                con.Open();
                numberOfRowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                empAddress.Add_Id = (int)outputParam.Value;
            }
            return empAddress;
        }

        public IList<EmpAddress> GetAllEmployeeAddress()
        {
            List<EmpAddress> empDetails = new List<EmpAddress>();
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_getEmployee_address", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var emp = new EmpAddress()
                    {

                        Add_Id = (int)rdr["Add_Id"],
                        Address = rdr["Address"].ToString(),
                        State = rdr["State"].ToString(),
                        District = rdr["District"].ToString(),
                        City = rdr["City"].ToString(),
                        Emp_id = (int)rdr["Emp_id"]


                    };
                    empDetails.Add(emp);
                }
                return (empDetails);
            }
        }
    }
}
