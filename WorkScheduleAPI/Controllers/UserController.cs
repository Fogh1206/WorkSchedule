using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WorkScheduleAPI.Data;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        private readonly ICompany _company;

        public UserController(IUser user, ICompany company)
        {
            _user = user;
            _company = company;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<User>> ValidateLogin([FromBody] LoginUserDTO userDTO)
        {
            Console.WriteLine("Hello");
            try
            {
                User user = await _user.ValidateUser(new User
                {
                    Username = userDTO.Username,
                    Password = userDTO.Password
                });
                return Ok(user);
                //return  Created($"/{user.Id}", user);
            }catch (Exception e) {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IList<User>>> GetUsers()
        {
            try {
                IList<User> companies = await _user.GetAsync();
                return Ok(companies);
                
            } catch (Exception e) {
                return StatusCode(500, e.Message);
                
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser([FromBody] CreateUserDTO userDTO)
        {
            Console.WriteLine("Hello 2 u");
            try
            {
                User user = new()
                {
                    Username = userDTO.Username,
                    Password = userDTO.Password,
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Company = await _company.GetByIdAsync(userDTO.CompanyId)
                };
                await _user.PostAsync(user);
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}