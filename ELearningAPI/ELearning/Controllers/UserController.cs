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
    public class UserController : ControllerBase
    {
        private readonly IUserBLL<UserInformation> _userBLL;
        public UserController(IUserBLL<UserInformation> userBLL)
        {
            _userBLL = userBLL;
        }

        [HttpGet("")]
        [Authorize(Roles = UserRoles.Admin+","+UserRoles.Faculty)]
        public async Task<IActionResult> DisplayStudent()
        {
            var result = await _userBLL.DisplayStudentAsync();
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }

        [HttpGet("")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DisplayFaculty()
        {
            var result = await _userBLL.DisplayFacultyAsync();
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }


        [HttpGet]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Search(string userName)
        {
            var result = await _userBLL.SearchAsync(userName);
            if (result != null) return Ok(result);
            else return NotFound("no such data exists");
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        public async Task<IActionResult> MyUploads(string userName)
        {
            var result = await _userBLL.MyUploads(userName);
            if (result != null) return Ok(result);
            else return NotFound("no such data exists");
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _userBLL.DeleteAsync(id);
            if (result != null) return Ok(result);
            else return NotFound();

        }

        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult> Edit(string id,UserInformation user)
        {
            var result = await _userBLL.EditAsync(id,user);
            if (result != null) return Ok(result);
            else return NotFound("data could not be edited");
        }

    }
}
