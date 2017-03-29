namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveIngredientsFromRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
            DropTable("dbo.Ingredients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Ingredients", "RecipeId");
            AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
