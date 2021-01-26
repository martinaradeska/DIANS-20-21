namespace LocalsScout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lokali_useri2 : DbMigration
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
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Reklama5_Lokal_ID });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationUserReklama5_Lokal");
        }
    }
}
