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
        [Authorize]
        [HttpPost]
        public ActionResult uploadFile(files infoForFile, HttpPostedFileBase uploadFile)
        {
            
            if (uploadFile != null)
            {
                string content = null;
                using (StreamReader sr = new StreamReader(uploadFile.InputStream, Encoding.Default, true))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        content += line + "@";
                    }
                }
                infoForFile.name = infoForFile.name.ToLower();
                infoForFile.content = content;
                repository.addNewFile(infoForFile);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public FileStreamResult downloadFile(int? id)
        {
            var fileToDownload = repository.getFileById(id.Value);
            var content = fileToDownload.content;
            content = content.Replace("@", System.Environment.NewLine);
            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", fileToDownload.name + "(" + fileToDownload.language + ")" + ".txt");
        }
        public ActionResult searchResults(FormCollection form)
        {
            search newItem = new search();
            UpdateModel(newItem);
            if(newItem.searchTerms == null)
            {
                IEnumerable<files> result = (from s in repository.getAllFiles()
                                             orderby s.name
                                             select s);
                return View(result);
            }
            else
            {
                IEnumerable<files> result = (from s in repository.getAllFiles()
                                             where s.name.ToLower().StartsWith(newItem.searchTerms)
                                             orderby s.name
                                             select s);
                return View(result);
            }
        }
        [HttpPost]
        public ActionResult addLike(int? id)
        {
            if(id.HasValue)
            {
                files fileToChange = repository.getFileById(id.Value);
                fileToChange.likes = fileToChange.likes + 1;
                repository.save();
                return Json(fileToChange.likes, JsonRequestBehavior.AllowGet);
            }
            return View();
            
        }
        public ActionResult listOfFiles()
        {
            IEnumerable<files> result = (from files in repository.getAllFiles()
                                         orderby files.dateOfPost descending
                                         select files).Take(10);
            return View(result);
        }
        public ActionResult listOfPopular()
        {
            IEnumerable<files> result = (from files in repository.getAllFiles()
                                         orderby files.likes descending
                                         select files).Take(10);

            return View(result);
        }
    }
}
