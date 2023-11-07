using BindDropDownListWithDatabase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace BindDropDownListWithDatabase.Controllers
{
    public class HomeController : Controller
    {
        private readonly ado_dbContext context;

        public HomeController(ado_dbContext context)
        {
            this.context = context;
        }

        private StudentModel BindDDL() 
        {
            StudentModel student = new StudentModel();
            student.StudentsList = new List<SelectListItem>();
            var data = context.Students.ToList();
            foreach (var item in data)
            {
                student.StudentsList.Add(new SelectListItem
                {
                    Text = item.StdName,
                    Value = item.StdId.ToString()
                });
            }
            return student;
        }


        public IActionResult Index()
        {
            var std = BindDDL();
            return View(std);
        }

        [HttpPost]
        public IActionResult Index(StudentModel std)
        {
            var student = context.Students.Where(x => x.StdId == std.Id).FirstOrDefault();
            if (student != null)
            {
                ViewBag.selectedvalue = student.StdName;
            }
            var myStudent = BindDDL();
            return View(myStudent);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}