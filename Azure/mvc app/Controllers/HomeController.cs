using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvc_app.Models;

namespace mvc_app.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IConfiguration config

    public HomeController(ILogger<HomeController> logger,IConfiguration config)
    {
        _logger = logger;
        this.config=config
    }

    public IActionResult Index()
    {
        string connstring = this.config.GetConnectionString("sqlconnection");
        ViewBag.ConnectionString = connstring;
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
