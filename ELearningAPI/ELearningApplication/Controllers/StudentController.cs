using ELearning.DAL.Models;
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
    //[Authorize(Roles =UserRoles.Student)]
    public class StudentController : Controller
    {
        ELearningApi _api = new ELearningApi();

        // GET: Student dashboard
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: StudentController/Edit/5
        //public async Task<ActionResult> Edit(string id)
        //{
           
        //    Student studentVal = new Student();
        //    HttpClient client = _api.Initial();
        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
           
        //    var response = await client.GetAsync("Student/GetIdAsync?id=" + id);
        //    response.Wait();
        //    var result = response.Result;
        //    if (result.IsSuccessStatusCode)
        //    {
        //        var Result = response.Content.ReadAsStringAsync().Result;
        //        studentVal = JsonConvert.DeserializeObject<Student>(Result);
                
        //    }

        //    return View(studentVal);
          
        //}

        // POST: StudentController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, Student student)
        {
            Student studentVal = new Student();
            try
            {
                HttpClient client = _api.Initial();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
                string data = JsonConvert.SerializeObject(student);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync("Student/Edit?id={id}" , content);
                //response.Wait();
                //var result = response.Result;
                if (response.IsSuccessStatusCode)
                {
                   // var Result = response.Content.ReadAsStringAsync().Result;
                    //studentVal = JsonConvert.DeserializeObject<Student>(Result);
                    return RedirectToAction("Index");
                }

                return View(studentVal);
            }
            catch
            {
                return View();
            }
        }

        public IActionResult MyChats()
        {
            List<ELearning.DAL.Models.Chat> chatList = new List<ELearning.DAL.Models.Chat>();
            HttpClient client = _api.Initial();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", HomeController.token);
            var response = client.GetAsync("Chat/MyChats");
            response.Wait();
            var result = response.Result;
            if (result.IsSuccessStatusCode)
            {
                var Result = result.Content.ReadAsStringAsync().Result;
                chatList = JsonConvert.DeserializeObject<List<Chat>>(Result);
            }

            return View(chatList);

        }
    }
}
