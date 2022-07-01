﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_Web_SellClothes.Models;

namespace DoAn_Web_SellClothes.Areas.Admin.Controllers
{
    
    public class StatisticalController : Controller
    {
        // GET: Admin/Statistical
        DataClasses1DataContext db = new DataClasses1DataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Statistical()
        {
            ViewBag.Receiptcount = Receiptcount();
            ViewBag.Customercount = Customercount();
            ViewBag.Productcount = Productcount();
            ViewBag.SexMen = SexMen();
            ViewBag.TotalInvoid = TotalInvoid();
            ViewBag.StatusInvoic = StatusInvoic();
            ViewBag.rStatusInvoic = rStatusInvoic();
            ViewBag.paidf = paidInvoic();
            ViewBag.paidr = rpaidInvoic();
            return View();
        }
        private int Customercount()
        {
           var count = db.Accounts.OrderByDescending(s => s.IdAccount).Count();
            return count;
        }
        private int Productcount()
        {
            var count = db.Products.OrderByDescending(s => s.IdProduct).Count();
            return count;
        }
        private int Receiptcount()
        {
            var count = db.Invoices.OrderByDescending(s => s.IdInvoice).Count();
            return count;
        }
        private int SexMen()
        {
            var count = db.ProductTypes.OrderByDescending(s => s.IdProductType).Count();
            return count;
        }
        private int TotalInvoid()
        {
            int tong = 0;
            var count = db.Invoices.OrderByDescending(s => s.TotalInvoice).Count();
            foreach(var item in db.Invoices)
            {
                tong = tong + item.TotalInvoice;
            }
            return tong;
        }
        private int StatusInvoic()
        {
            bool a = false;
            var count = (from s in db.Invoices where s.StatusInvoice == a select s).Count();
            //var count = db.Invoices.OrderByDescending(s => s.StatusInvoice = a).Count();
            return count;
        }
        private int rStatusInvoic()
        {
            bool a = true;
            var count = (from s in db.Invoices where s.StatusInvoice == a select s).Count();
            //var count = db.Invoices.OrderByDescending(s => s.StatusInvoice = a).Count();
            return count;
        }
        private int paidInvoic()
        {
            bool a = false;
            var count = (from s in db.Invoices where s.Paid == a select s).Count();
            //var count = db.Invoices.OrderByDescending(s => s.StatusInvoice = a).Count();
            return count;
        }
        private int rpaidInvoic()
        {
            bool a = true;
            var count = (from s in db.Invoices where s.Paid == a select s).Count();
            //var count = db.Invoices.OrderByDescending(s => s.StatusInvoice = a).Count();
            return count;
        }
    }
}