using ELearning.BLL.Interface;
using ELearning.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class AssignController : ControllerBase
    {
        private readonly IAssignedBLL _assignBLL;
        public AssignController(IAssignedBLL assignBLL)
        {
            _assignBLL = assignBLL;
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpPost]
        public async Task<IActionResult> Create(Assigned assignedVal)
        {
            var result = await _assignBLL.CreateAsync(assignedVal);
            return Ok(result);
        }

        
        [HttpGet("")]
        public async Task<IActionResult> Display()
        {
            var result = await _assignBLL.DisplayAsync();
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var result = await _assignBLL.SearchAsync(id);
            if (result != null) return Ok(result);
            else return NotFound("no such data exists");
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _assignBLL.DeleteAsync(id);
            if (result != null) return Ok(result);
            else return NotFound("Data not found");

        }

        
        [HttpPut]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        public async Task<IActionResult> Edit(int id,Assigned assignVal)
        {
            var result = await _assignBLL.EditAsync(id,assignVal);
            if (result != null) return Ok(result);
            else return NotFound("data could not be edited");
        }

        
        [HttpPut]
        [Authorize(Roles = UserRoles.Student)]
        public async Task<IActionResult> EditAccessibleByStudentAsync(int id, Assigned assignVal)
        {
            var result = await _assignBLL.EditAsync(id, assignVal);
            if (result != null) return Ok(result);
            else return NotFound("data could not be edited");
        }

    }
}
