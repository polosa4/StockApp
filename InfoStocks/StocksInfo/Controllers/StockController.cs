using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StocksInfo.DAL;
using StocksInfo.Models;
using HtmlAgilityPack;

namespace StocksInfo.Controllers
{
    public class StockController : Controller
    {
        private StockContext db = new StockContext();

        // GET: StockModels
        public ActionResult Index([Bind(Include = "ID,Ticker,Company,Sector,Industry,Country,MarketCap,Price,Change,Volume")] StockModel betterStocks)
        {
            using (var context = new StockContext())
            {
                context.Database.ExecuteSqlCommand("delete from StockModels");
            }
            var stocksModel2 = new List<StockModel>();
            StockModel oStocksModel;
            HtmlWeb hw = new HtmlWeb();
            HtmlDocument htmlDoc = hw.Load("https://finviz.com/screener.ashx?v=111&f=sec_technology,targetprice_a50");
            oStocksModel = new StockModel();
            HtmlNodeCollection cols = htmlDoc.DocumentNode.SelectNodes("//td//a");
            for (int j = 47; j < 267; j += 11)
            {
                oStocksModel.CompanyID = cols[j].InnerText;
                oStocksModel.Ticker = cols[j + 1].InnerText;
                oStocksModel.Company = cols[j + 2].InnerText;
                oStocksModel.Sector = cols[j + 3].InnerText;
                oStocksModel.Industry = cols[j + 4].InnerText;
                oStocksModel.Country = cols[j + 5].InnerText;
                oStocksModel.MarketCap = cols[j + 6].InnerText;
                oStocksModel.Price = cols[j + 8].InnerText;
                oStocksModel.Change = cols[j + 9].InnerText;
                oStocksModel.Volume = cols[j + 10].InnerText;

                if (ModelState.IsValid)
                {
                    db.StockData.Add(oStocksModel);
                    db.SaveChanges();
                }

            }
                     
            return View(db.StockData.ToList());
        }

        // GET: StockModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockModel stockModel = db.StockData.Find(id);
            if (stockModel == null)
            {
                return HttpNotFound();
            }
            return View(stockModel);
        }

        // GET: StockModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StockModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyID,Ticker,Company,Sector,Industry,Country,MarketCap,Price,Change,Volume")] StockModel stockModel)
        {
            if (ModelState.IsValid)
            {
                db.StockData.Add(stockModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stockModel);
        }

        // GET: StockModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockModel stockModel = db.StockData.Find(id);
            if (stockModel == null)
            {
                return HttpNotFound();
            }
            return View(stockModel);
        }

        // POST: StockModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyID,Ticker,Company,Sector,Industry,Country,MarketCap,Price,Change,Volume")] StockModel stockModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stockModel);
        }

        // GET: StockModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockModel stockModel = db.StockData.Find(id);
            if (stockModel == null)
            {
                return HttpNotFound();
            }
            return View(stockModel);
        }

        // POST: StockModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockModel stockModel = db.StockData.Find(id);
            db.StockData.Remove(stockModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
