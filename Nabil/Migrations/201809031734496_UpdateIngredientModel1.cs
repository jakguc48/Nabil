namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateIngredientModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ingredients", "ImgUrl");
        }
    }
}
