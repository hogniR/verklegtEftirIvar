using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using verklegtVerkefni.Models;
using verklegtVerkefni.RepoClasses;

namespace verklegtVerkefni.Controllers
{
    public class popularController : Controller
    {
        requestsRepository repository = new requestsRepository();
        //
        // GET: /popular/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult popular()
        {
            DataContext db = new DataContext();
            IEnumerable<Requests> result = (from request in repository.getAllRequests()
                                            orderby request.likes descending
                                            select request).Take(10);
            return View(result);
        }

        public ActionResult popular(int? id)
        {
            var popular = repository.getRequestByid(id.Value);

            if (popular != null)
            {
                return View(popular);
            }
            return View("Error");
        }
	}
}