namespace HLWEB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _0106 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ContentCategory",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metaTitle = c.String(maxLength: 250),
                        parentID = c.Long(),
                        displayOrder = c.Int(),
                        seoTitle = c.String(maxLength: 250),
                        cratedDate = c.DateTime(),
                        metaKeywords = c.String(maxLength: 250),
                        metaDiscription = c.String(maxLength: 250),
                        status = c.Boolean(),
                        showOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50),
                        phoneNumber = c.String(maxLength: 50),
                        email = c.String(maxLength: 50),
                        address = c.String(maxLength: 50),
                        content = c.String(maxLength: 250),
                        createdDate = c.DateTime(),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Content",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metaTitle = c.String(maxLength: 250),
                        description = c.String(),
                        image = c.String(maxLength: 250),
                        categoryID = c.Long(),
                        metaKeywords = c.String(maxLength: 250),
                        metaDescription = c.String(maxLength: 250),
                        status = c.Boolean(),
                        topHot = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Founders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255),
                        image = c.String(maxLength: 255),
                        slogan = c.String(maxLength: 255),
                        link1 = c.String(maxLength: 255),
                        link2 = c.String(maxLength: 255),
                        position = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Info",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        image = c.String(maxLength: 250),
                        content = c.String(),
                        status = c.Boolean(),
                        link = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserName);
            
            CreateTable(
                "dbo.MoreProductImages",
                c => new
                    {
                        productId = c.Int(nullable: false),
                        id = c.Int(nullable: false, identity: true),
                        img1 = c.String(maxLength: 255),
                        img2 = c.String(maxLength: 255),
                        img3 = c.String(maxLength: 255),
                        img4 = c.String(maxLength: 255),
                        img5 = c.String(maxLength: 255),
                        img6 = c.String(maxLength: 255),
                        Product_id = c.Long(),
                    })
                .PrimaryKey(t => t.productId)
                .ForeignKey("dbo.Product", t => t.Product_id)
                .Index(t => t.Product_id);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        metaTitle = c.String(maxLength: 250),
                        name = c.String(maxLength: 250),
                        Cpu = c.String(maxLength: 255),
                        ram = c.String(maxLength: 255),
                        ocung = c.String(maxLength: 255),
                        carđohoa = c.String(maxLength: 255),
                        manhinh = c.String(maxLength: 255),
                        hedieuhanh = c.String(maxLength: 255),
                        pin = c.String(maxLength: 255),
                        trongluong = c.String(maxLength: 255),
                        baohanh = c.String(maxLength: 255),
                        mota = c.String(),
                        image = c.String(maxLength: 250),
                        price = c.Decimal(precision: 18, scale: 2),
                        promotionPrice = c.Decimal(precision: 18, scale: 2),
                        categoryID = c.Long(),
                        metaKeywords = c.String(maxLength: 250),
                        metaDescription = c.String(maxLength: 250),
                        status = c.Boolean(),
                        topHot = c.DateTime(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ProductCategory",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(maxLength: 250),
                        metaTitle = c.String(maxLength: 250),
                        parentID = c.Long(),
                        displayOrder = c.Int(),
                        seoTitle = c.String(maxLength: 250),
                        createdDate = c.DateTime(),
                        metaKeywords = c.String(maxLength: 250),
                        metaDiscription = c.String(maxLength: 250),
                        status = c.Boolean(),
                        showOnHome = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 255),
                        comment = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Address = c.String(),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Slide",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        image = c.String(maxLength: 250),
                        displayOrder = c.Int(),
                        link = c.String(maxLength: 250),
                        description = c.String(maxLength: 500),
                        createdDate = c.DateTime(),
                        status = c.Boolean(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        userName = c.String(maxLength: 50),
                        passWord = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MoreProductImages", "Product_id", "dbo.Product");
            DropIndex("dbo.MoreProductImages", new[] { "Product_id" });
            DropTable("dbo.User");
            DropTable("dbo.Slide");
            DropTable("dbo.Registers");
            DropTable("dbo.Ratings");
            DropTable("dbo.ProductCategory");
            DropTable("dbo.Product");
            DropTable("dbo.MoreProductImages");
            DropTable("dbo.Logins");
            DropTable("dbo.Info");
            DropTable("dbo.Founders");
            DropTable("dbo.Content");
            DropTable("dbo.Contact");
            DropTable("dbo.ContentCategory");
        }
    }
}
