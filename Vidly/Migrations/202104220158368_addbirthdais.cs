namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbirthdais : DbMigration
    {
        public override void Up()
        {
            Sql($"UPDATE Customers SET BirthDate = '{DateTime.Now.ToString("yyyy-MM-dd")}' WHERE ID = 1");
            Sql($"UPDATE Customers SET BirthDate = '{DateTime.Now.ToString("yyyy-MM-dd")}' WHERE ID = 3");
        }
        
        public override void Down()
        {
        }
    }
}
