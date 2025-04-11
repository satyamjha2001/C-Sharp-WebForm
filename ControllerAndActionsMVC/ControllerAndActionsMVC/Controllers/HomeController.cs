using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControllerAndActionsMVC.Models;

namespace ControllerAndActionsMVC.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        //sending data from controller to view by viewData

        ViewBag.data1 = "Satyam";
        ViewBag.data = 542;
        ViewBag.data3 = DateTime.Now.ToLongDateString();

        ViewData["check"] = "ViewBag and ViewData can use interchangebly";
        ViewBag.check1 = "in home and controller";

        string[] arr = { "Ram", "satyam", "aman" };
        ViewBag.data4 = arr;

        ViewBag.data5 = new List<string>()
        {
            "Hockey", "Cricket", "Football"
        };

        //ViewData["data1"] = "Satyam";
        //ViewData["data2"] = 542;
        //ViewData["data3"] = DateTime.Now.ToLongDateString();

        //string[] arr = { "Ram","satyam","aman" };
        //ViewData["data4"] = arr;

        //ViewData["data5"] = new List<string>()
        //{ 
        //    "Hockey", "Cricket", "Football" 
        //};

        return View();  // by default or home/index
    }

    public IActionResult About()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    public string Display()
    {
        return "Welcome to MVC";  //home/display
    }
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });   //when error occured
    }
}
