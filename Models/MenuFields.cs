using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AccountOperations.Models
{
    public class MenuFields
    {
        public String menuName { get; set; }
        public String fieldName{ get; set; }
        public int seqNumber { get; set; }
        public String lovDesc { get; set; }
        public int lastUpdatedBy { get; set; }
        public DateTime lastUpdatedTime { get; set; }
        //public SelectList DropDownList { get; set; }
    }
}