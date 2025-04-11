using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ModelsInASPCore.Models;
using ModelsInASPCore.Repository;

namespace ModelsInASPCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly StudentRepository _studentRepository = null;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _studentRepository = new StudentRepository();
        }

        public List<StudentModel> getAllStudents()
        {
            return _studentRepository.getAllStudents();
        }

        public StudentModel getStudentById(int id)
        {
            return _studentRepository.getStudentById(id);
        }
        public IActionResult Index()
        {
            //var students = new List<StudentModel>
            //{
            //    new StudentModel { Rollno = 1, Name = "Satyam", Gender="Male", Standard = 12},
            //    new StudentModel { Rollno = 2, Name = "Raj", Gender="Male", Standard = 1},
            //    new StudentModel { Rollno = 3, Name = "Pratibha", Gender="Female", Standard = 5}
            //}; 

            //paas data to view
            //ViewBag.MyStudents = students;
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
    }
}
