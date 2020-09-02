using C19OfficeTracker.Data;
using C19OfficeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Services
{
    public class BuildingService
    {
        public bool CreateBuilding(BuildingCreate model)
        {
            var entity =
                new Building()
                {
                    BuildingName = model.BuildingName,
                    Address = model.Address,
                    City = model.City,
                    State = model.State,
                    Postal = model.Postal
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Buildings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<BuildingListItem> GetBuildings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Buildings
                        .Where(e => e.BuildingName != null)
                        .OrderBy(e => e.BuildingName)
                        .Select(
                            e =>
                                new BuildingListItem
                                {
                                    BuildingId = e.BuildingId,
                                    BuildingName = e.BuildingName,
                                    Address = e.Address,
                                    City = e.City,
                                    State = e.State
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<Building> GetBuildingsData()
        {
            using (var ctx = new ApplicationDbContext())
            {

                return (ctx.Buildings.ToList());
            }
        }
        public BuildingDetail GetBuildingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Buildings
                        .Single(e => e.BuildingId == id);

                return
                    new BuildingDetail
                    {
                        BuildingId = entity.BuildingId,
                        BuildingName = entity.BuildingName,
                        Address = entity.Address,
                        City = entity.City,
                        State = entity.State,
                        Postal = entity.Postal,
                        Departments = ctx.Departments.Where(d => d.BuildingId == entity.BuildingId).ToList()
                    };
            }
        }
        public bool UpdateBuilding(BuildingEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Buildings
                        .Single(e => e.BuildingId == model.BuildingId);
                entity.BuildingId = model.BuildingId;
                entity.BuildingName = model.BuildingName;
                entity.Address = model.Address;
                entity.City = model.City;
                entity.State = model.State;
                entity.Postal = model.Postal;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteBuilding(int buildingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Buildings
                        .Single(e => e.BuildingId == buildingId);

                ctx.Buildings.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
