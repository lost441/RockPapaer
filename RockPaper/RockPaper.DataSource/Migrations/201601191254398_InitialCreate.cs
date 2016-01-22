namespace RockPaper.DataSource.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        GameState = c.String(),
                        IsComplete = c.Boolean(nullable: false),
                        WinningTeam = c.String(),
                        Team1_Id = c.Guid(),
                        Team2_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team1_Id)
                .ForeignKey("dbo.Teams", t => t.Team2_Id)
                .Index(t => t.Team1_Id)
                .Index(t => t.Team2_Id);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Team1Hand = c.String(),
                        Team2Hand = c.String(),
                        Result = c.String(),
                        SequenceNumber = c.Int(nullable: false),
                        Game_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.Game_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "Team2_Id", "dbo.Teams");
            DropForeignKey("dbo.Games", "Team1_Id", "dbo.Teams");
            DropForeignKey("dbo.Rounds", "Game_Id", "dbo.Games");
            DropIndex("dbo.Rounds", new[] { "Game_Id" });
            DropIndex("dbo.Games", new[] { "Team2_Id" });
            DropIndex("dbo.Games", new[] { "Team1_Id" });
            DropTable("dbo.Teams");
            DropTable("dbo.Rounds");
            DropTable("dbo.Games");
        }
    }
}
