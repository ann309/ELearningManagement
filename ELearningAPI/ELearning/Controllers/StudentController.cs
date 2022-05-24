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
    public class StudentController : ControllerBase
    {
        private readonly IPersonBLL<Student> _student;
        private readonly IUserBLL<UserInformation> _user;
        public StudentController(IPersonBLL<Student> student,IUserBLL<UserInformation> user)
        {
            _student = student;
            _user = user;
        }

        [Authorize(Roles = UserRoles.Student)]
        [HttpPut]
        public IActionResult Edit(string id, Student student)
        {

            var result = _student.EditAsync(id, student);
            if (result != null) return Ok("Successfully edited");
            else return BadRequest("operation unsuccessfull");

        }

        [Authorize(Roles = UserRoles.Student+","+UserRoles.Faculty)]
        [HttpPut]
        public IActionResult GetStudentDetails(string id)
        {

            var result = _student.GetDetailsAsync(id);
            if (result != null) return Ok(result);
            else return BadRequest("operation unsuccessfull");

        }

    }
}
