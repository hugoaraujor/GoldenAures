namespace AurumData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mesonero : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Mesoneros");
            AlterColumn("dbo.Mesoneros", "Idmesonero", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Mesoneros", "Idmesonero");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Mesoneros");
            AlterColumn("dbo.Mesoneros", "Idmesonero", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Mesoneros", "Idmesonero");
        }
    }
}
