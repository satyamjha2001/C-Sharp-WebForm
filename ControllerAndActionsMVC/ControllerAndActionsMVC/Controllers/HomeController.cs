using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ControllerAndActionsMVC.Models;

namespace ControllerAndActionsMVC.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
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
