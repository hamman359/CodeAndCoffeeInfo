namespace CodeAndCoffeeInfo.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add_CCSession : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CCSession",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100, nullable: false),
                        Description = c.String(nullable: true),
						CreatedOn = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        CreatedBy = c.String(nullable: false),
						UpdatedOn = c.DateTime(nullable: false, defaultValueSql: "GETDATE()"),
                        UpdatedBy = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CCSession");
        }
    }
}
