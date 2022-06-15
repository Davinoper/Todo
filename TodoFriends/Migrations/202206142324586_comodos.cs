namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comodos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comodo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Residencial_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tarefa_Residencial", t => t.Residencial_Id)
                .Index(t => t.Residencial_Id);
            
            DropColumn("dbo.Tarefa_Residencial", "comodo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefa_Residencial", "comodo", c => c.String());
            DropForeignKey("dbo.Comodo", "Residencial_Id", "dbo.Tarefa_Residencial");
            DropIndex("dbo.Comodo", new[] { "Residencial_Id" });
            DropTable("dbo.Comodo");
        }
    }
}
