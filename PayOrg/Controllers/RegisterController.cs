﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Cryptography;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PayOrg.Models;
using PayOrg.Repository;
using PayOrg.Responses;

namespace PayOrg.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : BaseController
    {
        private RegisterRepository _registerRepository;        
        
        public RegisterController(ILogger<RegisterController> logger, IConfiguration config, RegisterRepository registerRepository) : base(logger, config)
        {
            _registerRepository = registerRepository;
            _configuration = config;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("Create")]
        public async Task<ActionResult<RegisterResponse>> Create(RegisterModel register)
        {
            register.Senha = AES.Encrypt(register.Senha, "xx7UQjjb7");
            RegisterResponse registerResponse = await _registerRepository.CreateAsync(register);
            if( registerResponse.EmailAlreadyExists)
            {
                registerResponse.StatusCode = HttpStatusCode.BadRequest;
                registerResponse.Message = "E-mail already in use. " + 
                                           "Please use the password recovery"+
                                           " if you forgot this account password.";
                return BadRequest(registerResponse);
            }
            else
            {
                registerResponse.StatusCode = HttpStatusCode.OK;
                registerResponse.Message = "User created with success";

            }
            return Ok(registerResponse);
        }
        
    }
}
