using C19OfficeTracker.Data;
using C19OfficeTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C19OfficeTracker.Services
{
    public class EmployeeService
    {
        private readonly Guid _userId;

        public EmployeeService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateEmployee(EmployeeCreate model)
        {
            var entity =
                new Employee()
                {
                    IndividualId = _userId,
                    FullName = model.FullName,
                    Phone = model.Phone,
                    Email = model.Email,
                    HireDate = model.HireDate,
                    BirthDate = model.BirthDate,
                    Gender = model.Gender,
                    TypeOfPosition = model.TypeOfPosition,
                    DeptId = model.DeptId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Employees.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        
        public IEnumerable<EmployeeListItem> GetEmployees()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Employees
                       // .Where(e => e.IndividualId == _userId)
                        .Where(e => e.FullName != null)
                        .Select(
                            e =>
                                new EmployeeListItem
                                {
                                    EmpId = e.EmpId,
                                    FullName = e.FullName,
                                    Phone = e.Phone,
                                    Gender = e.Gender,
                                    TypeOfPosition = e.TypeOfPosition,
                                    DeptId = e.DeptId
                                }
                        );

                return query.ToArray();
            }
        }
        public EmployeeDetail GetEmployeeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        //.Single(e => e.EmpId == id && e.IndividualId == _userId);
                        .Single(e => e.EmpId == id);
               
                return
                    new EmployeeDetail
                    {
                        EmpId = entity.EmpId,
                        FullName = entity.FullName,
                        Phone = entity.Phone,
                        Email = entity.Email,
                        Gender = entity.Gender,
                        TypeOfPosition = entity.TypeOfPosition,
                        DeptId = entity.DeptId
                    };
            }
        }
        public bool UpdateNote(EmployeeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Employees
                        .Single(e => e.EmpId == model.EmpId);
                        //.Single(e => e.EmpId == model.EmpId && e.IndividualId == _userId);
                entity.EmpId = model.EmpId;
                entity.FullName = model.FullName;
                entity.Phone = model.Phone;
                entity.Email = model.Email;
                entity.Gender = model.Gender;
                entity.TypeOfPosition = model.TypeOfPosition;
                entity.DeptId = model.DeptId;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
