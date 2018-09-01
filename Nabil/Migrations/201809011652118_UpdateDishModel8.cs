namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDishModel8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "ImgUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "ImgUrl");
        }
    }
}
