namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckForeignKeyRecipeID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ingredients", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Ingredients", "Name", c => c.String(nullable: false));
        }
    }
}
