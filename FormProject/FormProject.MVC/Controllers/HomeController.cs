﻿using FormProject.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormProject.MVC.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

    }
}