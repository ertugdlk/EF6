namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModificationHistoryInterface : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clans", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clans", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clans", "isDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ninjas", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ninjas", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ninjas", "isDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.NinjaEquipments", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.NinjaEquipments", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.NinjaEquipments", "isDirty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NinjaEquipments", "isDirty");
            DropColumn("dbo.NinjaEquipments", "DateModified");
            DropColumn("dbo.NinjaEquipments", "DateCreated");
            DropColumn("dbo.Ninjas", "isDirty");
            DropColumn("dbo.Ninjas", "DateModified");
            DropColumn("dbo.Ninjas", "DateCreated");
            DropColumn("dbo.Clans", "isDirty");
            DropColumn("dbo.Clans", "DateModified");
            DropColumn("dbo.Clans", "DateCreated");
        }
    }
}
