using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using shoppApp.Models;
using ShoppApp.Data;
using ShoppApp.Models;

namespace ShoppApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        int saat=DateTime.Now.Hour;

            // string Mesaj= saat>12?"iyi günler":"Günaydın";

            ViewBag.Greeting=saat>12 ? "İyi Günler":"Günaydın";
           ViewBag.UserName="Cengiz";

           var productViewModel=new ProductViewModel{
                Products=ProductRepository.Products
           };
        return View(productViewModel);
    }

    public IActionResult About(){
        return View();
    }
    public IActionResult Contact(){
        return View("MyView");
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
