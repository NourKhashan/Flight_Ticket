namespace Booking_Flight_Ticket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _06 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlaneTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime = c.String(),
                        Duration = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ReservationDatas", "PlaneTimeId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReservationDatas", "PlaneTimeId");
            AddForeignKey("dbo.ReservationDatas", "PlaneTimeId", "dbo.PlaneTimes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationDatas", "PlaneTimeId", "dbo.PlaneTimes");
            DropIndex("dbo.ReservationDatas", new[] { "PlaneTimeId" });
            DropColumn("dbo.ReservationDatas", "PlaneTimeId");
            DropTable("dbo.PlaneTimes");
        }
    }
}
