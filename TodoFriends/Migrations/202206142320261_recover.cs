namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recover : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Log", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Log", new[] { "Usuario_Id" });
            DropTable("dbo.Log");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HoraCadastro = c.DateTime(nullable: false),
                        Acao = c.Int(nullable: false),
                        Usuario_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Log", "Usuario_Id");
            AddForeignKey("dbo.Log", "Usuario_Id", "dbo.Usuario", "Id");
        }
    }
}
