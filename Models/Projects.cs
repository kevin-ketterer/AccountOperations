using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Text;
//using System.IO;
//using System.Data.SqlClient;
//using System.Data;

namespace AccountOperations.Models
{
    public class Projects
    {
        public int projectId { get; set; }
        public String projectName { get; set; }
        public String projectDesc { get; set; }
        public DateTime projectBeginDate { get; set; }
        public DateTime projectEndDate { get; set; }
        public int lastUpdatedBy { get; set; }
        public DateTime lastUpdatedTime { get; set; }
    }
}