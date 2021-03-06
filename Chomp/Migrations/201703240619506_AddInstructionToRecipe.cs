namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInstructionToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Instruction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "Instruction");
        }
    }
}
