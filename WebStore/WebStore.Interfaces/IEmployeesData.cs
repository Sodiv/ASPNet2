using System.Collections.Generic;
using WebStore.Domain.ViewModel;

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
        EmployeeView UpdateEmployee(int id, EmployeeView entity);
        void AddNew(EmployeeView model);
        void Delete(int id);
        void Commit();
    }
}
