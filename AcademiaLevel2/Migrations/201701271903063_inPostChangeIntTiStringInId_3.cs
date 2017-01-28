namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inPostChangeIntTiStringInId_3 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Friends");
            AddColumn("dbo.Friends", "idFriends", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Friends", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Friends", "idFriends");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Friends");
            AlterColumn("dbo.Friends", "id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Friends", "idFriends");
            AddPrimaryKey("dbo.Friends", "id");
        }
    }
}
