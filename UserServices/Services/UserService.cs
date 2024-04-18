using Microsoft.Extensions.Configuration;
using Net3.Services.Channel.Services.Services;
using Net3.Services.User.UserServices.Models;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Channels;
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
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@UserID",
                    Value = user.UserId
                },
                new SqlParameter
                {
                    ParameterName = "@PasswordHash",
                    Value = user.PasswordHash
                }
            };

            try
            {
                int result = await SqlExecutor.ExecuteNonQueryAsync(conn, sqlParam, "sp_create_user");

                return result == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UserLoginAsync(UserModel user)
        {
            SqlConnection conn = new SqlConnection(_configuration["ConnectionStrings:Database"]);
            List<SqlParameter> sqlParam = new List<SqlParameter>
            {
                new SqlParameter
                {
                    ParameterName = "@UserID",
                    Value = user.UserId
                },
                new SqlParameter
                {
                    ParameterName = "@PasswordHash",
                    Value = user.PasswordHash
                }
            };

            try
            {
                int result = await SqlExecutor.ExecuteNonQueryAsync(conn, sqlParam, "sp_user_sign_in");

                return result == 1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
