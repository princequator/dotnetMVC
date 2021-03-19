using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VegamTask.Models;

namespace VegamTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //StudentDAL obj = new StudentDAL();
        private StudentDAL obj;

        //private StudentDetailsdbContext _context { get; }

        public HomeController(StudentDAL Obj, ILogger<HomeController> logger)
        {
            // _context = context;
            obj = Obj;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        [HttpGet]
        [Route("api/Student")]
        public IActionResult GetStudents()
        {
            return View(obj.getAllStudents().ToList());
        }
        [HttpGet]
        [Route("api/StudentMarks")]
        public IActionResult GetStudentsWithMarks(Boolean sortTable = false, Boolean showStatus= false, Boolean addGrace = false)
        {
            ViewBag.showStatus = showStatus;
            return  View(obj.getStudentsWithIndividualSubjectMarks(sortTable, showStatus, addGrace));
        }

        //[HttpGet]
        //[Route("api/StudentStatus")]
        //public IActionResult GetStudentsWithMarksWithStatus()
        //{
        //    return View(obj.getStudentsWithIndividualSubjectMarks());
        //}
    }
}
