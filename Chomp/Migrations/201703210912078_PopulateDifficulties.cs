namespace Chomp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateDifficulties : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Difficulties (Name) VALUES ('Very Easy')");
            Sql("INSERT INTO Difficulties (Name) VALUES ('Easy')");
            Sql("INSERT INTO Difficulties (Name) VALUES ('Medium')");
            Sql("INSERT INTO Difficulties (Name) VALUES ('Hard')");
            Sql("INSERT INTO Difficulties (Name) VALUES ('Very Hard')");
        }
        
        public override void Down()
        {
        }
    }
}
