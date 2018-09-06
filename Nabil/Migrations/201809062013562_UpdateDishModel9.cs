namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDishModel9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "Description", c => c.String());
            AddColumn("dbo.Dishes", "WeightSmall", c => c.Short());
            AddColumn("dbo.Dishes", "PriceSmall", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "PriceSmall");
            DropColumn("dbo.Dishes", "WeightSmall");
            DropColumn("dbo.Dishes", "Description");
        }
    }
}
