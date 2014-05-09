using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace verklegtVerkefni.Models
{
    public class newRequestDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string comment { get; set; }
        public string language { get; set; }
        public DateTime dateOfRequest { get; set; }

        public newRequestDTO()
        {
            dateOfRequest = DateTime.Now;
        }
    }
}