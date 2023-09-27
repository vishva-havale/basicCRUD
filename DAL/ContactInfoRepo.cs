
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
    public class ContactInfoRepo : IContactInfoRepo
    {
        string _ConnectionString;
        public ContactInfoRepo(string connectionString)
        {
            _ConnectionString = connectionString;
        }

        public ContactInfo addContactInfo(ContactInfo contactInfo)
        {
            int numberOfRowsAffected = 0;
            using (SqlConnection con =new SqlConnection(_ConnectionString)) 
            {
                var cmd = new SqlCommand("sp_ContactInformationInsert/Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", contactInfo.FirstName);
                cmd.Parameters.AddWithValue("@LastName", contactInfo.LastName);
                cmd.Parameters.AddWithValue("@ContactNumber", contactInfo.ContactNumber);
                cmd.Parameters.AddWithValue("Email",contactInfo.Email);
                cmd.Parameters.AddWithValue("Message",contactInfo.Message);
                SqlParameter outputParam = cmd.Parameters.Add("@ContactId", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;

                con.Open();
                numberOfRowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                contactInfo.ContactId = (int)outputParam.Value;
               
            }
            return contactInfo;
            
        }
    }
}
