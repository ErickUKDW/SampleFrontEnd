using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SampleFrontEnd.Models;
using SampleFrontEnd.DAL;

namespace SampleFrontEnd.Controllers
{
    //contoh pengunaan ajax beginform untuk searching
    public class CategoriesController : Controller
    {
        // GET: Categories
        //contoh penggunaan modal form untuk cari dan pilih data
        public ActionResult Index(string categoryname)
        {
            CategoryDAL categoryDal = new CategoryDAL();
            var models = categoryDal.GetAll();

            if (Request.IsAjaxRequest())
            {
                models = categoryDal.GetAllByName(categoryname);
                return PartialView("_PartialCategoryResult", models);
            }

            return View(models);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
