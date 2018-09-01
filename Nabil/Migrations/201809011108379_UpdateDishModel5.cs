namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDishModel5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "DishType", c => c.String());
            DropColumn("dbo.Dishes", "TypDania");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dishes", "TypDania", c => c.String());
            DropColumn("dbo.Dishes", "DishType");
        }
    }
}
