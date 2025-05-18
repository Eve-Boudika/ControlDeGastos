namespace ControlDeGastos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameGastoesToGastos : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Gastoes", newName: "Gastos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Gastos", newName: "Gastoes");
        }
    }
}
