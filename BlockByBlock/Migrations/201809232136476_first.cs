namespace BlockByBlock.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Mtc_Activity");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Mtc_Activity",
                c => new
                    {
                        Id_act = c.Int(nullable: false, identity: true),
                        Zone_act = c.Int(nullable: false),
                        Count_act = c.Int(nullable: false),
                        Hours_act = c.String(),
                        Days_act = c.String(),
                    })
                .PrimaryKey(t => t.Id_act);
            
        }
    }
}
