using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace verklegtVerkefni.Models
{
    public class DataContext : DbContext
    {
        public DbSet<Requests> requests { get; set; }
        public DbSet<users> users { get; set; }
        public DbSet<files> files { get; set; }
    }
}