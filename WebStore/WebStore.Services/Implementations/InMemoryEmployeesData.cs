﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastuctures.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastuctures.Implementations
{
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<EmployeeView> _employees;

        public InMemoryEmployeesData()
        {
            _employees = new List<EmployeeView>
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
        }

        public void AddNew(EmployeeView model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }

        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id.Equals(id));
        }

        public EmployeeView UpdateEmployee(int id, EmployeeView entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));

            var employee = _employees.FirstOrDefault(e => e.Id.Equals(id));
            if (employee == null) throw new InvalidOperationException("Employee not exits");
            employee.Age = entity.Age;
            employee.FirstName = entity.FirstName;
            employee.Patronymic = entity.Patronymic;
            employee.SurName = entity.SurName;
            employee.Department = entity.Department;

            return employee;
        }

        public void Commit()
        {

        }
    }
}
