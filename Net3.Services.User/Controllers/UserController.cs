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
        ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [Route("/login")]
        [ProducesResponseType(typeof(ResponseModel<bool>), 200)]
        [ProducesResponseType(typeof(ResponseModel<bool>), 500)]
        public async Task<ResponseModel<bool>> LoginUserAsync([Required][FromHeader] string userId, [Required][FromHeader] string passwordHash)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                UserModel user = new UserModel
                {
                    UserId = userId,
                    PasswordHash = passwordHash
                };
                response.Response = await _userService.UserLoginAsync(user);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, typeof(UserController));
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
            ResponseModel<bool> response = new ResponseModel<bool>();
            try
            {
                response.Response = await _userService.UserSignupAsync(user);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, typeof(UserController));
                return new ResponseModel<bool>
                {
                    Error = new Error {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }


        [HttpGet]
        [Route("/getall")]
        [ProducesResponseType(typeof(ResponseModel<List<AdminUserModel>>), 200)]
        [ProducesResponseType(typeof(ResponseModel<List<AdminUserModel>>), 500)]
        public async Task<ResponseModel<List<AdminUserModel>>> GetAllUsersAsync()
        {
            ResponseModel<List<AdminUserModel>> response = new ResponseModel<List<AdminUserModel>>();
            try
            {
                response.Response = await _userService.AdminGetUserMsgAsync();
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, typeof(UserController));
                return new ResponseModel<List<AdminUserModel>>
                {
                    Error = new Error
                    {
                        Code = 500,
                        Message = ex.Message
                    }
                };
            }
        }
    }
}
