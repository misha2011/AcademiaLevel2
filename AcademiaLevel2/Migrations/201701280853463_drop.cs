namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friends", "userAnother_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "userThis_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "userAnother_Id" });
            DropIndex("dbo.Friends", new[] { "userThis_Id" });
            DropTable("dbo.Friends");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        idFriends = c.String(),
                        status = c.String(),
                        userAnother_Id = c.String(maxLength: 128),
                        userThis_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Friends", "userThis_Id");
            CreateIndex("dbo.Friends", "userAnother_Id");
            AddForeignKey("dbo.Friends", "userThis_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Friends", "userAnother_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
