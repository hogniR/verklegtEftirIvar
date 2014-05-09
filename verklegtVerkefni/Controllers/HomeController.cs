using System;
using verklegtVerkefni.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace verklegtVerkefni.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           //DataContext db = new DataContext();
           //var requests = from request in db.requests where request.id == 10 select request;
           
            return View();
        }

        public ActionResult listOfRequests()
        {
            return View();
        }

    }
}