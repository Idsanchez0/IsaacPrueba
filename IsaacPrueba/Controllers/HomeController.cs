using IsaacPrueba.Models;
using IsaacPrueba.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IsaacPrueba.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        private readonly Repository _repo;

        public HomeController(ILogger<HomeController> logger, Repository repository)
        {
            _logger = logger;

            _repo = repository;
        }

        public IActionResult Index()
        {

            try
            {
                var employee = _repo.GetIngresoAportables();

                return View(employee);
            }
            catch (Exception ex)
            {
                return View();
            }

          

            
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
