using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace verklegtVerkefni.Models
{
    public class search
    {
        [Display(Name = "Leita að skrá")]
        public string searchTerms { get; set; }
    }
}