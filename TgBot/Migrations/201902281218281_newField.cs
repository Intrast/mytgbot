namespace TgBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "CurrentPosition", c => c.String());
            AddColumn("dbo.Profiles", "Experience", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "Experience");
            DropColumn("dbo.Profiles", "CurrentPosition");
        }
    }
}
