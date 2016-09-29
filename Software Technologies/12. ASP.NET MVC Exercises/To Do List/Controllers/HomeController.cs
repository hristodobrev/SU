﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _12.ASP.NET_MVC_Exercises.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var items = (List<string>) this.Session["items"] ?? new List<string>();

            return View(items);
        }

        public ActionResult AddItem(string newItem)
        {
            var items = (List<string>) this.Session["items"] ?? new List<string>();
            items.Add(newItem);
            this.Session["items"] = items;

            return this.RedirectToAction("Index");
        }

        public ActionResult RemoveItem(int index)
        {
            var items = (List<string>)this.Session["items"];
            if (items != null && index < items.Count)
            {
                items.RemoveAt(index);
                this.Session["items"] = items;
            }

            return this.RedirectToAction("Index");
        }
    }
}