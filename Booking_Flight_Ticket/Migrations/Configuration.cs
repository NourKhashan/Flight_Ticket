namespace Booking_Flight_Ticket.Migrations
{
    using Booking_Flight_Ticket.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Booking_Flight_Ticket.Models.BookingModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Booking_Flight_Ticket.Models.BookingModel context)
        {
            //  This method will be called after migrating to the latest version.
            IList<PlaneTime> defaultStandards = new List<PlaneTime>();

            defaultStandards.Add(new PlaneTime() { StartTime = "09:00", Duration = "09:00 - 09:20" });
            defaultStandards.Add(new PlaneTime() { StartTime = "09:20", Duration = "09:20 - 09:40" });
            defaultStandards.Add(new PlaneTime() { StartTime = "09:40", Duration = "09:40 - 09:50" });

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
