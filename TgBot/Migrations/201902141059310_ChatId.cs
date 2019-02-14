namespace TgBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "ChatId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "ChatId", c => c.Int(nullable: false));
        }
    }
}
