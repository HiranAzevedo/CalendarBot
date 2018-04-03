namespace EntityAlpha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CamposId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Carroes", "modelo_id", "dbo.Modeloes");
            DropForeignKey("dbo.Modeloes", "fabricante_id", "dbo.Fabricantes");
            DropIndex("dbo.Carroes", new[] { "modelo_id" });
            DropIndex("dbo.Modeloes", new[] { "fabricante_id" });
            RenameColumn(table: "dbo.Carroes", name: "modelo_id", newName: "modeloId");
            RenameColumn(table: "dbo.Modeloes", name: "fabricante_id", newName: "fabricanteId");
            AlterColumn("dbo.Carroes", "modeloId", c => c.Int(nullable: false));
            AlterColumn("dbo.Modeloes", "fabricanteId", c => c.Int(nullable: false));
            CreateIndex("dbo.Carroes", "modeloId");
            CreateIndex("dbo.Modeloes", "fabricanteId");
            AddForeignKey("dbo.Carroes", "modeloId", "dbo.Modeloes", "id", cascadeDelete: true);
            AddForeignKey("dbo.Modeloes", "fabricanteId", "dbo.Fabricantes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Modeloes", "fabricanteId", "dbo.Fabricantes");
            DropForeignKey("dbo.Carroes", "modeloId", "dbo.Modeloes");
            DropIndex("dbo.Modeloes", new[] { "fabricanteId" });
            DropIndex("dbo.Carroes", new[] { "modeloId" });
            AlterColumn("dbo.Modeloes", "fabricanteId", c => c.Int());
            AlterColumn("dbo.Carroes", "modeloId", c => c.Int());
            RenameColumn(table: "dbo.Modeloes", name: "fabricanteId", newName: "fabricante_id");
            RenameColumn(table: "dbo.Carroes", name: "modeloId", newName: "modelo_id");
            CreateIndex("dbo.Modeloes", "fabricante_id");
            CreateIndex("dbo.Carroes", "modelo_id");
            AddForeignKey("dbo.Modeloes", "fabricante_id", "dbo.Fabricantes", "id");
            AddForeignKey("dbo.Carroes", "modelo_id", "dbo.Modeloes", "id");
        }
    }
}
