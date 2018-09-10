namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipesIntoDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        DishId = c.Int(nullable: false),
                        IngredientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DishId, t.IngredientId })
                .ForeignKey("dbo.Dishes", t => t.DishId, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId, cascadeDelete: true)
                .Index(t => t.DishId)
                .Index(t => t.IngredientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Recipes", "DishId", "dbo.Dishes");
            DropIndex("dbo.Recipes", new[] { "IngredientId" });
            DropIndex("dbo.Recipes", new[] { "DishId" });
            DropTable("dbo.Recipes");
        }
    }
}
