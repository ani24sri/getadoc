namespace getadoc.Migrations.DataDb
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diseasesChng : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        appDate = c.DateTime(nullable: false),
                        reason = c.String(),
                        availble = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.diseaseDatas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        symptom1 = c.String(),
                        symptom2 = c.String(),
                        symptom3 = c.String(),
                        symptom4 = c.String(),
                        desc = c.String(),
                        cure = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        speciality = c.Int(nullable: false),
                        phoneno = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        symptoms = c.String(),
                        patientNo = c.Long(nullable: false),
                        phNo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
            DropTable("dbo.diseaseDatas");
            DropTable("dbo.Appointments");
        }
    }
}
