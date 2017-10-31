namespace BanDongHo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateTimeColumnToOrderTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "DateTime");
        }
    }
}
