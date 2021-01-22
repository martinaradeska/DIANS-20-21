namespace LocalsScout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Izbrisan_Klient_Model : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reklama5_LokalKlient", "Reklama5_Lokal_ID", "dbo.Reklama5_Lokal");
            DropForeignKey("dbo.Reklama5_LokalKlient", "Klient_ID", "dbo.Klients");
            DropIndex("dbo.Reklama5_LokalKlient", new[] { "Reklama5_Lokal_ID" });
            DropIndex("dbo.Reklama5_LokalKlient", new[] { "Klient_ID" });
            DropTable("dbo.Klients");
            DropTable("dbo.Reklama5_LokalKlient");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Reklama5_LokalKlient",
                c => new
                    {
                        Reklama5_Lokal_ID = c.Int(nullable: false),
                        Klient_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reklama5_Lokal_ID, t.Klient_ID });
            
            CreateTable(
                "dbo.Klients",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Tel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.Reklama5_LokalKlient", "Klient_ID");
            CreateIndex("dbo.Reklama5_LokalKlient", "Reklama5_Lokal_ID");
            AddForeignKey("dbo.Reklama5_LokalKlient", "Klient_ID", "dbo.Klients", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Reklama5_LokalKlient", "Reklama5_Lokal_ID", "dbo.Reklama5_Lokal", "ID", cascadeDelete: true);
        }
    }
}
