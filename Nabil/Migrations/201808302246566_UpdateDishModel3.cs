namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDishModel3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "IngredientId", c => c.Int());
            AlterColumn("dbo.Dishes", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Ingredients", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Dishes", "IngredientId");
            AddForeignKey("dbo.Dishes", "IngredientId", "dbo.Ingredients", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.Dishes", new[] { "IngredientId" });
            AlterColumn("dbo.Ingredients", "Name", c => c.String());
            AlterColumn("dbo.Dishes", "Name", c => c.String());
            DropColumn("dbo.Dishes", "IngredientId");
        }
    }
}
