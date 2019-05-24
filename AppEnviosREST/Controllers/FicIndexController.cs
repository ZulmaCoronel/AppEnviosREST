using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AppEnviosREST.Controllers
{
    public class FicIndexController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}