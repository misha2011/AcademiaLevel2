namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPost : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        IdUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.IdUser_Id)
                .Index(t => t.IdUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "IdUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "IdUser_Id" });
            DropTable("dbo.Posts");
        }
    }
}
