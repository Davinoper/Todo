namespace TodoFriends.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class recovery : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
