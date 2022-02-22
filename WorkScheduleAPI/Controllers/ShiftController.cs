using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WorkScheduleAPI.Data;
using WorkScheduleAPI.Models;

namespace WorkScheduleAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShiftController : ControllerBase
    {
        private IShift _shift;

        public ShiftController(IShift shift)
        {
            _shift = shift;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Shift>>> GetShifts()
        {
            try
            {
                IList<Shift> shifts = await _shift.GetAsync();
                return Ok(shifts);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Shift>> AddShift([FromBody] Shift shift)
        {
            try
            {
                await _shift.PostAsync(shift);
                return Created($"/{shift.Id}", shift);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}