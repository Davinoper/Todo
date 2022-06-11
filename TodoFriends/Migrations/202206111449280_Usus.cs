namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Usus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tarefa", "Usuario_Id", c => c.Int());
            CreateIndex("dbo.Tarefa", "Usuario_Id");
            AddForeignKey("dbo.Tarefa", "Usuario_Id", "dbo.Usuario", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefa", "Usuario_Id", "dbo.Usuario");
            DropIndex("dbo.Tarefa", new[] { "Usuario_Id" });
            DropColumn("dbo.Tarefa", "Usuario_Id");
        }
    }
}
