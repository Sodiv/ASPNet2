using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;

namespace WebStore.Infrastuctures.Interfaces
{
    public interface IEmployeesData
    {
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeView> GetAll();
        EmployeeView GetById(int id);
        void AddNew(EmployeeView model);
        void Delete(int id);
    }
}
