using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StocksInfo.Models;
using System.Data.Entity;

namespace StocksInfo.DAL
{
    public class StockContext:DbContext 
    {
        public DbSet<StockModel> StockData  { get; set; }
    }
}