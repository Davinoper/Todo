namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Novissima : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarefa_Residencial", "comodo", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tarefa_Residencial", "comodo");
        }
    }
}
