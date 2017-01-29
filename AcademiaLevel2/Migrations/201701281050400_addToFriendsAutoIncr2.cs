namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addToFriendsAutoIncr2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Friends");
            AlterColumn("dbo.Friends", "idFriends", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Friends", "idFriends");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Friends");
            AlterColumn("dbo.Friends", "idFriends", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Friends", "idFriends");
        }
    }
}
