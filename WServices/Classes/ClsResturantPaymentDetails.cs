using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WServices.Classes
{
    public class ClsResturantPaymentDetails
    {
        public int OrderID { get; set; }
        public int OrderPaymentType { get; set; }
        public int CardType { get; set; }
        public string PayAmount { get; set; }
        public string TwoT { get; set; }
        public string FiveH { get; set; }
        public string TwoH { get; set; }
        public string OneH { get; set; }
        public string Fifty { get; set; }
        public string Twenty { get; set; }
        public string Ten { get; set; }
    }
}