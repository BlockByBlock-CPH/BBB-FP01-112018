namespace BlockByBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mtc_Activity",
                c => new
                    {
                        Id_act = c.Int(nullable: false, identity: true),
                        Zone_act = c.Int(nullable: false),
                        Count_act = c.Int(nullable: false),
                        Hours_act = c.Int(nullable: false),
                        Days_act = c.String(),
                    })
                .PrimaryKey(t => t.Id_act);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Mtc_Activity");
        }
    }
}