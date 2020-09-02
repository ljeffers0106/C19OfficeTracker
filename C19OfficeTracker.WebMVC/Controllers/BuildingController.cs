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
    public class BuildingController : Controller
    {
        [Authorize]
        // GET: Departments
        public ActionResult Index()
        {
            var service = new BuildingService();
            var model = service.GetBuildings();

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
        public ActionResult Create(BuildingCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateBuildingService();

            if (service.CreateBuilding(model))
            {
                TempData["SaveResult"] = "The  Department was successfully created.";
                return RedirectToAction("Index");
            };

            return View(model);
        }
        public ActionResult Details(int id)
        {
          //  List<Department> Departments = CreateDepartmentService().GetDepartmentsData().ToList();
            var svc = CreateBuildingService();
            var model = svc.GetBuildingById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateBuildingService();
            var detail = service.GetBuildingById(id);
            var model =
                new BuildingEdit
                {
                    BuildingId = detail.BuildingId,
                    BuildingName = detail.BuildingName,
                    Address = detail.Address,
                    City = detail.City,
                    State = detail.State,
                    Postal = detail.Postal
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BuildingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.BuildingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateBuildingService();

            if (service.UpdateBuilding(model))
            {
                TempData["SaveResult"] = "The building was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The building could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateBuildingService();
            var model = svc.GetBuildingById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateBuildingService();

            service.DeleteBuilding(id);

            TempData["SaveResult"] = "The Building was successfully deleted";

            return RedirectToAction("Index");
        }
        private BuildingService CreateBuildingService()
        {
            var service = new BuildingService();
            return service;
        }
      
    }
}