namespace AurumData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mesas : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Mesas",
                c => new
                    {
                        Idmesa = c.Int(nullable: false, identity: true),
                        Siglas = c.String(),
                        Ocupada = c.Boolean(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        Area = c.Int(nullable: false),
                        HoraReserva = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        Idmesonero = c.Int(),
                        Idocupante = c.Int(),
                    })
                .PrimaryKey(t => t.Idmesa);
            
                       
          
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mesas");
          
        }
    }
}
