namespace LocalsScout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NM_relacija_users_lokali : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationUserReklama5_Lokal",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Reklama5_Lokal_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Reklama5_Lokal_ID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Reklama5_Lokal", t => t.Reklama5_Lokal_ID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Reklama5_Lokal_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserReklama5_Lokal", "Reklama5_Lokal_ID", "dbo.Reklama5_Lokal");
            DropForeignKey("dbo.ApplicationUserReklama5_Lokal", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserReklama5_Lokal", new[] { "Reklama5_Lokal_ID" });
            DropIndex("dbo.ApplicationUserReklama5_Lokal", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserReklama5_Lokal");
        }
    }
}
