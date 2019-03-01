namespace TgBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_model_profile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "CurrentProperty", c => c.String());
            AddColumn("dbo.Profiles", "Email", c => c.String());
            AddColumn("dbo.Profiles", "Phone", c => c.String());
            AddColumn("dbo.Profiles", "Adress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "Adress");
            DropColumn("dbo.Profiles", "Phone");
            DropColumn("dbo.Profiles", "Email");
            DropColumn("dbo.Profiles", "CurrentProperty");
        }
    }
}
