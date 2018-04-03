namespace EntityAlpha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criandoCarro : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carroes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        placa = c.String(),
                        quilometragem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Carroes");
        }
    }
}
