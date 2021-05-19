namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class seedcustomerrole : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f392458d-2aa2-449f-9ba6-615135bdbb4a', N'" + App_Code.RoleName.CanManageCustomers + @"');
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6102ee6c-b896-4a20-88a3-7a392603ebee', N'f392458d-2aa2-449f-9ba6-615135bdbb4a');
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'cec750e3-d7b5-4feb-a17b-0d45bd0b8a83', N'79074ece-9c18-4274-8af5-30927475b235');
            ");
        }

        public override void Down()
        {
        }
    }
}
