namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCuisines : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Cuisines (Name) VALUES ('Australian')");
            Sql("INSERT INTO Cuisines (Name) VALUES ('Brazilian')");
            Sql("INSERT INTO Cuisines (Name) VALUES ('Chinese')");
            Sql("INSERT INTO Cuisines (Name) VALUES ('Italian')");
            Sql("INSERT INTO Cuisines (Name) VALUES ('Japanese')");
            Sql("INSERT INTO Cuisines (Name) VALUES ('Korean')");
        }
        
        public override void Down()
        {
        }
    }
}
