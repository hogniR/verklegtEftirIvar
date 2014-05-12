using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using verklegtVerkefni.Models;
using verklegtVerkefni.RepoClasses;

namespace verklegtVerkefni.Controllers
{
    public class fileController : Controller
    {
        filesRepository repository = new filesRepository();
        public ActionResult uploadFile()
        {
            return View(new files());
        }
        [HttpPost]
        public ActionResult uploadFile(files infoForFile, HttpPostedFileBase uploadFile)
        {
            string content = null;
            if(uploadFile.ContentLength > 0)
            {
                using (StreamReader sr = new StreamReader(uploadFile.InputStream))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        content += line;
                        //content += '\n';
                    }
                }
                infoForFile.content = content;
                repository.addNewFile(infoForFile);
            }
            
            return RedirectToAction("Index", "Home");
        }
    }
}
