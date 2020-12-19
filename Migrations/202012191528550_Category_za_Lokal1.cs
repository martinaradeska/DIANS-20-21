namespace LocalsScout.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Category_za_Lokal1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Lokals", name: "Kategorija_Type_ID", newName: "Category_Type_ID");
            RenameIndex(table: "dbo.Lokals", name: "IX_Kategorija_Type_ID", newName: "IX_Category_Type_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Lokals", name: "IX_Category_Type_ID", newName: "IX_Kategorija_Type_ID");
            RenameColumn(table: "dbo.Lokals", name: "Category_Type_ID", newName: "Kategorija_Type_ID");
        }
    }
}
