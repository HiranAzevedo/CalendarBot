namespace EntityAlpha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Resto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aluguels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        locacao = c.DateTime(nullable: false),
                        prazo = c.DateTime(nullable: false),
                        devolucao = c.DateTime(nullable: false),
                        carro_id = c.Int(),
                        usuario_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Carroes", t => t.carro_id)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id)
                .Index(t => t.carro_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(),
                        email = c.String(),
                        senha = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Carroes", "modelo_id", c => c.Int());
            CreateIndex("dbo.Carroes", "modelo_id");
            AddForeignKey("dbo.Carroes", "modelo_id", "dbo.Modeloes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluguels", "usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.Carroes", "modelo_id", "dbo.Modeloes");
            DropForeignKey("dbo.Aluguels", "carro_id", "dbo.Carroes");
            DropIndex("dbo.Carroes", new[] { "modelo_id" });
            DropIndex("dbo.Aluguels", new[] { "usuario_id" });
            DropIndex("dbo.Aluguels", new[] { "carro_id" });
            DropColumn("dbo.Carroes", "modelo_id");
            DropTable("dbo.Usuarios");
            DropTable("dbo.Aluguels");
        }
    }
}
