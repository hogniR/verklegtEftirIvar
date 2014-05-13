using System;
using verklegtVerkefni.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using verklegtVerkefni.RepoClasses;

namespace verklegtVerkefni.Controllers
{
    public class HomeController : Controller
    {
        filesRepository repository = new filesRepository();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult instructions()
        {
            return View();
        }
        public ActionResult information()
        {
            return View();
        }
    }
}