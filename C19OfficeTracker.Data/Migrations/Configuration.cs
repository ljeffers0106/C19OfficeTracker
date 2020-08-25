

namespace C19OfficeTracker.Data.Migrations
{
    using C19OfficeTracker.Data;
    using System.Data.Entity.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<C19OfficeTracker.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "C19OfficeTracker.Data.ApplicationDbContext";
        }

        protected override void Seed(C19OfficeTracker.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Departments.AddOrUpdate(x => x.DeptId,
                        new Department
                        {
                            DeptId = 1,
                            DeptName = "Accounting",
                            Building = 1,
                            Location = "2nd Floor",
                            Room = "205B"
                        },
                        new Department
                        {
                            DeptId = 2,
                            DeptName = "IT",
                            Building = 1,
                            Location = "2nd Floor",
                            Room = "201"
                        },
                        new Department
                        {
                            DeptId = 3,
                            DeptName = "Human Resources",
                            Building = 1,
                            Location = "1st Floor",
                            Room = "101"
                        },
                        new Department
                        {
                            DeptId = 4,
                            DeptName = "Sales",
                            Building = 1,
                            Location = "3rd Floor",
                            Room = "301"
                        },
                        new Department
                        {
                            DeptId = 5,
                            DeptName = "Marketing",
                            Building = 1,
                            Location = "3rd Floor",
                            Room = "305"
                        },
                        new Department
                        {
                            DeptId = 6,
                            DeptName = "Customer Service",
                            Building = 2,
                            Location = "1st Floor",
                            Room = "107"
                        },
                        new Department
                        {
                            DeptId = 7,
                            DeptName = "Legal",
                            Building = 2,
                            Location = "2nd Floor",
                            Room = "201"
                        },
                        new Department
                        {
                            DeptId = 8,
                            DeptName = "Finance",
                            Building = 1,
                            Location = "2nd Floor",
                            Room = "210"
                        },
                        new Department
                        {
                            DeptId = 9,
                            DeptName = "Operations",
                            Building = 2,
                            Location = "3rd Floor",
                            Room = "301"
                        },
                        new Department
                        {
                            DeptId = 10,
                            DeptName = "Payroll",
                            Building = 1,
                            Location = "1st Floor",
                            Room = "105"
                        }
                );
            
        }
    }
}
