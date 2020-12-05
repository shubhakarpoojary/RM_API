using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WServices.Classes
{
    public class clsTabConfiguration
    {
        
        public int ModuleID { get; set; }
        public int SubModuleID { get; set; }
        public int RoleID { get; set; }
        public int TabID { get; set; }
        public int Status { get; set; }
        public int IsActive { get; set; }
        public int BranchID { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
        public string TabName { get; set; }
        public int ConfigurationTab { get; set; }
        public Boolean selected { get; set; }
    }
}