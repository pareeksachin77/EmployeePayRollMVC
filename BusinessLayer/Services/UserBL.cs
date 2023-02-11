using ModelLayer.Services;
using RepoLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void addEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.userRL.addEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void UpdateEmployee(EmployeeModel employeeModel)
        {
            try
            {
                this.userRL.UpdateEmployee(employeeModel);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteEmployee(int? id)
        {
            try
            {
                this.userRL.DeleteEmployee(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                return this.userRL.GetAllEmployees();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public EmployeeModel GetEmployeeById(int? id)
        {
            try
            {
                return this.userRL.GetEmployeeById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
