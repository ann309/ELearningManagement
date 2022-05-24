using ELearning.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using ELearningApplication.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ELearningApplication.Controllers
{
    //[Authorize]
    public class ProjectController : Controller
    {
        ELearningApi _api = new ELearningApi();
        
        public IActionResult Index()
        {
            try
            {
                List<ELearning.DAL.Models.Project> projectList = new List<ELearning.DAL.Models.Project>();
                HttpClient client = _api.Initial();
                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress = new Uri(baseUrl);
                //    client.DefaultRequestHeaders.Clear();
                //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                if (HomeController.token!=null)
                {
                    var identity = User.Identity as ClaimsIdentity;
                    if (identity != null)
                    {
                        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);

                        var response = client.GetAsync("Project/Display");
                        response.Wait();
                        var result = response.Result;
                        if (result.IsSuccessStatusCode)
                        {
                            var Result = result.Content.ReadAsStringAsync().Result;
                            projectList = JsonConvert.DeserializeObject<List<Project>>(Result);
                        }
                        
                        return View(projectList);
                    }
                    return View();
                }
                else return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

      

        public IActionResult Create()
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
