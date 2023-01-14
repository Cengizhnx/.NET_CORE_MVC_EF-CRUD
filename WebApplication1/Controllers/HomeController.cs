using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.DBContext;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductDBContext productsDBContext;

        public HomeController(ILogger<HomeController> logger, ProductDBContext productsDBContext)
        {

            _logger = logger;
            this.productsDBContext = productsDBContext;
        }

        public IActionResult Index()
        {
            //var products = productsDBContext.Product.ToList();
            //return View(products);
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