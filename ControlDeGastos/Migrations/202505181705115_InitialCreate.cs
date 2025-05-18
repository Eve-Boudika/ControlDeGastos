namespace ControlDeGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Gastos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Monto = c.Int(nullable: false),
                        Categoria = c.String(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Gastos");
        }
    }
}
