namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class еуіе : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "idUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Likes", "Post_Id", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "idUser_Id" });
            DropIndex("dbo.Likes", new[] { "Post_Id" });
           
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Post = c.Int(nullable: false),
                        idUser_Id = c.String(maxLength: 128),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Posts", "isLike", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Likes", "Post_Id");
            CreateIndex("dbo.Likes", "idUser_Id");
            AddForeignKey("dbo.Likes", "Post_Id", "dbo.Posts", "Id");
            AddForeignKey("dbo.Likes", "idUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
