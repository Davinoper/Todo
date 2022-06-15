namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reco : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comodo", "Residencial_Id", "dbo.Tarefa_Residencial");
            DropIndex("dbo.Comodo", new[] { "Residencial_Id" });
            AddColumn("dbo.Tarefa_Residencial", "comodo", c => c.String());
            DropTable("dbo.Comodo");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comodo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Residencial_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Tarefa_Residencial", "comodo");
            CreateIndex("dbo.Comodo", "Residencial_Id");
            AddForeignKey("dbo.Comodo", "Residencial_Id", "dbo.Tarefa_Residencial", "Id");
        }
    }
}
