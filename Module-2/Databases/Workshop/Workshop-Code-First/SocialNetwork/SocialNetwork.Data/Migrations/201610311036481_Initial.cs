namespace SocialNetwork.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Friendships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstUsedId = c.Int(nullable: false),
                        SecondUsedId = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        FriendsSince = c.DateTime(),
                        FirstUser_Id = c.Int(),
                        SecondUser_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.FirstUser_Id)
                .ForeignKey("dbo.Users", t => t.SecondUser_Id)
                .Index(t => t.Approved)
                .Index(t => t.FirstUser_Id)
                .Index(t => t.SecondUser_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 20),
                        FirstName = c.String(maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        RegisteredOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Username, unique: true);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(nullable: false),
                        FileExtension = c.String(nullable: false, maxLength: 4),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        SentOn = c.DateTime(nullable: false),
                        SeenOn = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        FriendshipId = c.Int(nullable: false),
                        Author_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Author_Id)
                .ForeignKey("dbo.Friendships", t => t.FriendshipId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.SentOn)
                .Index(t => t.UserId)
                .Index(t => t.FriendshipId)
                .Index(t => t.Author_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        PostedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostUsers",
                c => new
                    {
                        Post_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Post_Id, t.User_Id })
                .ForeignKey("dbo.Posts", t => t.Post_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Post_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Friendships", "SecondUser_Id", "dbo.Users");
            DropForeignKey("dbo.Friendships", "FirstUser_Id", "dbo.Users");
            DropForeignKey("dbo.PostUsers", "User_Id", "dbo.Users");
            DropForeignKey("dbo.PostUsers", "Post_Id", "dbo.Posts");
            DropForeignKey("dbo.Messages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Messages", "UserId", "dbo.Users");
            DropForeignKey("dbo.Messages", "FriendshipId", "dbo.Friendships");
            DropForeignKey("dbo.Messages", "Author_Id", "dbo.Users");
            DropForeignKey("dbo.Images", "UserId", "dbo.Users");
            DropIndex("dbo.PostUsers", new[] { "User_Id" });
            DropIndex("dbo.PostUsers", new[] { "Post_Id" });
            DropIndex("dbo.Messages", new[] { "User_Id" });
            DropIndex("dbo.Messages", new[] { "Author_Id" });
            DropIndex("dbo.Messages", new[] { "FriendshipId" });
            DropIndex("dbo.Messages", new[] { "UserId" });
            DropIndex("dbo.Messages", new[] { "SentOn" });
            DropIndex("dbo.Images", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Username" });
            DropIndex("dbo.Friendships", new[] { "SecondUser_Id" });
            DropIndex("dbo.Friendships", new[] { "FirstUser_Id" });
            DropIndex("dbo.Friendships", new[] { "Approved" });
            DropTable("dbo.PostUsers");
            DropTable("dbo.Posts");
            DropTable("dbo.Messages");
            DropTable("dbo.Images");
            DropTable("dbo.Users");
            DropTable("dbo.Friendships");
        }
    }
}
