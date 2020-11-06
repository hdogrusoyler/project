using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class dataContext : DbContext
    {
        public dataContext() : base("categoryConnection")
        {
        }
        public DbSet<user> Users { get; set; }
        public DbSet<category> Categories { get; set; }
    }
}