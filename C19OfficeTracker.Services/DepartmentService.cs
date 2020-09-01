using C19OfficeTracker.Data;
using C19OfficeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Services
{
    public class DepartmentService
    {
        //private readonly Guid _userId;

        //public DepartmentService(Guid userId)
        //{
         //   _userId = userId;
        //}
        public bool CreateDepartment(DepartmentCreate model)
        {
            var entity =
                new Department()
                {
                    DeptName = model.DeptName,
                    BuildingId = model.BuildingId,
                    Location = model.Location,
                    Room = model.Room
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Departments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<DepartmentListItem> GetDepartments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Departments
                        .Where(e => e.DeptName != null)
                        .OrderBy(e => e.DeptName)
                        .Select(
                            e =>
                                new DepartmentListItem
                                {
                                    DeptId = e.DeptId,
                                    DeptName = e.DeptName,
                                    BuildingName = e.Building.BuildingName,
                                    Location = e.Location,
                                    Room = e.Room
                                }
                        );

                return query.ToArray();
            }
        }
        public IEnumerable<Department> GetDepartmentsData()
        {
            using (var ctx = new ApplicationDbContext())
            {

                return (ctx.Departments.ToList());
            }
        }
        public DepartmentDetail GetDepartmentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Departments
                        .Single(e => e.DeptId == id);

                return
                    new DepartmentDetail
                    {
                        DeptId = entity.DeptId,
                        DeptName = entity.DeptName,
                        BuildingId = entity.BuildingId,
                        BuildingName = entity.Building.BuildingName,
                        Location = entity.Location,
                        Room = entity.Room
                    };
            }
        }
        public bool UpdateDepartment(DepartmentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Departments
                        .Single(e => e.DeptId == model.DeptId);
                entity.DeptId = model.DeptId;
                entity.DeptName = model.DeptName;
                entity.BuildingId = model.BuildingId;
                entity.Location = model.Location;
                entity.Room = model.Room;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteDepartment(int deptId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Departments
                        .Single(e => e.DeptId == deptId);

                ctx.Departments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
