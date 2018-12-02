using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastuctures.Interfaces;
using static WebStore.Domain.WebStoreContants;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("admin"), Authorize(Roles="Administrator")]
    public class HomeController : Controller
    {
        private readonly IProductData _productData;

        public HomeController(IProductData productData)
        {
            _productData = productData;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var products = _productData.GetProducts(new Domain.Entities.ProductFilter());
            return View(products);
        }
    }
}