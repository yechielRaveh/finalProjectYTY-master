using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace invoiceProject.Controllers
{
    public class HomeController : Controller
    {
        //GET
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        //POST
        //public IActionResult ContactUs()
        //{
        //    return View();
        //}
        public IActionResult AboutUs()
        {
            return View();
        }

    }
}
