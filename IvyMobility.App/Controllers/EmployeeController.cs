using ShoppingCart.Interface;
using ShoppingCart.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IvyMobility.App.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;
        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }
        // GET: Employee
        public async Task<ActionResult> Index()
        {
            List<EmployeeModel> employees = await _employeeService.GetAllEmployee();
            return View(employees??new List<EmployeeModel>());
        }

        // GET: Employee/Details/5
        public async Task<ActionResult> Details(int id)
        {
            EmployeeModel employee = await _employeeService.GetEmployeeById(id);
            return View(employee??new EmployeeModel());
        }

        // GET: Employee/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public async Task<ActionResult> Create(EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool flag = await _employeeService.AddOrUpdateEmployee(employee);
                    if (flag)
                        return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Employee/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            EmployeeModel employee = await _employeeService.GetEmployeeById(id);
            return View(employee ?? new EmployeeModel());
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, EmployeeModel employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool flag = await _employeeService.AddOrUpdateEmployee(employee);
                    if (flag)
                        return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        // GET: Employee/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            EmployeeModel employee = await _employeeService.GetEmployeeById(id);
            return View(employee ?? new EmployeeModel());
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, EmployeeModel employeeDetail)
        {
            try
            {
                
                    EmployeeModel employee = await _employeeService.GetEmployeeById(id);
                    if (employee != null)
                    {
                        bool flag = await _employeeService.DeleteEmployee(employee);
                        if (flag)
                            return RedirectToAction("Index");
                    }
                }

            catch
            {
                return View();
            }
            return View();
        }
    }
}
