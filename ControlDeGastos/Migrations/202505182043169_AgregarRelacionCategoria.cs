namespace ControlDeGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarRelacionCategoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Gastos", "CategoriaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Gastos", "CategoriaId");
            AddForeignKey("dbo.Gastos", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
            DropColumn("dbo.Gastos", "Categoria");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gastos", "Categoria", c => c.String(nullable: false));
            DropForeignKey("dbo.Gastos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Gastos", new[] { "CategoriaId" });
            DropColumn("dbo.Gastos", "CategoriaId");
            DropTable("dbo.Categorias");
        }
    }
}
