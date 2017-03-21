namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAspNetUserIdToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "AspNetUserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "AspNetUserId");
        }
    }
}
