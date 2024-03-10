﻿using Microsoft.AspNetCore.Mvc;
using Net3.Services.User.UserServices.Models;
using RestSharp;
using System.ComponentModel.DataAnnotations;
using System.Net;
using UserServices.Services;

namespace Net3.Services.User.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("/login")]
        [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
        [ProducesResponseType(typeof(ResponseModel<bool>), 500)]
        public async Task<ResponseModel<bool>> LoginUserAsync([Required][FromBody] UserModel user)
        {
            ResponseModel<bool> response = null;
            try
            {
                response.Response = await _userService.UserLoginAsync(user);
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>
                {
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }

        [HttpPost]
        [Route("/signup")]
        [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
        [ProducesResponseType(typeof(ResponseModel<bool>), 500)]
        public async Task<ResponseModel<bool>> SignupUserAsync([FromBody][Required] UserModel user)
        {
            ResponseModel<bool> response = null;
            try
            {
                response.Response = await _userService.UserSignupAsync(user);
                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>
                {
                    Error = new Error {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }
    }
}
