using C19OfficeTracker.Data;
using C19OfficeTracker.Models;
using C19OfficeTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace C19OfficeTracker.WebMVC.Controllers
{
    public class EmployeeController : Controller
    {
        [Authorize]
        // GET: Employee
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            var model = service.GetEmployees();

            return View(model);
        }
        // Add method
        // Get
        
        public ActionResult Create()
        {
            List<Department> Departments = CreateDepartmentService().GetDepartmentsData().ToList();
            ViewBag.DeptId = Departments.Select(o => new SelectListItem()
            {
                Value = o.DeptId.ToString(),
                Text = o.DeptName,
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeCreate model)
        {

            if (!ModelState.IsValid) return View(model);

            var service = CreateEmployeeService();

            if (service.CreateEmployee(model))
            {
                TempData["SaveResult"] = "Your employee was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateEmployeeService();
            var model = svc.GetEmployeeById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateEmployeeService();
            var detail = service.GetEmployeeById(id);
            List<Department> Departments = CreateDepartmentService().GetDepartmentsData().ToList();
            ViewBag.DeptId = Departments.Select(o => new SelectListItem()
            {
                Value = o.DeptId.ToString(),
                Text = o.DeptName,
                Selected = o.DeptId == detail.DeptId
            });
            var model =
                new EmployeeEdit
                {
                    EmpId = detail.EmpId,
                    FullName = detail.FullName,
                    Phone = detail.Phone,
                    Email = detail.Email,
                    Gender = detail.Gender,
                    TypeOfPosition = detail.TypeOfPosition,
                    DeptId = detail.DeptId
                };
       
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EmployeeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.EmpId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateEmployeeService();

            if (service.UpdateEmployee(model))
            {
                TempData["SaveResult"] = "The employee was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The employee could not be updated.");
            return View(model);
        }
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }

        private DepartmentService CreateDepartmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DepartmentService(userId);
            return service;
        }
    }
}