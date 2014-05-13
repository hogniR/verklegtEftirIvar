using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace verklegtVerkefni.Models
{
    public class Requests
    {
        public int id { get; set; }
        [Display(Name = "Nafn")]
        public string name { get; set; }
        [Display(Name = "Lýsing")]
        public string comment { get; set; }
        [Display(Name = "Tungumál")]
        public string language { get; set; }
        [Display(Name = "Dagsetning")]
        public DateTime dateOfPost { get; set; }
        public int likes { get; set; }
        public int status { get; set; }
        public Requests()
        {
            dateOfPost = DateTime.Now;
        }
    }
}