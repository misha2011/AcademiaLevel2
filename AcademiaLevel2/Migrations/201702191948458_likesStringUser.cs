namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class likesStringUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "iduser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "iduser_Id" });
            AddColumn("dbo.Likes", "iduser", c => c.String());
            DropColumn("dbo.Likes", "iduser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likes", "iduser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Likes", "iduser");
            CreateIndex("dbo.Likes", "iduser_Id");
            AddForeignKey("dbo.Likes", "iduser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
