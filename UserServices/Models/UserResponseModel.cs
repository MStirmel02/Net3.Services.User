using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Net3.Services.User.UserServices.Models
{
    public class UserResponseModel
    {
        public UserModel? Response { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}
