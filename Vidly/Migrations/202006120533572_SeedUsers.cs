namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'559d30c3-7701-40a5-9bb5-c4bec1de58ef', N'admin@vidly.com', 0, N'AOe9OEEq00IbEVvBxlj2vTI/EOMHu8W57Y68Ek3irksvcu+G7CnON4fEIBFzCMwy9g==', N'fbc9780c-147b-4902-90bc-e196574c6a25', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ab1d7d60-3863-4956-ac71-ff3bf256d235', N'guest@vidly.com', 0, N'AMpT7qDxRcbDbZbcitwmpZIhB8/nfHUwuXorz/yLO0Qe5MeYDUgMbR1DHQZ5xjbOqQ==', N'6eb053f5-2bd0-45aa-b744-aa5e28f4bcc1', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd0ab9f58-30bc-4fff-83c9-a69f79b3431a', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'559d30c3-7701-40a5-9bb5-c4bec1de58ef', N'd0ab9f58-30bc-4fff-83c9-a69f79b3431a')

");
        }
        
        public override void Down()
        {
        }
    }
}
