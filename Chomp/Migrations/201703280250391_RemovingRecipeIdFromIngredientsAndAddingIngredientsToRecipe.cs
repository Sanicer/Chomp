namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingRecipeIdFromIngredientsAndAddingIngredientsToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ingredients", "Recipe_Id", c => c.Int());
            CreateIndex("dbo.Ingredients", "Recipe_Id");
            AddForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes", "Id");
            DropColumn("dbo.Ingredients", "RecipeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "RecipeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            DropColumn("dbo.Ingredients", "Recipe_Id");
        }
    }
}
