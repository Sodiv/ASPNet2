using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeView> _employees = new List<EmployeeView>
        {
            new EmployeeView
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22,
                Department = "Администрация"
            },
            new EmployeeView
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                Patronymic = "Иванович",
                Age = 35,
                Department = "Администрация"
            },
            new EmployeeView
            {
                Id = 3,
                FirstName = "Василий",
                SurName = "Пупкин",
                Patronymic = "",
                Age = 40,
                Department = "Администрация"
            }
        };

        public IActionResult Index()
        {            
            return View(_employees);
        }

        public IActionResult Details(int id)
        {
            return View((_employees.Where(e => e.Id == id)).Single());
        }
    }
}