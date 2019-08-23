namespace Booking_Flight_Ticket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _03 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Class = c.Int(nullable: false),
                        AdultNumber = c.Int(nullable: false),
                        ChildernNumberNumber = c.Int(nullable: false),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        PersonalData_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonalDatas", t => t.PersonalData_Id)
                .Index(t => t.PersonalData_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationDatas", "PersonalData_Id", "dbo.PersonalDatas");
            DropIndex("dbo.ReservationDatas", new[] { "PersonalData_Id" });
            DropTable("dbo.ReservationDatas");
        }
    }
}
