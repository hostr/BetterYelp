using BetterYelp.Business.Directors;
using BetterYelp.Business.Enums;
using BetterYelp.Data;
using BetterYelp.Models.UnitOfWork;
using BetterYelp.Security;
using BetterYelp.ServiceConnectors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BetterYelp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}