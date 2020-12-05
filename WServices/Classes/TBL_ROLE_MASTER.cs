using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WServices.ClassCode
{
    public class TBL_ROLE_MASTER
    {
        public TBL_ROLE_MASTER()
        {
            //this.TBL_HMS_DOCTOR_MASTER = new HashSet<TBL_HMS_DOCTOR_MASTER>();
            //this.TBL_USER_LOGIN_INFO = new HashSet<TBL_USER_LOGIN_INFO>();
        }

        public short ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public string IS_ACTIVE { get; set; }
        public string CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public string MODIFIED_BY { get; set; }
        public Nullable<System.DateTime> MODIFIED_DATE { get; set; }

        //public virtual ICollection<TBL_HMS_DOCTOR_MASTER> TBL_HMS_DOCTOR_MASTER { get; set; }
        //public virtual ICollection<TBL_USER_LOGIN_INFO> TBL_USER_LOGIN_INFO { get; set; }
    }
}