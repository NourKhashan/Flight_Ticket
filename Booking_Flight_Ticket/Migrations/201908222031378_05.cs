namespace Booking_Flight_Ticket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReservationDatas", "PersonalData_Id", "dbo.PersonalDatas");
            DropIndex("dbo.ReservationDatas", new[] { "PersonalData_Id" });
            RenameColumn(table: "dbo.ReservationDatas", name: "PersonalData_Id", newName: "PersonId");
            AlterColumn("dbo.ReservationDatas", "PersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReservationDatas", "PersonId");
            AddForeignKey("dbo.ReservationDatas", "PersonId", "dbo.PersonalDatas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationDatas", "PersonId", "dbo.PersonalDatas");
            DropIndex("dbo.ReservationDatas", new[] { "PersonId" });
            AlterColumn("dbo.ReservationDatas", "PersonId", c => c.Int());
            RenameColumn(table: "dbo.ReservationDatas", name: "PersonId", newName: "PersonalData_Id");
            CreateIndex("dbo.ReservationDatas", "PersonalData_Id");
            AddForeignKey("dbo.ReservationDatas", "PersonalData_Id", "dbo.PersonalDatas", "Id");
        }
    }
}
