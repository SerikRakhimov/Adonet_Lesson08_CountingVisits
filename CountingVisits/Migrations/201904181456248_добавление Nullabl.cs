namespace CountingVisits.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class добавлениеNullabl : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visits", "DateOut", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visits", "DateOut", c => c.DateTime(nullable: false));
        }
    }
}
