namespace Booking_Flight_Ticket.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BookingModel : DbContext
    {
        // Your context has been configured to use a 'BookingModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Booking_Flight_Ticket.Models.BookingModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'BookingModel' 
        // connection string in the application configuration file.
        public BookingModel()
            : base("name=BookingModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<PersonalData> PersonalDatas { get; set; }
        public virtual DbSet<ReservationData> ReservationDatas { get; set; }
        public virtual DbSet<PlaneTime> PlaneTime { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}


}