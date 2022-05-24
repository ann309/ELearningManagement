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
    public class FacultyController : ControllerBase
    {
        private readonly IPersonBLL<Faculty> _faculty;
        public FacultyController(IPersonBLL<Faculty> faculty)
        {
            _faculty = faculty;
        }

        [Authorize(Roles = UserRoles.Faculty)]
        [HttpPut]
        public IActionResult Edit(string id, Faculty faculty)
        {

            var result = _faculty.EditAsync(id, faculty);
            if (result != null) return Ok("Successfully edited");
            else return BadRequest("operation unsuccessfull");
        }

        [Authorize(Roles = UserRoles.Faculty)]
        [HttpPut]
        public IActionResult GetFacultyDetails(string id)
        {
            var result = _faculty.GetDetailsAsync(id);
            if (result != null) return Ok(result);
            else return BadRequest("operation unsuccessfull");
        }

    }
}
