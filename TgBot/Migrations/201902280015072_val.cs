namespace TgBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class val : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "Email", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "Email", c => c.String(nullable: false));
        }
    }
}
