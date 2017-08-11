using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StocksInfo.Models
{
    public class StockModel
    {
        public int ID { get; set; }
        public string CompanyID { get; set; }
        public string Ticker { get; set; }
        public string Company { get; set; }
        public string Sector { get; set; }
        public string Industry { get; set; }
        public string Country { get; set; }
        public string MarketCap { get; set; }
        public string Price { get; set; }
        public string Change { get; set; }
        public string Volume { get; set; }
    }
}