namespace ProjectCrudMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExtraTableForPlayers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Team = c.String(),
                        HireInBPL = c.String(),
                        SigningMoney = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        GradeID = c.Int(nullable: false, identity: true),
                        GradeName = c.String(),
                    })
                .PrimaryKey(t => t.GradeID);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        DoB = c.DateTime(nullable: false),
                        Team = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                        GradeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlayerID)
                .ForeignKey("dbo.Grades", t => t.GradeID, cascadeDelete: true)
                .Index(t => t.GradeID);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        UserID = c.Int(nullable: false),
                        TblUser_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.tblUsers", t => t.TblUser_ID)
                .Index(t => t.TblUser_ID);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblRoles", "TblUser_ID", "dbo.tblUsers");
            DropForeignKey("dbo.Players", "GradeID", "dbo.Grades");
            DropIndex("dbo.tblRoles", new[] { "TblUser_ID" });
            DropIndex("dbo.Players", new[] { "GradeID" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblRoles");
            DropTable("dbo.Players");
            DropTable("dbo.Grades");
            DropTable("dbo.ExtraTableForPlayers");
        }
    }
}
