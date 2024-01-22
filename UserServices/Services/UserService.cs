using System.Net;
using UserServices.Services;

namespace Net3.Services.User.Services
{
    public class UserService : IUserService
    {
        public HttpStatusCode UserLogin(string user, string pass)
        {
            return HttpStatusCode.OK;
        }

        public async Task<HttpStatusCode> LoginAsync(string user)
        {
            Task<HttpStatusCode> response = null;

            return response.Result;
        }
    }
}
