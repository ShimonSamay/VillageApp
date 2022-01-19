namespace VillageAPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateResidentsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Residents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        FatherName = c.String(),
                        Gender = c.String(),
                        BornAtVillage = c.Boolean(nullable: false),
                        BirthDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Residents");
        }
    }
}
