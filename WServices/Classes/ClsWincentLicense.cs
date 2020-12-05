using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WServices.Classes
{
    public class ClsWincentLicense
    {

        public int SC_LicenseId { get; set; }
        public int SC_CustomerId { get; set; }
    
        public string SC_License_Name { get; set; }
        public string SC_Limit { get; set; }
    }
}