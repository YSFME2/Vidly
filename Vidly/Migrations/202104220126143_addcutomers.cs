namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcutomers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Youssef',1,1)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Mustafa',0,2)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Wafaa',1,2)");
            Sql("INSERT INTO Customers (Name,IsSubscribedToNewsLetter,MembershipTypeId) VALUES ('Ahmed',1,3)");
        }
        
        public override void Down()
        {
        }
    }
}
