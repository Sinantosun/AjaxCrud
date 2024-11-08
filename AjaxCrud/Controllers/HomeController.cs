using AjaxCrud.Dal.Context;
using AjaxCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AjaxCrud.Dal.Entities;


namespace AjaxCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoListContext _context;

        public HomeController(ToDoListContext context)
        {

            _context = context;
        }

        public IActionResult Index()
        {

            return View();
        }
        public JsonResult List()
        {
            var values = _context.Processes.OrderBy(t => t.IsComplated).ToList();

            return Json(values);
        }
        public JsonResult Add(string note)
        {
            _context.Processes.Add(new Process
            {
                Note = note,
                Date = DateTime.Now,
                IsComplated = false,

            });
            var value = _context.SaveChanges();
            if (value > 0)
            {
                return Json("success");
            }
            return Json("err");
        }


        public JsonResult Delete(int id)
        {
            var value = _context.Processes.Find(id);
            _context.Processes.Remove(value);
            var result = _context.SaveChanges();
            if (result > 0)
            {
                return Json("success");
            }
            return Json("err");
        }

        public JsonResult Update(int id, string note)
        {
            var value = _context.Processes.Find(id);
            value.Note = note;
            _context.SaveChanges();
            return Json("success");
        }
        public JsonResult StatusChange(int id)
        {
            var value = _context.Processes.Find(id);
            value.IsComplated = true;
            _context.SaveChanges();
            return Json("success");
        }

    }
}
