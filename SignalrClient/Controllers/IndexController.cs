using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SignalrClient.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult UsesOnline()
        {
            return View();
        }

        public IActionResult AnyOne()
        {
            return View();
        }

        public IActionResult EveryOne()
        {
            return View();
        }

        public IActionResult AnyGroups()
        {
            return View();
        }

        public IActionResult MoreParamsRequest()
        {
            return View();
        }
    }
}