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
    public class DepartmentController : Controller
    {
        [Authorize]
        // GET: Departments
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DepartmentService(userId);
            var model = service.GetDepartments();

            return View(model);
        }
        // Add method
        // Get
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DepartmentCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateDepartmentService();

            if (service.CreateDepartment(model))
            {
                TempData["SaveResult"] = "Your Department was created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateDepartmentService();
            var model = svc.GetDepartmentById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateDepartmentService();
            var detail = service.GetDepartmentById(id);
            var model =
                new DepartmentEdit
                {
                    DeptId = detail.DeptId,
                    DeptName = detail.DeptName,
                    Building = detail.Building,
                    Location = detail.Location,
                    Room = detail.Room
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DepartmentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.DeptId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateDepartmentService();

            if (service.UpdateDepartment(model))
            {
                TempData["SaveResult"] = "The department was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The department could not be updated.");
            return View(model);
        }
        private DepartmentService CreateDepartmentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DepartmentService(userId);
            return service;
        }

    }
}