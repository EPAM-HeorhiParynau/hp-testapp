﻿using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using HpTestApp.Models;

using Infrastructure.Repositories;

namespace HpTestApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
	        throw null;
	        var x = new SimpleTextRepository().GetTextValue(12);
	        var y = new SimpleTextRepository().Get(11);

			return View(new AboutViewModel { Text = x.Value + " + DB project source!!! " + "Git source: " + y.Text });
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
