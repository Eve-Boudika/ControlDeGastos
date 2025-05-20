namespace ControlDeGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPresupuesto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Presupuestos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Año = c.Int(nullable: false),
                        Mes = c.String(),
                        Monto = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Presupuestos");
        }
    }
}
