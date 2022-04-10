namespace Hotel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        ArriveDateTime = c.DateTime(nullable: false),
                        DepartureDateTime = c.DateTime(nullable: false),
                        Room = c.String(maxLength: 100),
                        NumberOfPeople = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReservationModels");
        }
    }
}
