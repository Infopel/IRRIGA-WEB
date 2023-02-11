using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace IRRIGA.Controllers
{
    public class DynamicFormsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Forms()
        {
            return View();
        }

        public IActionResult FormProvider()
        {
            return View();
        }

        public IActionResult Fields()
        {
            return View();
        }
    }
}
