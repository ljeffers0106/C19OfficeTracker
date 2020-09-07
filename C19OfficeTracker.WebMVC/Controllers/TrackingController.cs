using C19OfficeTracker.Data;
using C19OfficeTracker.Models;
using C19OfficeTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace C19OfficeTracker.WebMVC.Controllers
{
    public class TrackingController : Controller
    {
        [Authorize]
        // GET: Tracking
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrackingService(userId);
            var model = service.GetTrackings();

            return View(model);
        }
        // Add method
        // Get
        public ActionResult Create()
        {
            List<Employee> Employees = CreateEmployeeService().GetEmployeeData().ToList();
            ViewBag.EmpId = Employees.Select(o => new SelectListItem()
            {
                Value = o.EmpId.ToString(),
                Text = o.FullName,
            });
            var model = new TrackingCreate()
            {
                TrackDate = DateTime.Now
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrackingCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateTrackingService();

            if (service.CreateTracking(model))
            {
                if (model.Temperature >= 100.4)
                {
                    TempData["SaveResult2"] = "DO NOT REPORT TO WORK - Contact YOUR Manager - Temperature >= 100.4";
                    return RedirectToAction("Index");
                }
                if (model.SymptomAnswer == "Yes")
                {
                    TempData["SaveResult2"] = "DO NOT REPORT TO WORK - Contact YOUR Manager - Need tested for COVID-19";
                    return RedirectToAction("Index");
                }
                if (model.ContactAnswer == "Yes")
                {
                    TempData["SaveResult2"] = "DO NOT REPORT TO WORK - Contact YOUR Manager - Need to be put in Quarantine";
                    return RedirectToAction("Index");
                }
                if (model.TempAnswer == "No")
                {
                    TempData["SaveResult2"] = "DO NOT REPORT TO WORK - Contact YOUR Manager - Must take your Temperature within 90 mins";
                    return RedirectToAction("Index");
                }
                TempData["SaveResult1"] = "You have been APPROVED to work today!";
                    return RedirectToAction("Index");
            };

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateTrackingService();
            var model = svc.GetTrackingById(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateTrackingService();
            var detail = service.GetTrackingById(id);
            var model =
                new TrackingEdit
                {
                    TrackingId = detail.TrackingId,
                    TrackDate = detail.TrackDate,
                    SymptomAnswer = detail.SymptomAnswer,
                    ContactAnswer = detail.ContactAnswer,
                    TempAnswer = detail.TempAnswer,
                    Temperature = detail.Temperature,
                    MaskAnswer = detail.MaskAnswer,
                    GroupAnswer = detail.GroupAnswer,
                    EmpId = detail.EmpId,
                    FullName = detail.FullName
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TrackingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.TrackingId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateTrackingService();

            if (service.UpdateTracking(model))
            {
                    TempData["SaveResult1"] = "The tracking date was updated.";
                    return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The tracking date could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateTrackingService();
            var model = svc.GetTrackingById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateTrackingService();

            service.DeleteTracking(id);

            TempData["SaveResult3"] = "Your Tracking for date was deleted";

            return RedirectToAction("Index");
        }
        // GET: Tracking
        public ActionResult FollowUp()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrackingService(userId);
            var model = service.GetTrackingQuestions();

            return View(model);
        }
        
        private TrackingService CreateTrackingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrackingService(userId);
            return service;
        }
        private EmployeeService CreateEmployeeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new EmployeeService(userId);
            return service;
        }

    }
}