namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipeIdToIngredientsAndRemoveIngredientsFromRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.Ingredients", new[] { "Recipe_Id" });
            AddColumn("dbo.Ingredients", "RecipeId", c => c.Int(nullable: false));
            DropColumn("dbo.Ingredients", "Recipe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Ingredients", "Recipe_Id", c => c.Int());
            DropColumn("dbo.Ingredients", "RecipeId");
            CreateIndex("dbo.Ingredients", "Recipe_Id");
            AddForeignKey("dbo.Ingredients", "Recipe_Id", "dbo.Recipes", "Id");
        }
    }
}
