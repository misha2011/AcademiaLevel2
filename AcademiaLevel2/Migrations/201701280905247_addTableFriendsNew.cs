namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableFriendsNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friends",
                c => new
                    {
                        idFriends = c.String(nullable: false, maxLength: 128),
                        status = c.String(),
                        userAnother_Id = c.String(maxLength: 128),
                        userThis_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.idFriends)
                .ForeignKey("dbo.AspNetUsers", t => t.userAnother_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.userThis_Id)
                .Index(t => t.userAnother_Id)
                .Index(t => t.userThis_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friends", "userThis_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Friends", "userAnother_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Friends", new[] { "userThis_Id" });
            DropIndex("dbo.Friends", new[] { "userAnother_Id" });
            DropTable("dbo.Friends");
        }
    }
}
