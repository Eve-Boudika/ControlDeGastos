namespace ControlDeGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class agregodetalle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gastos", "Detalle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gastos", "Detalle");
        }
    }
}
