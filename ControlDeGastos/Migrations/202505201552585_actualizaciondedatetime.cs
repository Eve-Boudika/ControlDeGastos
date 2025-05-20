namespace ControlDeGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class actualizaciondedatetime : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Presupuestos", "Mes", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Presupuestos", "Mes", c => c.String());
        }
    }
}
