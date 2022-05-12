namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BasicEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccomodationPackages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationTypeID = c.Int(nullable: false),
                        Name = c.String(),
                        NoOfRoom = c.Int(nullable: false),
                        FeePerNight = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccomodationTypes", t => t.AccomodationTypeID, cascadeDelete: true)
                .Index(t => t.AccomodationTypeID);
            
            CreateTable(
                "dbo.AccomodationTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Accomodations",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccomodationTypeID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AccomodationTypes", t => t.AccomodationTypeID, cascadeDelete: true)
                .Index(t => t.AccomodationTypeID);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AcommodationID = c.Int(nullable: false),
                        FromDate = c.DateTime(nullable: false),
                        Duration = c.Int(nullable: false),
                        Accomodation_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accomodations", t => t.Accomodation_ID)
                .Index(t => t.Accomodation_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Accomodation_ID", "dbo.Accomodations");
            DropForeignKey("dbo.Accomodations", "AccomodationTypeID", "dbo.AccomodationTypes");
            DropForeignKey("dbo.AccomodationPackages", "AccomodationTypeID", "dbo.AccomodationTypes");
            DropIndex("dbo.Bookings", new[] { "Accomodation_ID" });
            DropIndex("dbo.Accomodations", new[] { "AccomodationTypeID" });
            DropIndex("dbo.AccomodationPackages", new[] { "AccomodationTypeID" });
            DropTable("dbo.Bookings");
            DropTable("dbo.Accomodations");
            DropTable("dbo.AccomodationTypes");
            DropTable("dbo.AccomodationPackages");
        }
    }
}
