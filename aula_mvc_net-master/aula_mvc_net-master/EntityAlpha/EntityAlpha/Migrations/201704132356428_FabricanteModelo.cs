namespace EntityAlpha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FabricanteModelo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Fabricantes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        fabricante_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Fabricantes", t => t.fabricante_id)
                .Index(t => t.fabricante_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "fabricante_id", "dbo.Fabricantes");
            DropIndex("dbo.Modeloes", new[] { "fabricante_id" });
            DropTable("dbo.Modeloes");
            DropTable("dbo.Fabricantes");
        }
    }
}
