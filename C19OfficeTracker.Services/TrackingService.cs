using C19OfficeTracker.Data;
using C19OfficeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Services
{
    public class TrackingService
    {
        private readonly Guid _userId;

        public TrackingService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateTracking(TrackingCreate model)
        {
            var entity =
                new Tracking()
                {
                    TrackingId = model.TrackingId,
                    TrackDate = DateTime.Now,
                    IndividualId = _userId,
                    SymptomAnswer = model.SymptomAnswer,
                    ContactAnswer = model.ContactAnswer,
                    TempAnswer = model.TempAnswer,
                    Temperature = model.Temperature,
                    MaskAnswer = model.MaskAnswer,
                    GroupAnswer = model.GroupAnswer,
                    EmpId = model.EmpId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Trackings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TrackingListItem> GetTrackings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Trackings
                        // .Where(e => e.IndividualId == _userId)
                        .Where(e => e.TrackDate != null)
                        .OrderBy(e => e.TrackDate)
                        .Select(
                            e =>
                                new TrackingListItem
                                {
                                    EmpId = e.EmpId,
                                    TrackingId = e.TrackingId,
                                    TrackDate = e.TrackDate,
                                    SymptomAnswer = e.SymptomAnswer,
                                    ContactAnswer = e.ContactAnswer,
                                    TempAnswer = e.TempAnswer,
                                    Temperature = e.Temperature,
                                    FullName = e.Employee.FullName
                                }
                        );

                return query.ToArray();
            }
        }
        public TrackingDetail GetTrackingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trackings
                        .Single(e => e.TrackingId == id && e.IndividualId == _userId);

                return
                    new TrackingDetail
                    {
                        EmpId = entity.EmpId,
                        TrackingId = entity.TrackingId,
                        TrackDate = entity.TrackDate,
                        SymptomAnswer = entity.SymptomAnswer,
                        ContactAnswer = entity.ContactAnswer,
                        TempAnswer = entity.TempAnswer,
                        Temperature = entity.Temperature,
                        MaskAnswer = entity.MaskAnswer,
                        GroupAnswer = entity.GroupAnswer,
                        FullName = entity.Employee.FullName
                    };
            }
        }
        public bool UpdateTracking(TrackingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trackings
                        .Single(e => e.TrackingId == model.TrackingId && e.IndividualId == _userId);
                entity.TrackingId = model.TrackingId;
                entity.TrackDate = model.TrackDate;
                entity.SymptomAnswer = model.SymptomAnswer;
                entity.ContactAnswer = model.ContactAnswer;
                entity.TempAnswer = model.TempAnswer;
                entity.Temperature = model.Temperature;
                entity.MaskAnswer = model.MaskAnswer;
                entity.GroupAnswer = model.GroupAnswer;
                entity.EmpId = model.EmpId;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteTracking(int trackingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Trackings
                        .Single(e => e.TrackingId == trackingId && e.IndividualId == _userId);

                ctx.Trackings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

