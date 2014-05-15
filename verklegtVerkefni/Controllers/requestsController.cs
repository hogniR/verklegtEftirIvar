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
        // þetta fall sér til þess að þegar verið er að senda inn nýja beiðni að allir
        // reitir séu tómir. Þetta er get fall
        public ActionResult newRequest()
        {
            return View(new Requests());
        }
        // hér er svo POST fallið fyrir nýja beiðni. Það sendir upplýsingarnar
        // inn í gagnagrunninn og vistar þær.
        [HttpPost]
        public ActionResult newRequest(FormCollection form)
        {
            Requests newItem = new Requests();
            UpdateModel(newItem);
            repository.addNewRequest(newItem);
            repository.save();
            return RedirectToAction("listOfRequests", "requests");
        }
        // þetta fall skilar öllum beiðnum sem eru í gagnagrunninum og birtast þær allar
        // í beiðna viewinu
        public ActionResult listOfRequests()
        {
            IEnumerable<Requests> result = (from request in repository.getAllRequests()
                                            orderby request.dateOfPost descending
                                            select request);
            return View(result);
        }
        // þetta fall gerir notanda kleift að skoða einstaka beiðni nánar. Þar getur hann
        // séð nafn, athugasemnd, tungumál og hvenær beiðninni var bætt inn.
        public ActionResult viewRequest(int? id)
        {
            var viewRequest = repository.getRequestById(id.Value);
            
            if(viewRequest != null)
            {
                return View(viewRequest);
            }
            return View("Error");
        }
        // þetta fall talar við ajax scriptu í listi af vinsælustu, nýjustu og heildar 
        // lista af beiðnum og gerir notenda kleift að adda like-i á beiðni
        [HttpPost]
        public ActionResult addLike(int? id)
        {
            if (id.HasValue)
            {
                Requests fileToChange = repository.getRequestById(id.Value);
                fileToChange.likes = fileToChange.likes + 1;
                repository.save();
                return Json(fileToChange.likes, JsonRequestBehavior.AllowGet);
            }
            return View();

        }
	}
}