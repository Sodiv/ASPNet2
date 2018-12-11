using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastuctures.Interfaces;
using WebStore.Models;

namespace WebStore.ServiceHosting.Controllers
{
    [Produces("application/json")]
    [Route("api/employees")]
    public class EmployeesApiController : Controller, IEmployeesData
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesApiController(IEmployeesData employeesData)
        {
            _employeesData = employeesData ?? throw new ArgumentNullException(nameof(employeesData));
        }

        [HttpPost, ActionName("Post")]
        public void AddNew([FromBody]EmployeeView model)
        {
            _employeesData.AddNew(model);
        }

        [NonAction]
        public void Commit()
        {
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _employeesData.Delete(id);
        }

        [HttpGet, ActionName("Get")]
        public IEnumerable<EmployeeView> GetAll()
        {
            return _employeesData.GetAll();
        }

        [HttpGet("{id}"), ActionName("Get")]
        public EmployeeView GetById(int id)
        {
            return _employeesData.GetById(id);
        }

        [HttpPut("{id}"), ActionName("Put")]
        public EmployeeView UpdateEmployee(int id, EmployeeView entity)
        {
            return _employeesData.UpdateEmployee(id, entity);
        }
    }
}