using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Visma.Fagsamling.Domain.Interfaces;
using Visma.Fagsamling.Web.Models;

namespace Visma.Fagsamling.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStationLogic _client;

        public HomeController(IStationLogic client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> ExampleCode()
        {
            var stations = await _client.GetBikeStation();
            ViewData["Stations"] = stations;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
