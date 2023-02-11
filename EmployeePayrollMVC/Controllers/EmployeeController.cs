using BusinessLayer.Services;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.Services;
using System.Collections.Generic;
using System.Linq;

namespace EmployeePayrollMVC.Controllers
{
    public class EmployeeController : Controller
    {
        IUserBL userBL;
        public EmployeeController(IUserBL userBL)
        {
            this.userBL = userBL;
        }


        [HttpGet]
        public IActionResult Index()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();
            lstemployee = userBL.GetAllEmployees().ToList();
            return View(lstemployee);
        }
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            List<EmployeeModel> lstemployee = new List<EmployeeModel>();
            lstemployee = userBL.GetAllEmployees().ToList();
            return View(lstemployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                userBL.addEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }

        //edit or update
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = userBL.GetEmployeeById(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EmployeeModel employeeModel)
        {
            if (id != employeeModel.Emp_id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                userBL.UpdateEmployee(employeeModel);
                return RedirectToAction("Index");
            }
            return View(employeeModel);
        }

        //Detail view or GetEmployeeByID
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = userBL.GetEmployeeById(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        //Delete view or delete employee by id

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            EmployeeModel employeeModel = userBL.GetEmployeeById(id);

            if (employeeModel == null)
            {
                return NotFound();
            }
            return View(employeeModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            userBL.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
