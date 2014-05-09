using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verklegtVerkefni.Models
{
    public class Requests
    {
        public int id { get; set; }
        public string name { get; set; }
        public string comment { get; set; }
        public string language { get; set; }
        public DateTime dateOfPost { get; set; }
        public int likes { get; set; }
        public Requests()
        {
            dateOfPost = DateTime.Now;
        }
    }
}