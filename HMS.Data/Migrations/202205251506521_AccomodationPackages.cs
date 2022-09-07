namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccomodationPackages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Accomodations", "AccomodationTypeID", "dbo.AccomodationTypes");
            DropIndex("dbo.Accomodations", new[] { "AccomodationTypeID" });
            DropColumn("dbo.Accomodations", "AccomodationTypeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accomodations", "AccomodationTypeID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accomodations", "AccomodationTypeID");
            AddForeignKey("dbo.Accomodations", "AccomodationTypeID", "dbo.AccomodationTypes", "ID", cascadeDelete: true);
        }
    }
}
