// <auto-generated />
namespace Chomp.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.1.3-40302")]
    public sealed partial class RemoveRecipeIdAndAddIngredients : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(RemoveRecipeIdAndAddIngredients));
        
        string IMigrationMetadata.Id
        {
            get { return "201703261606327_RemoveRecipeIdAndAddIngredients"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}