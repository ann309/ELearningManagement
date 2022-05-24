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
    public class ArticleController : ControllerBase
    {
        private readonly IOperationBLL<Articles> _articleBLL;
        public ArticleController(IOperationBLL<Articles> articleBLL)
        {
            _articleBLL = articleBLL;
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpPost]
        public async Task<IActionResult> Create(Articles articleVal)
        {
            var result = await _articleBLL.CreateAsync(articleVal);
            return Ok(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> Display()
        {
            var result = await _articleBLL.DisplayAsync();
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> Search(int id)
        {
            var result = await _articleBLL.SearchAsync(id);
            if (result != null) return Ok(result);
            else return NotFound("no such data exists");
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _articleBLL.DeleteAsync(id);
            if (result != null) return Ok(result);
            else return NotFound();
        }

        [Authorize(Roles = UserRoles.Admin + "," + UserRoles.Faculty)]
        [HttpPut]
        public async Task<IActionResult> Edit(int id, Articles articleVal)
        {
            var result = await _articleBLL.EditAsync(id, articleVal);
            if (result != null) return Ok(result);
            else return NotFound("data could not be edited");
        }
    }
}
