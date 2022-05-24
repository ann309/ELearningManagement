using ELearning.DAL;
using ELearning.DAL.Models;
using ELearningApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ELearningApplication.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        //private readonly ELearningDBContext _db;
        public static string token = "";
        bool isAuthenticated;
        public static string role;
        //private readonly UserManager<UserInformation> _userManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
           // _userManager = userManager;
        }


        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowArticles()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogInStudent()
        {
            return View();
        }

        // GET: AccountController/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogInStudent(LogIn logIn)
        {
            try
            {
                // tokenBased = String.Empty;
                using (var client = new HttpClient())
                {
                    string data = JsonConvert.SerializeObject(logIn);
                    using StringContent content = new(data, Encoding.UTF8, "application/json");
                    var postTask = client.PostAsync($"https://localhost:44378/api/Authentication/LoginStudent/", content);
                    postTask.Wait();
                    var result = postTask.Result;
                    var response = result.StatusCode;
                    
                    if (result.IsSuccessStatusCode)
                    {
                        //var re =if (result.Content.ReadAsStringAsync().Result.Contains(role)) { }
                        HomeController.token = result.Content.ReadAsStringAsync().Result;
                        HttpContext.Session.SetString("JWToken", HomeController.token);
                        // HomeController.token.Contains(
                        //if (HomeController.token.Contains(role)) { HomeController.role=HomeController.token.role}

                        //isAuthenticated=User.Identity.IsAuthenticated;
                        //ViewData.Add(isAuthenticated,true);
                        return RedirectToAction("Index", "Student");
                    }
                }
                //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View();
                //return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult LogInFaculty()
        {
            return View();
        }

        // GET: AccountController/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogInFaculty(LogIn logIn)
        {
            try
            {
                
                using (var client = new HttpClient())
                {
                    string data = JsonConvert.SerializeObject(logIn);
                    using StringContent content = new(data, Encoding.UTF8, "application/json");
                    var postTask = client.PostAsync($"https://localhost:44378/api/Authentication/LoginFaculty/", content);
                    postTask.Wait();
                    var result = postTask.Result;
                    var response = result.StatusCode;

                    if (result.IsSuccessStatusCode)
                    {
                        
                        HomeController.token = result.Content.ReadAsStringAsync().Result;
                       
                        return RedirectToAction("Index", "Faculty");
                    }
                }
                
                return View();
                
            }
            catch
            {
                return View();
            }
        }

        [AllowAnonymous]
        public ActionResult LogInAdmin()
        {
            return View();
        }

        // GET: AccountController/Details/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogInAdmin(LogIn logIn)
        {
            try
            {
                
                using (var client = new HttpClient())
                {
                    string data = JsonConvert.SerializeObject(logIn);
                    using StringContent content = new(data, Encoding.UTF8, "application/json");
                    var postTask = client.PostAsync($"https://localhost:44378/api/Authentication/LoginAdmin/", content);
                    postTask.Wait();
                    var result = postTask.Result;
                    var response = result.StatusCode;

                    if (result.IsSuccessStatusCode)
                    {
                       
                        HomeController.token = result.Content.ReadAsStringAsync().Result;
                     
                        return RedirectToAction("Index", "User");
                    }
                }
               
                return View();
                
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
