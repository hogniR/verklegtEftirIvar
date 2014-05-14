using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using verklegtVerkefni.Models;
using verklegtVerkefni.RepoClasses;

namespace verklegtVerkefni.Controllers
{
    public class requestsController : Controller
    {
        requestsRepository repository = new requestsRepository();

        public ActionResult newRequest()
        {
            return View(new Requests());
        }
        [HttpPost]
        public ActionResult newRequest(FormCollection form)
        {
            Requests newItem = new Requests();
            UpdateModel(newItem);
            repository.addNewRequest(newItem);
            repository.save();
            return RedirectToAction("listOfRequests", "requests");
        }

        public ActionResult listOfRequests()
        {
            IEnumerable<Requests> result = (from request in repository.getAllRequests()
                                            orderby request.dateOfPost descending
                                            select request).Take(10);
            return View(result);
        }
        public ActionResult viewRequest(int? id)
        {
            var viewRequest = repository.getRequestByid(id.Value);
            
            if(viewRequest != null)
            {
                return View(viewRequest);
            }
            return View("Error");
        }
        public ActionResult popular()
        {
            DataContext db = new DataContext();
            IEnumerable<Requests> result = (from request in repository.getAllRequests()
                                            orderby request.likes descending
                                            select request).Take(10);
            return View(result);
        }
	}
}