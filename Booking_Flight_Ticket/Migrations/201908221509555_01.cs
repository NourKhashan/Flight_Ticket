namespace Booking_Flight_Ticket.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PersonalDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 10),
                        MiddleName = c.String(nullable: false, maxLength: 10),
                        GrandFatherName = c.String(nullable: false, maxLength: 10),
                        LastName = c.String(nullable: false, maxLength: 10),
                        Email = c.String(nullable: false),
                        IdentityNumber = c.String(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        BithPlace = c.String(nullable: false, maxLength: 10),
                        PhoneNumber = c.String(nullable: false),
                        MobileNumber = c.String(nullable: false),
                        Residence = c.String(nullable: false, maxLength: 10),
                        Street = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PersonalDatas");
        }
    }
}
