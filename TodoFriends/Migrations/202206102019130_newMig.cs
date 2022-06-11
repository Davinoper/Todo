namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Tarefa_Residencial", "comodo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefa_Residencial", "comodo", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
