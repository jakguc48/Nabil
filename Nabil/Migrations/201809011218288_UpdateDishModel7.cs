namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDishModel7 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Dishes", "DishType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Dishes", "DishType", c => c.Int(nullable: false));
        }
    }
}
