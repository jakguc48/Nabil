namespace Nabil.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDishModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Dishes", "GluteFree", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Dishes", "GluteFree");
        }
    }
}
