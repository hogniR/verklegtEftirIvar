using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verklegtVerkefni.Models
{
    public class files
    {
        public int id { get; set; }
        public string name { get; set; }
        public int series { get; set; }
        public int episode { get; set; }
        public string language { get; set; }
        public string content { get; set; }
        public int likes { get; set; }
        public DateTime dateOfPost { get; set; }
        public files ()
        {
            dateOfPost = DateTime.Now;
        }
    }
}