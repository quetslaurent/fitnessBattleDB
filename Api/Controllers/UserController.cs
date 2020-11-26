﻿using System;
using Application.Services.User;
using Application.Services.User.Dto;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBattle.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<OutputDtoQueryUser> Query()
        {
            return Ok(_userService.Query());
        }
        
        [HttpGet]
        [Route("points/{id:int}")]
        public ActionResult<int> GetUserPointsById(int id)
        {
            return Ok(_userService.GetUserPointsById(id));
        }

        [HttpPost]
        public ActionResult<OutputDtoAddUser> Post([FromBody] InputDtoAddUser inputDtoAddUser)
        {
            return Ok(_userService.Create(inputDtoAddUser));
        }
    }
}