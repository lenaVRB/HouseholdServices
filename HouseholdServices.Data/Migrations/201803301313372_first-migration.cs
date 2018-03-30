namespace HouseholdServices.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        DateOfBirth = c.DateTime(),
                        Mobile = c.String(maxLength: 50, unicode: false),
                        RegistrationDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        OrderDate = c.DateTime(),
                        Status = c.String(maxLength: 50, unicode: false),
                        Address = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.OrderServices",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        OrderID = c.Int(nullable: false),
                        ServiceID = c.Int(nullable: false),
                        Status = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Services", t => t.ServiceID)
                .ForeignKey("dbo.Orders", t => t.OrderID)
                .Index(t => t.OrderID)
                .Index(t => t.ServiceID);
            
            CreateTable(
                "dbo.Services",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 50, unicode: false),
                        Price = c.Decimal(storeType: "money"),
                        Image = c.String(maxLength: 50),
                        Description = c.String(unicode: false, storeType: "text"),
                        ServiceTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ServiceTypes", t => t.ServiceTypeID)
                .Index(t => t.ServiceTypeID);
            
            CreateTable(
                "dbo.ServiceTypes",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Error",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Message = c.String(nullable: false, maxLength: 50),
                        StackTrace = c.String(unicode: false, storeType: "text"),
                        DateCreated = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        UserID = c.Int(nullable: false),
                        RoleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .ForeignKey("dbo.Roles", t => t.RoleID)
                .Index(t => t.UserID)
                .Index(t => t.RoleID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Username = c.String(nullable: false, maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 50, unicode: false),
                        HashedPassword = c.String(maxLength: 50, unicode: false),
                        IsLocked = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(),
                        Salt = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "RoleID", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "UserID", "dbo.Users");
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.OrderServices", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.Services", "ServiceTypeID", "dbo.ServiceTypes");
            DropForeignKey("dbo.OrderServices", "ServiceID", "dbo.Services");
            DropIndex("dbo.UserRoles", new[] { "RoleID" });
            DropIndex("dbo.UserRoles", new[] { "UserID" });
            DropIndex("dbo.Services", new[] { "ServiceTypeID" });
            DropIndex("dbo.OrderServices", new[] { "ServiceID" });
            DropIndex("dbo.OrderServices", new[] { "OrderID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.Error");
            DropTable("dbo.ServiceTypes");
            DropTable("dbo.Services");
            DropTable("dbo.OrderServices");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
