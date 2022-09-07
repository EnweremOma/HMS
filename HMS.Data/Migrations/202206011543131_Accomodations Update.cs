namespace HMS.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccomodationsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Accomodations", "AccomodationPackageID", c => c.Int(nullable: false));
            CreateIndex("dbo.Accomodations", "AccomodationPackageID");
            AddForeignKey("dbo.Accomodations", "AccomodationPackageID", "dbo.AccomodationPackages", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Accomodations", "AccomodationPackageID", "dbo.AccomodationPackages");
            DropIndex("dbo.Accomodations", new[] { "AccomodationPackageID" });
            DropColumn("dbo.Accomodations", "AccomodationPackageID");
        }
    }
}
