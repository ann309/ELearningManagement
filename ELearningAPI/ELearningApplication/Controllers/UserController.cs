using ELearning.DAL.Models;
using ELearning.Models;
using ELearningApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ELearningApplication.Controllers
{
    
    public class UserController : Controller
    {
        ELearningApi _api = new ELearningApi();
        string baseUrl = "https://localhost:44378/";
        public ActionResult Index()
        {
            return View();
        }
        // GET: UserController
        public ActionResult Display()
        {
            return View();
        }


        [Authorize(UserRoles.Admin)]
        public IActionResult RegisterFaculty()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterFaculty(SignUp signUp/*IFormCollection collection*/)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string data = JsonConvert.SerializeObject(signUp);
                    using StringContent content = new(data, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var postTask = client.PostAsync($"https://localhost:44378/api/Authentication/RegisterFaculty/", content);
                    postTask.Wait();
                    var result = postTask.Result;
                    var a = result.StatusCode;
                    if (result.IsSuccessStatusCode)
                    {
                        HomeController.token = result.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View();
               
            }
            catch
            {
                return View();
            }
        }

        [Authorize(UserRoles.Admin)]
        public IActionResult RegisterAdmin()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterAdmin(SignUp signUp/*IFormCollection collection*/)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string data = JsonConvert.SerializeObject(signUp);
                    using StringContent content = new(data, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var postTask = client.PostAsync($"https://localhost:44378/api/Authentication/RegisterAdmin/", content);
                    postTask.Wait();
                    var result = postTask.Result;
                    var a = result.StatusCode;
                    if (result.IsSuccessStatusCode)
                    {
                        HomeController.token = result.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View();

            }
            catch
            {
                return View();
            }
        }

        [Authorize(UserRoles.Admin)]
        public IActionResult RegisterStudent()
        {

            return View();
        }
        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterStudent(SignUp signUp/*IFormCollection collection*/)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    string data = JsonConvert.SerializeObject(signUp);
                    using StringContent content = new(data, Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                    var postTask = client.PostAsync($"https://localhost:44378/api/Authentication/RegisterStudent/", content);
                    postTask.Wait();
                    var result = postTask.Result;
                    var a = result.StatusCode;
                    if (result.IsSuccessStatusCode)
                    {
                        HomeController.token = result.Content.ReadAsStringAsync().Result;
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
                return View();
                //List<ELearning.DAL.Models.Project> projectList = new List<ELearning.DAL.Models.Project>();
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri(baseUrl);
                //    client.DefaultRequestHeaders.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                //    client.DefaultRequestHeaders.Authorization
                //        = new AuthenticationHeaderValue(scheme: "Bearer", SignInController.token);
                //    var response = client.PostAsJsonAsync(baseUrl + "api/Account/Register", signUp);
                //    response.Wait();
                //    var result = response.Result;
                //    if (result.IsSuccessStatusCode)
                //    {
                //        //ViewBag.Message = "Submitted Successfully";
                //        //ModelState.Clear();
                //        return RedirectToAction("Display");
                //    }
                //    else
                //    {
                //        //ViewBag.Message = "Operation unsuccessfull";
                //        return BadRequest("Operation unsuccessfull");
                //    }
                //}

                //return View();
               // return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string id)
        {
            return View(id);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, UserInformation user)
        {
            UserInformation userVal = new UserInformation();
            try
            {
                HttpClient client = _api.Initial();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                string data = JsonConvert.SerializeObject(user);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response =await client.PutAsync("User/Edit?id=" + id,content);
                //response.Wait();
                //var result = response.Result;
                if (response.IsSuccessStatusCode)
                {
                    var Result = response.Content.ReadAsStringAsync().Result;
                    userVal = JsonConvert.DeserializeObject<UserInformation>(Result);
                    return RedirectToAction("Index");
                }

                return View(userVal);
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserInformation user)
        {
            try
            {

                return RedirectToAction(nameof(Display));
            }
            catch
            {
                return View();
            }
        }
    }
}
