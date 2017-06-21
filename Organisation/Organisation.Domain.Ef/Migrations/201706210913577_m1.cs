namespace Organisation.Domain.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Group",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Login",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 50),
                        Name = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        ReturnUrl = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamMember",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Designation = c.Int(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Image = c.String(),
                        IsTeanLead = c.Boolean(nullable: false),
                        TeamId = c.Int(nullable: true),
                        BillableStatus = c.Int(),
                        EmployeeStatus = c.Int(),
                        BriefDescription = c.String(),
                        HighestQualification = c.String(nullable: false),
                        YearOfPassing = c.Int(nullable: false),
                        YearofJoiningCCI = c.DateTime(nullable: false),
                        YearofJoiningTeam = c.DateTime(nullable: false),
                        phoneNumber = c.String(nullable: false, maxLength: 10),
                        Address = c.String(nullable: false),
                        Technologies = c.String(nullable: false),
                        SkypeId = c.String(nullable: false),
                        EmailId = c.String(nullable: false),
                        GmailId = c.String(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ClientName = c.String(nullable: false, maxLength: 50),
                        GroupId = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamMember", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "GroupId", "dbo.Group");
            DropIndex("dbo.Team", new[] { "GroupId" });
            DropIndex("dbo.TeamMember", new[] { "TeamId" });
            DropTable("dbo.Team");
            DropTable("dbo.TeamMember");
            DropTable("dbo.Login");
            DropTable("dbo.Group");
        }
    }
}
