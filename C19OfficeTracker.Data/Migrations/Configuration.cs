namespace C19OfficeTracker.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<C19OfficeTracker.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(C19OfficeTracker.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Buildings.AddOrUpdate(x => x.BuildingId,
                                   new Building
                                   {
                                       BuildingId = 1,
                                       BuildingName = "Old Red Brick - 4 story",
                                       Address = "999 Main Street ",
                                       City = "Carmel",
                                       State = "IN",
                                       Postal = "46032"
                                   },
                                   new Building
                                   {
                                       BuildingId = 2,
                                       BuildingName = "Merchants Center",
                                       Address = "9750 Hague Road ",
                                       City = "Fishers",
                                       State = "IN",
                                       Postal = "46038"
                                   },
                                   new Building
                                   {
                                       BuildingId = 3,
                                       BuildingName = "Bank One Tower",
                                       Address = "111 Monument Circle ",
                                       City = "Indianapolis",
                                       State = "IN",
                                       Postal = "46204"
                                   },
                                   new Building
                                   {
                                       BuildingId = 4,
                                       BuildingName = "State Farm Building",
                                       Address = "32 Madison Ave ",
                                       City = "Indianapolis",
                                       State = "IN",
                                       Postal = "46227"
                                   },
                                    new Building
                                    {
                                        BuildingId = 5,
                                        BuildingName = "Tucker Building",
                                        Address = "2932 Main Street ",
                                        City = "Greenwood",
                                        State = "IN",
                                        Postal = "46143"
                                    }
                   );
            context.Departments.AddOrUpdate(x => x.DeptId,
                        new Department
                        {
                            DeptId = 1,
                            DeptName = "Accounting",
                            BuildingId = 1,
                            Location = "2nd Floor",
                            Room = "205B"
                        },
                        new Department
                        {
                            DeptId = 2,
                            DeptName = "IT",
                            BuildingId = 1,
                            Location = "2nd Floor",
                            Room = "201"
                        },
                        new Department
                        {
                            DeptId = 3,
                            DeptName = "Human Resources",
                            BuildingId = 1,
                            Location = "1st Floor",
                            Room = "101"
                        },
                        new Department
                        {
                            DeptId = 4,
                            DeptName = "Sales",
                            BuildingId = 1,
                            Location = "3rd Floor",
                            Room = "301"
                        },
                        new Department
                        {
                            DeptId = 5,
                            DeptName = "Marketing",
                            BuildingId = 1,
                            Location = "3rd Floor",
                            Room = "305"
                        },
                        new Department
                        {
                            DeptId = 6,
                            DeptName = "Customer Service",
                            BuildingId = 2,
                            Location = "1st Floor",
                            Room = "107"
                        },
                        new Department
                        {
                            DeptId = 7,
                            DeptName = "Legal",
                            BuildingId = 2,
                            Location = "2nd Floor",
                            Room = "201"
                        },
                        new Department
                        {
                            DeptId = 8,
                            DeptName = "Finance",
                            BuildingId = 1,
                            Location = "2nd Floor",
                            Room = "210"
                        },
                        new Department
                        {
                            DeptId = 9,
                            DeptName = "Operations",
                            BuildingId = 2,
                            Location = "3rd Floor",
                            Room = "301"
                        },
                        new Department
                        {
                            DeptId = 10,
                            DeptName = "Payroll",
                            BuildingId = 1,
                            Location = "1st Floor",
                            Room = "105"
                        }
                );
        }
    }
}
