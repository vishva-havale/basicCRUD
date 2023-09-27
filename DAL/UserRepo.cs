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
    public class UserRepo : IUserRepo
    {
        String _ConnectionString;
        public UserRepo(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        public User AddUser(User user)
        {
            int NumberOfRowsAffected = 0;
            using (SqlConnection sql = new SqlConnection(this._ConnectionString))
            {
                var cmd = new SqlCommand("sp_UserInsert", sql);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
                cmd.Parameters.AddWithValue("@LastName", user.LastName);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                SqlParameter outputParam = cmd.Parameters.Add("@UserId", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                sql.Open();
                NumberOfRowsAffected=cmd.ExecuteNonQuery();
               
                sql.Close();
                user.UserId = (int)outputParam.Value;
        
            }
            return user;
        }
    }
}
