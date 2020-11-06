using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public int topCategoryId { get; set; }
    }
}