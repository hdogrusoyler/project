using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project.Models
{
    public class MenuItem
    {
        public string Value { get; set; }
        public string Text { get; set; }
    }

    public class ActionValue
    {
        public int ParentId { get; set; }
        public int HierarchyId { get; set; }
    }

   

    

   

}