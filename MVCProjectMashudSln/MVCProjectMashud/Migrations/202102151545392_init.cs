namespace MVCProjectMashud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblDepartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DepartmentHead = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblDoctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        DoctorName = c.String(),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "dbo.tblPatients",
                c => new
                    {
                        PatientId = c.Int(nullable: false, identity: true),
                        PatientName = c.String(),
                        Age = c.Int(nullable: false),
                        AdmissionDate = c.DateTime(nullable: false),
                        Email = c.String(),
                        Bed = c.Boolean(nullable: false),
                        Cabin = c.Boolean(nullable: false),
                        ImageName = c.String(),
                        ImageUrl = c.String(),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PatientId)
                .ForeignKey("dbo.tblDoctors", t => t.DoctorId, cascadeDelete: true)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.tblRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollName = c.String(),
                        UserId = c.Int(nullable: false),
                        tblUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblUsers", t => t.tblUser_Id)
                .Index(t => t.tblUser_Id);
            
            CreateTable(
                "dbo.tblUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        UserPassword = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblRoles", "tblUser_Id", "dbo.tblUsers");
            DropForeignKey("dbo.tblPatients", "DoctorId", "dbo.tblDoctors");
            DropIndex("dbo.tblRoles", new[] { "tblUser_Id" });
            DropIndex("dbo.tblPatients", new[] { "DoctorId" });
            DropTable("dbo.tblUsers");
            DropTable("dbo.tblRoles");
            DropTable("dbo.tblPatients");
            DropTable("dbo.tblDoctors");
            DropTable("dbo.tblDepartments");
        }
    }
}
