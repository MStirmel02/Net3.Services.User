using Microsoft.Extensions.Configuration;
using Net3.Services.User.UserServices.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using UserServices.Services;

namespace Net3.Services.User.Services
{
    public class UserService : IUserService
    {
        protected readonly IConfiguration _configuration;
        public UserService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<bool> UserSignupAsync(UserModel user)
        {
            SqlConnection conn = new SqlConnection(_configuration["ConnectionStrings:Database"]);
            var cmd = new SqlCommand("sp_create_user", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar);
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar);

            cmd.Parameters["@UserID"].Value = user.UserId;
            cmd.Parameters["@PasswordHash"].Value = user.PasswordHash;
            cmd.Parameters["@Email"].Value = user.Email;

            try
            {
                conn.Open();

                if (cmd.ExecuteNonQueryAsync().Result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally { conn.Close(); }
        }

        public async Task<bool> UserLoginAsync(UserModel user)
        {
            SqlConnection conn = new SqlConnection(_configuration["ConnectionStrings:Database"]);
            var cmd = new SqlCommand("sp_user_sign_in", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@UserID", SqlDbType.NVarChar);
            cmd.Parameters.Add("@PasswordHash", SqlDbType.NVarChar);

            cmd.Parameters["@UserID"].Value = user.UserId;
            cmd.Parameters["@PasswordHash"].Value = user.PasswordHash;

            try
            {
                conn.Open();

                if (cmd.ExecuteNonQueryAsync().Result != 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
            finally { conn.Close(); }
        }
    }
}
