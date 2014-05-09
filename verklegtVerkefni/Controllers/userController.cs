using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            return View();
        }
        [HttpPost]
        public ActionResult logIn(logIn info)
        {
            var user = repository.getUserByName(info.userName);
            if(user != null)
            {
                var pw = (from pw in repository.getAllUsers()
                          where password.userName == info.userName
                          select password.password).SingleOrDefault();
               varresult = (from request in repository.getAllRequests()
                            orderby request.dateOfPost descending
                            select request).Take(10);
            }
            else
            {

                Debug.WriteLine("not a valid user");
            }
            
            return RedirectToAction("Index", "Home");
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