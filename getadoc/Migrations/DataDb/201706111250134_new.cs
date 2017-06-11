namespace getadoc.Migrations.DataDb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.feedbacks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        rate = c.Int(nullable: false),
                        feed = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.feedbacks");
        }
    }
}
