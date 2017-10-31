namespace BanDongHo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAboutContactTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 255),
                        Company = c.String(maxLength: 255),
                        Address = c.String(),
                        PhoneNumber = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
            DropTable("dbo.Abouts");
        }
    }
}
