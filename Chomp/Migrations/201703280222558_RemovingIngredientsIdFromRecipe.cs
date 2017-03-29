namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingIngredientsIdFromRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "RecipeId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Ingredients", "RecipeId");
            AddForeignKey("dbo.Ingredients", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
