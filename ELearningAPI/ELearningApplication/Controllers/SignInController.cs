//using ELearning.DAL.Models;
//using ELearning.Models;
//using ELearningApplication.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace ELearningApplication.Controllers
//{
//    public class SignInController : Controller
//    {
//        public static string token = "";
//        string baseUrl = "https://localhost:44378/api/";
       

       
//        // GET: AccountController
//        public ActionResult LogIn()
//        {
//            return View();
//        }

//        // GET: AccountController/Details/5
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult LogIn(LogIn logIn)
//        {
//            try
//            {
//                // tokenBased = String.Empty;
//                using (var client = new HttpClient())
//                {
//                    string data = JsonConvert.SerializeObject(logIn);
//                    using StringContent content = new(data, Encoding.UTF8, "application/json");
//                    var postTask = client.PostAsync($"https://localhost:44378/api/Authentication/Login/",content);
//                    postTask.Wait();
//                    var result = postTask.Result;
//                    var a = result.StatusCode;
//                    if (result.IsSuccessStatusCode)
//                    {
//                        SignInController.token = result.Content.ReadAsStringAsync().Result;
//                        return RedirectToAction("Index", "Home");
//                    }
//                }
//                //ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
//                //return View();
//                return RedirectToAction("Index", "Home");
//            }
//            catch
//            {
//                return View();
//            }


//    }
//}