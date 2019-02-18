namespace WpfAuth.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WpfAuthDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StdDept",
                c => new
                    {
                        DeptId = c.String(nullable: false, maxLength: 128),
                        DeptName = c.String(),
                        UpDeptId = c.String(),
                    })
                .PrimaryKey(t => t.DeptId);
            
            CreateTable(
                "dbo.StdRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        RoleName = c.String(),
                        UpRoleId = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.StdUser",
                c => new
                    {
                        User_id = c.String(nullable: false, maxLength: 128),
                        User_Pw = c.String(),
                        Group_Name = c.String(),
                        User_Name = c.String(),
                        E_Mail = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.User_id);
            
            CreateTable(
                "dbo.StdUserDept",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        DeptId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.DeptId });
            
            CreateTable(
                "dbo.StdUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StdUserRole");
            DropTable("dbo.StdUserDept");
            DropTable("dbo.StdUser");
            DropTable("dbo.StdRole");
            DropTable("dbo.StdDept");
        }
    }
}
