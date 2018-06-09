using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Controllers
{
    public class HomeController : Controller
    {
        private hospitalContext db = new hospitalContext();

        public IActionResult Index()
        {
            return View();
        }
    }
}
