namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDishModel10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "Size1", c => c.String());
            AddColumn("dbo.Dishes", "Size2", c => c.String());
            DropColumn("dbo.Dishes", "Weight");
            DropColumn("dbo.Dishes", "WeightSmall");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Dishes", "WeightSmall", c => c.Short());
            AddColumn("dbo.Dishes", "Weight", c => c.Short(nullable: false));
            DropColumn("dbo.Dishes", "Size2");
            DropColumn("dbo.Dishes", "Size1");
        }
    }
}
