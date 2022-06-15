namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tentativa : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comodo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResidencialComodo",
                c => new
                    {
                        Residencial_Id = c.Int(nullable: false),
                        Comodo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Residencial_Id, t.Comodo_Id })
                .ForeignKey("dbo.Tarefa_Residencial", t => t.Residencial_Id, cascadeDelete: true)
                .ForeignKey("dbo.Comodo", t => t.Comodo_Id, cascadeDelete: true)
                .Index(t => t.Residencial_Id)
                .Index(t => t.Comodo_Id);
            
            DropColumn("dbo.Tarefa_Residencial", "comodo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tarefa_Residencial", "comodo", c => c.String());
            DropForeignKey("dbo.ResidencialComodo", "Comodo_Id", "dbo.Comodo");
            DropForeignKey("dbo.ResidencialComodo", "Residencial_Id", "dbo.Tarefa_Residencial");
            DropIndex("dbo.ResidencialComodo", new[] { "Comodo_Id" });
            DropIndex("dbo.ResidencialComodo", new[] { "Residencial_Id" });
            DropTable("dbo.ResidencialComodo");
            DropTable("dbo.Comodo");
        }
    }
}
