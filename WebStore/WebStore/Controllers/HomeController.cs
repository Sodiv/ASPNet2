﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Interfaces.Clients;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IValueService _valueService;

        public HomeController(IValueService valueService)
        {
            _valueService = valueService;
        }

        public async Task<IActionResult> Index()
        {
            //throw new InvalidOperationException("Новая ошибка!");
            var values = await _valueService.GetAsync();
            return View(values);
        }
        
        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogSingle()
        {
            return View();
        }

        public IActionResult ErrorStatus(string id)
        {
            if (id == "404")
                return RedirectToAction("NotFound");
            return Content($"Статусный код ошибки: {id}");
        }

        public IActionResult NotFound()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }
    }
}