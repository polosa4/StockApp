namespace StocksInfo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StockModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CompanyID = c.String(),
                        Ticker = c.String(),
                        Company = c.String(),
                        Sector = c.String(),
                        Industry = c.String(),
                        Country = c.String(),
                        MarketCap = c.String(),
                        Price = c.String(),
                        Change = c.String(),
                        Volume = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StockModels");
        }
    }
}
