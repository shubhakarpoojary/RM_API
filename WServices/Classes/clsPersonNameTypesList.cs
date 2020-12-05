using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WServices.Classes;

namespace WServices.Classes
{
    public class clsPersonNameTypesList
    {
        public int id { get; set; }
        public string text { get; set; }
        public StatusOfjsTree state { get; set; }
        public List<clsPersonNameTypesList> children { get; set; }
    }
}


