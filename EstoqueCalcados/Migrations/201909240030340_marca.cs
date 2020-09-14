namespace NosSeusPes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class marca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sapatoes", "Marca", c => c.String());
            DropColumn("dbo.Sapatoes", "Nome");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sapatoes", "Nome", c => c.String());
            DropColumn("dbo.Sapatoes", "Marca");
        }
    }
}
