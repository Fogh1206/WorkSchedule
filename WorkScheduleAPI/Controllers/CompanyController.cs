using System;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkScheduleAPI.Data;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {

        private ICompany _company;

        public CompanyController(ICompany company)
        {
            _company = company;
        }

        [HttpGet]
        public async Task<ActionResult<GetCompanyDTO>> GetCompanies()
        {
            try
            {
                var companyResults = await _company.GetAsync();
                return Ok(companyResults.Select(c => new GetCompanyDTO
                {
                    Name = c.Name,
                    Users = c.Users
                }));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Company/{id:int}")]
        public async Task<ActionResult<Company>> GetCompanyById([FromRoute] int id)
        {
            try
            {
                Company company = await _company.GetByIdAsync(id);
                return Ok(company);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Company>> AddCompany([FromBody] CreateCompanyDTO companyDTO)
        {
            Console.WriteLine("Yes");
            try
            {
                Company company = new()
                {
                    Name = companyDTO.Name
                };
                await _company.PostAsync(company);
                return Ok(company);
                //return Created($"/{company.Id}", company);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        

    }
}