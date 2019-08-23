namespace Booking_Flight_Ticket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationDatas", "PlaneTimeId", "dbo.PlaneTimes");
            DropIndex("dbo.ReservationDatas", new[] { "PlaneTimeId" });
            DropColumn("dbo.ReservationDatas", "PlaneTimeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReservationDatas", "PlaneTimeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReservationDatas", "PlaneTimeId");
            AddForeignKey("dbo.ReservationDatas", "PlaneTimeId", "dbo.PlaneTimes", "Id", cascadeDelete: true);
        }
    }
}
