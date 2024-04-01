using EnvVariables.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnvVariables.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            try
            {
                var conn = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");

                if (string.IsNullOrEmpty(conn))
                {
                    throw new InvalidOperationException("A variável de ambiente DATABASE_CONNECTION_STRING não está definida.");
                }
                else
                {
                    _logger.LogInformation(conn + " Controller");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Test");
            }
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
