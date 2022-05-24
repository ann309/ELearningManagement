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
    public class ProjectController : ControllerBase
    {
        private readonly IOperationBLL<Project> _projectBLL;
        public ProjectController(IOperationBLL<Project> projectBLL)
        {
            _projectBLL = projectBLL;
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpPost]
        public async Task<IActionResult> Create(Project assignedVal)
        {
            var result = await _projectBLL.CreateAsync(assignedVal);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> Display()
        {
            var result = await _projectBLL.DisplayAsync();
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var result = await _projectBLL.SearchAsync(id);
            if (result != null) return Ok(result);
            else return NotFound("no such data exists");
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _projectBLL.DeleteAsync(id);
            if (result != null) return Ok(result);
            else return NotFound();

        }


        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpPut]
        public async Task<IActionResult> Edit(int id,Project projectVal)
        {
            var result = await _projectBLL.EditAsync(id,projectVal);
            if (result != null) return Ok(result);
            else return NotFound("data could not be edited");
        }

    }
}
