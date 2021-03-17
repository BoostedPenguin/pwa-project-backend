﻿using Microsoft.AspNetCore.Mvc;
using net_core_backend.Models;
using net_core_backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace net_core_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }


        [HttpPost("verify")]
        public async Task<IActionResult> UserVerification([FromBody] VerificationRequest model)
        {
            try
            {
                var response = await accountService.UserVerification(model);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize]
        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest model)
        {
            try
            {
                var response = await accountService.AddUser(model);

                return Ok(new { link = response });
            }
            catch(Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            try
            {
                var response = await accountService.Login(model);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOrganization([FromBody]CreateOrganizationRequest request)
        {
            try
            {
                var response = await accountService.CreateOrganization(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
