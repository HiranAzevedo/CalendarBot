namespace EntityAlpha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arrumando : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aluguels", "carro_id1", "dbo.Carroes");
            DropForeignKey("dbo.Aluguels", "usuario_id1", "dbo.Usuarios");
            DropIndex("dbo.Aluguels", new[] { "carro_id1" });
            DropIndex("dbo.Aluguels", new[] { "usuario_id1" });
            RenameColumn(table: "dbo.Aluguels", name: "carro_id1", newName: "carroId");
            RenameColumn(table: "dbo.Aluguels", name: "usuario_id1", newName: "usuarioId");
            AlterColumn("dbo.Aluguels", "carroId", c => c.Int(nullable: false));
            AlterColumn("dbo.Aluguels", "usuarioId", c => c.Int(nullable: false));
            CreateIndex("dbo.Aluguels", "carroId");
            CreateIndex("dbo.Aluguels", "usuarioId");
            AddForeignKey("dbo.Aluguels", "carroId", "dbo.Carroes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Aluguels", "usuarioId", "dbo.Usuarios", "id", cascadeDelete: true);
            DropColumn("dbo.Aluguels", "carro_id");
            DropColumn("dbo.Aluguels", "usuario_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Aluguels", "usuario_id", c => c.Int(nullable: false));
            AddColumn("dbo.Aluguels", "carro_id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Aluguels", "usuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Aluguels", "carroId", "dbo.Carroes");
            DropIndex("dbo.Aluguels", new[] { "usuarioId" });
            DropIndex("dbo.Aluguels", new[] { "carroId" });
            AlterColumn("dbo.Aluguels", "usuarioId", c => c.Int());
            AlterColumn("dbo.Aluguels", "carroId", c => c.Int());
            RenameColumn(table: "dbo.Aluguels", name: "usuarioId", newName: "usuario_id1");
            RenameColumn(table: "dbo.Aluguels", name: "carroId", newName: "carro_id1");
            CreateIndex("dbo.Aluguels", "usuario_id1");
            CreateIndex("dbo.Aluguels", "carro_id1");
            AddForeignKey("dbo.Aluguels", "usuario_id1", "dbo.Usuarios", "id");
            AddForeignKey("dbo.Aluguels", "carro_id1", "dbo.Carroes", "id");
        }
    }
}
