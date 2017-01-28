namespace AcademiaLevel2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inPostChangeIntTiStringInId_2 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Friends");
            DropPrimaryKey("dbo.Posts");
            AlterColumn("dbo.Friends", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Posts", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Friends", "id");
            AddPrimaryKey("dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Posts");
            DropPrimaryKey("dbo.Friends");
            AlterColumn("dbo.Posts", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Friends", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Posts", "Id");
            AddPrimaryKey("dbo.Friends", "id");
        }
    }
}
