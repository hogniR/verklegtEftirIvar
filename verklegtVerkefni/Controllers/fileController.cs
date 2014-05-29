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
        // þetta fall gerir notenda kleift að upphala skrá. Það notar HttpPostedFileBase til
        // að sækja skránna sem verið er að upphala og notar svo streamreader til þess að
        // lesa skránna línu fyrir línu og setja inn í breytu sem er svo skilað í gagnagrunn 
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
                var type = uploadFile.ContentType;
                if (type == "text/plain" || type == "application/octet-stream")
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
                return View();
            }
            else
            {
                return View();
            }
        }
        // þetta fall gerir notenda kleift að niðurhala skrá með því að smella á hlekk
        // fyrir myndina eða þáttinn. Fallið tekur inn eina færibreytu sem er ID á myndinni
        // eða þættinum. Það smíðar svo skrá úr strengnum í gagnagrunninum og skilar henni ut
        public FileStreamResult downloadFile(int? id)
        {
            var fileToDownload = repository.getFileById(id.Value);
            var content = fileToDownload.content;
            content = content.Replace("@", System.Environment.NewLine);
            var byteArray = Encoding.UTF8.GetBytes(content);
            var stream = new MemoryStream(byteArray);

            return File(stream, "text/plain", fileToDownload.name + "(" + fileToDownload.language + ")" + ".srt");
        }
        // þetta fall skilar leitarniðurstöðum af leitarorði sem slegið er inn í 
        // leitarboxið á forsíðunni. Það notar formcollection og ef leitarorðið er ekkert
        // þá skilar þetta öllum skrám á síðunni en ef eitthvað er slegið inn er leitað
        // af öllum skrám sem byrja á það sama og leitarorðið
        [HttpGet]
        public ActionResult editFile(int? id)
        {
            var result = repository.getFileById(id.Value);
            if(result != null)
            {
                result.content = result.content.Replace("@", System.Environment.NewLine);
                return View(result);
            }
            return View("Error");
        }
        [HttpPost]
        public ActionResult editFile(int? id, FormCollection form)
        {
            files newItem = repository.getFileById(id.Value);
            UpdateModel(newItem);
            newItem.content = newItem.content.Replace(System.Environment.NewLine, "@");
            newItem.content += "@";
            repository.updateFile(newItem);
            return RedirectToAction("searchResults");
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
                var search = newItem.searchTerms.ToLower();
                IEnumerable<files> result = (from s in repository.getAllFiles()
                                             where s.name.ToLower().StartsWith(search)
                                             orderby s.name
                                             select s);
                return View(result);
            }
        }
        // kallað er á þetta fall í gegnum searchresult viewið í gegnum ajax scriptu.
        // þetta nær í like fyrir ákveðinn file með ákveðnu ID-i og hækkar það um einn
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
        // þetta fall skilar lista af 10 nýjustu skrám sem eru í gagnagrunninum
        public ActionResult listOfFiles()
        {
            IEnumerable<files> result = (from files in repository.getAllFiles()
                                         orderby files.dateOfPost descending
                                         select files).Take(10);
            return View(result);
        }
        // þetta fall skilar lista af 10 vinsælustu skrám í gagnagrunninum
        public ActionResult listOfPopular()
        {
            IEnumerable<files> result = (from files in repository.getAllFiles()
                                         orderby files.likes descending
                                         select files).Take(10);

            return View(result);
        }
    }
}
