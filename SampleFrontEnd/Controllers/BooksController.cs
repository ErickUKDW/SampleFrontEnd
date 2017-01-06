using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SampleFrontEnd.Models;
using SampleFrontEnd.DAL;

namespace SampleFrontEnd.Controllers
{
    public class BooksController : Controller
    {
        public JsonResult GetAllByCategory(string CategoryId)
        {
            BooksDAL bookDAL = new BooksDAL();
            return Json(bookDAL.GetAllByCategory(CategoryId), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Delete(string CategoryId)
        {
            BooksDAL bookDAL = new BooksDAL();
            bookDAL.DeleteBooksByCategory(CategoryId);
            var result = new { Success = "true", Message = "Berhasil mendelete data" };
            return Json(result);
        }

        [HttpPost]
        public JsonResult Create(IEnumerable<Book> listBook)
        {
            BooksDAL bookDAL = new BooksDAL();
            foreach(var book in listBook)
            {
                bookDAL.Insert(book);
            }
            var result = new { Success = "true", Message = "Berhasil menambah data" };
            return Json(result);
        }

        public ActionResult SampleMasterDetail()
        {
            return View();
        }



        // GET: Books
        public ActionResult Index()
        {
            return View();
        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

      
    }
}
