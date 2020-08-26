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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TrackingCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateTrackingService();

            if (service.CreateTracking(model))
            {
                TempData["SaveResult"] = "Your Tracking for today was created.";
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
                    EmpId = detail.EmpId
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
                TempData["SaveResult"] = "The tracking date was updated.";
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

            TempData["SaveResult"] = "Your Tracking for date was deleted";

            return RedirectToAction("Index");
        }
        private TrackingService CreateTrackingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new TrackingService(userId);
            return service;
        }


    }
}