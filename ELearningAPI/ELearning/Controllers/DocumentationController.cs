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
    public class DocumentationController : ControllerBase
    {
        private readonly IOperationBLL<Documentation> _documentationBLL;
        public DocumentationController(IOperationBLL<Documentation> documentationBLL)
        {
            _documentationBLL = documentationBLL;
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpPost]
        public async Task<IActionResult> Create(Documentation documentationVal)
        {
            var result = await _documentationBLL.CreateAsync(documentationVal);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> Display()
        {
            var result = await _documentationBLL.DisplayAsync();
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var result = await _documentationBLL.SearchAsync(id);
            if (result != null) return Ok(result);
            else return NotFound("no such data exists");
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _documentationBLL.DeleteAsync(id);
            if (result != null) return Ok(result);
            else return NotFound();

        }

        [Authorize(Roles = UserRoles.Student + "," + UserRoles.Faculty)]
        [HttpPut]
        public async Task<IActionResult> Edit(int id,Documentation documentationVal)
        {
            var result = await _documentationBLL.EditAsync(id,documentationVal);
            if (result != null) return Ok(result);
            else return NotFound("data could not be edited");
        }

    }
}
