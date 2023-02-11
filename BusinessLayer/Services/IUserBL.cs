using ModelLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public interface IUserBL
    {
        public void addEmployee(EmployeeModel employeeModel);
        public void UpdateEmployee(EmployeeModel employeeModel);

        public void DeleteEmployee(int? id);

        public IEnumerable<EmployeeModel> GetAllEmployees();

        public EmployeeModel GetEmployeeById(int? id);
    }
}
