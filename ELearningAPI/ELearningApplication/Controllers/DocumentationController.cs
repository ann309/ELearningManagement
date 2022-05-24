using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELearningApplication.Controllers
{
    public class DocumentationController : Controller
    {
        // GET: DocumentationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DocumentationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DocumentationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DocumentationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DocumentationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DocumentationController/Edit/5
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

        // GET: DocumentationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DocumentationController/Delete/5
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
