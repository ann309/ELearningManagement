using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningApplication.Controllers
{
    public class CalenderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
