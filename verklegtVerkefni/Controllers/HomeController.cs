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
        // þetta fall skilar index viewinu
        public ActionResult Index()
        {
            return View();
        }
        // þetta fall skilar leiðbeininga viewiu
        public ActionResult instructions()
        {
            return View();
        }
        // þetta fall skilar hafa samband viewinu
        public ActionResult information()
        {
            return View();
        }
    }
}