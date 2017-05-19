namespace ToDoList.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Task",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 100),
                        Priority = c.Int(),
                        TaskDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Task");
        }
    }
}
