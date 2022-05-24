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
    public class ChatController : ControllerBase
    {
        private readonly IChatBLL _chatBLL;
        public ChatController(IChatBLL chatBLL)
        {
            _chatBLL = chatBLL;
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(Chat chat)
        {
            var result = await _chatBLL.CreateAsync(chat);
            return Ok(result);
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("")]
        public async Task<IActionResult> Display()
        {
            var result = await _chatBLL.DisplayAsync();
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _chatBLL.DeleteAsync(id);
            if (result != null) return Ok(result);
            else return NotFound();

        }

        [HttpGet("userName")]
        public async Task<IActionResult> MyChats(string userName)
        {
            var result = await _chatBLL.MyChatsAsync(userName);
            if (result != null) return Ok(result);
            else return NotFound("no  data exists");
        }
    }
}
