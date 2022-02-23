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
        private IUser _user;

        public ShiftController(IShift shift, IUser user)
        {
            _shift = shift;
            _user = user;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shift>>> GetShifts()
        {
            try
            {
                IEnumerable<Shift> shifts = await _shift.GetAsync();
                return Ok(shifts);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Shift>> AddShift([FromBody] CreateShiftDTO shiftDTO)
        {
            try
            {
                Shift shift = new()
                {
                    Start = shiftDTO.Start,
                    End = shiftDTO.End,
                    User = await _user.GetByIdAsync(shiftDTO.UserId)
                };
                
                await _shift.PostAsync(shift);
                return Ok(shift);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("/Shifts/{id:int}")]
        public async Task<ActionResult<IEnumerable<GetShiftDTO>>> GetShiftsFromUserId([FromRoute] int id)
        {
            try
            {
                return Ok(await _shift.GetFromUserIdAsync(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        
    }
}