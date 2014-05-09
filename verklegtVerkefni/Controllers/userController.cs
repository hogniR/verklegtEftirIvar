using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using verklegtVerkefni.Models;
using verklegtVerkefni.RepoClasses;

namespace verklegtVerkefni.Controllers
{
    public class userController : Controller
    {
        userRepository repository = new userRepository();
        public ActionResult logIn()
        {
            return View(new logIn());
        }
        public ActionResult register()
        {
            return View(new users());
        }
        [HttpPost]
        public ActionResult register(FormCollection form)
        {
            users newItem = new users();
            UpdateModel(newItem);
            repository.addNewUser(newItem);
            repository.save();
            return RedirectToAction("Index", "Home");
        }
	}
}