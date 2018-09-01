namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDishModel4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dishes", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.Dishes", new[] { "IngredientId" });
            AddColumn("dbo.Dishes", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Dishes", "TypDania", c => c.String());
            DropColumn("dbo.Dishes", "IngredientId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dishes", "IngredientId", c => c.Int());
            DropColumn("dbo.Dishes", "TypDania");
            DropColumn("dbo.Dishes", "Price");
            CreateIndex("dbo.Dishes", "IngredientId");
            AddForeignKey("dbo.Dishes", "IngredientId", "dbo.Ingredients", "Id");
        }
    }
}
