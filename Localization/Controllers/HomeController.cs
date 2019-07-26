using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Localization.Models;
using Microsoft.Extensions.Localization;
using Newtonsoft.Json;

namespace Localization.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            List<dynamic> localizedDatas = new List<dynamic>();
            List<string> menuNames = new List<string>() { "billing", "wood bill" };

            foreach (var menuName in menuNames)
            {
                localizedDatas.Add(new
                {
                    menuName,
                    localizedValue = _localizer[menuName.ToLower().Trim()].Value
                });
            }

            return Content(JsonConvert.SerializeObject(localizedDatas));
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

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
