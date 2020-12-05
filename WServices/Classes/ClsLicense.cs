using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WServices.Classes
{
    public class ClsLicense
    {
      public int LICENSE_ID { get; set; }
      public int CUSTOMER_ID { get; set; }

      public string LICENSE_NAME { get; set; }
      public string LIMIT { get; set; }
    }
}