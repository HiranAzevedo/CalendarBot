namespace EntityAlpha.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Aluguels", "carro_id", "dbo.Carroes");
            DropForeignKey("dbo.Aluguels", "usuario_id", "dbo.Usuarios");
            DropIndex("dbo.Aluguels", new[] { "carro_id" });
            DropIndex("dbo.Aluguels", new[] { "usuario_id" });
            AddColumn("dbo.Aluguels", "carro_id1", c => c.Int());
            AddColumn("dbo.Aluguels", "usuario_id1", c => c.Int());
            AlterColumn("dbo.Aluguels", "carro_id", c => c.Int(nullable: false));
            AlterColumn("dbo.Aluguels", "usuario_id", c => c.Int(nullable: false));
            CreateIndex("dbo.Aluguels", "carro_id1");
            CreateIndex("dbo.Aluguels", "usuario_id1");
            AddForeignKey("dbo.Aluguels", "carro_id1", "dbo.Carroes", "id");
            AddForeignKey("dbo.Aluguels", "usuario_id1", "dbo.Usuarios", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Aluguels", "usuario_id1", "dbo.Usuarios");
            DropForeignKey("dbo.Aluguels", "carro_id1", "dbo.Carroes");
            DropIndex("dbo.Aluguels", new[] { "usuario_id1" });
            DropIndex("dbo.Aluguels", new[] { "carro_id1" });
            AlterColumn("dbo.Aluguels", "usuario_id", c => c.Int());
            AlterColumn("dbo.Aluguels", "carro_id", c => c.Int());
            DropColumn("dbo.Aluguels", "usuario_id1");
            DropColumn("dbo.Aluguels", "carro_id1");
            CreateIndex("dbo.Aluguels", "usuario_id");
            CreateIndex("dbo.Aluguels", "carro_id");
            AddForeignKey("dbo.Aluguels", "usuario_id", "dbo.Usuarios", "id");
            AddForeignKey("dbo.Aluguels", "carro_id", "dbo.Carroes", "id");
        }
    }
}
