namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NovaMig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Local", "Name", c => c.String());
            AlterColumn("dbo.Local", "Rua", c => c.String(maxLength: 25));
            AlterColumn("dbo.Local", "Bairro", c => c.String(maxLength: 25));
            AlterColumn("dbo.Local", "Lote", c => c.String(maxLength: 25));
            AlterColumn("dbo.Local", "Qi", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Local", "Qi", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Local", "Lote", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Local", "Bairro", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Local", "Rua", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Local", "Name", c => c.String(nullable: false));
        }
    }
}
