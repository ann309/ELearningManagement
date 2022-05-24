using ELearning.BLL.Interface;
using ELearning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ELearning.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CalenderController : ControllerBase
    {
        private readonly IOperationBLL<Calender> _calenderBLL;
        public CalenderController(IOperationBLL<Calender> calenderBLL)
        {
            _calenderBLL = calenderBLL;
        }

        
        [HttpPost]       
        public async Task<IActionResult> Create(Calender calenderVal)
        {
            var result = await _calenderBLL.CreateAsync(calenderVal);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Display()
        {
            var result = await _calenderBLL.DisplayAsync();
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var result = await _calenderBLL.SearchAsync(id);
            if (result != null) return Ok(result);
            else return NotFound("no such data exists");
        }

        
        [HttpDelete("{id}")]       
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _calenderBLL.DeleteAsync(id);
            if (result != null) return Ok(result);
            else return NotFound();
        }

       
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Calender calenderVal)
        {
            var result = await _calenderBLL.EditAsync(id, calenderVal);
            if (result != null) return Ok(result);
            else return NotFound("data could not be edited");
        }

    }
}
