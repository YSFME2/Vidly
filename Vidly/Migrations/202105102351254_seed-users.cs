namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'cec750e3-d7b5-4feb-a17b-0d45bd0b8a83', N'guest@vidly.com', 0, N'ACAN/ovHzVLH8w0mtmT3Ek2NK3rgk5Vnz2G5DcgZzJkBfiJEkw1lGkuCUY1uC411dQ==', N'240b6799-6d1a-4299-8abc-3830cc9ec99f', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6102ee6c-b896-4a20-88a3-7a392603ebee', N'admin@vidly.com', 0, N'ACAN/ovHzVLH8w0mtmT3Ek2NK3rgk5Vnz2G5DcgZzJkBfiJEkw1lGkuCUY1uC411dQ==', N'3f1eedc2-bea0-4278-ab18-a5d335114088', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'79074ece-9c18-4274-8af5-30927475b235', N'" + App_Code.RoleName.CanManageMovies + @"')


INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6102ee6c-b896-4a20-88a3-7a392603ebee', N'79074ece-9c18-4274-8af5-30927475b235')

");
        }
        
        public override void Down()
        {
        }
    }
}
