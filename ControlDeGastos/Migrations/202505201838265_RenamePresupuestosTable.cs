namespace ControlDeGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenamePresupuestosTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Presupuestoes", newName: "Presupuestos");
            AlterColumn("dbo.Presupuestos", "Año", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Presupuestos", "Año", c => c.Int(nullable: false));
            RenameTable(name: "dbo.Presupuestos", newName: "Presupuestoes");
        }
    }
}
