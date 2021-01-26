namespace LocalsScout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class user_lokali_vo_db : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ApplicationUserReklama5_Lokal", newName: "ApplicationUserReklama5_Lokal1");
            CreateTable(
                "dbo.ApplicationUserReklama5_Lokal",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Reklama5_Lokal_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Reklama5_Lokal_ID });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationUserReklama5_Lokal");
            RenameTable(name: "dbo.ApplicationUserReklama5_Lokal1", newName: "ApplicationUserReklama5_Lokal");
        }
    }
}
