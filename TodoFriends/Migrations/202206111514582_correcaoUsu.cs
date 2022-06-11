namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correcaoUsu : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuario", "Nome", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuario", "Nome", c => c.String(nullable: false));
        }
    }
}
