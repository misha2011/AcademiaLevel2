namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likesTEst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idPost = c.Int(nullable: false),
                        iduser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.AspNetUsers", t => t.iduser_Id)
                .ForeignKey("dbo.Posts", t => t.idPost, cascadeDelete: true)
                .Index(t => t.idPost)
                .Index(t => t.iduser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "idPost", "dbo.Posts");
            DropForeignKey("dbo.Likes", "iduser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "iduser_Id" });
            DropIndex("dbo.Likes", new[] { "idPost" });
            DropTable("dbo.Likes");
        }
    }
}
