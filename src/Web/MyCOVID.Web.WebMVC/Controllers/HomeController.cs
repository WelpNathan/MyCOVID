using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyCOVID.Web.WebMVC.Models;
using MyCOVID.Web.WebMVC.Services;

namespace MyCOVID.Web.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICaseFetcher _client;

        public HomeController(ILogger<HomeController> logger, ICaseFetcher client)
        {
            _logger = logger;
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
           
            var blocks = await _client.GetCasesAsync();
            ViewBag.Blocks = blocks;
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}