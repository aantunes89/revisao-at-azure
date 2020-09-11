using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class FabricanteController : Controller
    {
        // GET: FabricanteController
        public ActionResult Index()
        {
            return View();
        }

        // GET: FabricanteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FabricanteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabricanteController/Create
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

        // GET: FabricanteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FabricanteController/Edit/5
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

        // GET: FabricanteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FabricanteController/Delete/5
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
