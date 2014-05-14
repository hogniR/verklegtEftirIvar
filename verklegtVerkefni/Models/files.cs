using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace verklegtVerkefni.Models
{
    public class files
    {
        public int id { get; set; }
        [Display(Name = "Nafn")]
        public string name { get; set; }
        [Display(Name = "Númer seríu")]
        public int series { get; set; }
        [Display(Name = "Númer þáttar")]
        public int episode { get; set; }
        [Display(Name = "Tungumál")]
        public string language { get; set; }
        [Display(Name = "Heyrnarskert/ur")]
        public bool deaf { get; set; }
        public string content { get; set; }
        public int likes { get; set; }
        public DateTime dateOfPost { get; set; }
        public files ()
        {
            dateOfPost = DateTime.Now;
        }
    }
}