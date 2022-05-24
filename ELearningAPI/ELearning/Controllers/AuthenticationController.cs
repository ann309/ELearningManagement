using ELearning.DAL.Models;
using ELearning.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ELearning.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {

        private readonly UserManager<UserInformation> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<UserInformation> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromForm] LogIn logIn)
        {
            var user = await userManager.FindByNameAsync(logIn.UserName);
            if (user != null && await userManager.CheckPasswordAsync(user, logIn.Password) )
            {
                var userRoles = await userManager.GetRolesAsync(user);
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),             
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };
                
                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var finalToken = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    role = userRoles,
                    expiration =token.ValidTo
                });                
            }
            return Unauthorized();
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> RegisterFaculty([FromBody] SignUp signUp)
        {
            var userExists = await userManager.FindByNameAsync(signUp.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Faculty already exists!" });

            Faculty faculty = new Faculty()
            {
                FirstName = signUp.FirstName,
                LastName = signUp.LastName,
                Email = signUp.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signUp.UserName
            };
            var result = await userManager.CreateAsync(faculty, signUp.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Faculty creation failed! Please check user details and try again." });

            
            if (!await roleManager.RoleExistsAsync(UserRoles.Faculty))  
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Faculty));  
  
            if (await roleManager.RoleExistsAsync(UserRoles.Faculty))  
            {  
                await userManager.AddToRoleAsync(faculty, UserRoles.Faculty);  
            }
            return Ok(new Response { Status = "Success", Message = "Faculty created successfully!" });
        }

        [HttpPost]
        [Authorize(Roles =UserRoles.Admin)]
        public async Task<IActionResult> RegisterStudent([FromBody] SignUp signUp)
        {
            var userExists = await userManager.FindByNameAsync(signUp.UserName);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student already exists!" });

            Student student = new Student()
            {
                FirstName =signUp.FirstName,
                LastName =signUp.LastName,
                Email = signUp.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = signUp.UserName
            };
            var result = await userManager.CreateAsync(student, signUp.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Student creation failed! Please check user details and try again." });


            if (!await roleManager.RoleExistsAsync(UserRoles.Student))
                await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));

            if (await roleManager.RoleExistsAsync(UserRoles.Student))
            {
                await userManager.AddToRoleAsync(student, UserRoles.Student);
            }
            return Ok(new Response { Status = "Success", Message = "Student created successfully!" });
        }
    }
}
