using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WServices.ClassCode
{
    public class AssignRoles
    {
        public short ROLE_ID { get; set; }
        public short MODULE_ID { get; set; }
        public List<AssignSubrole> SubMenu { get; set; }
    }
    public class AssignSubrole
    {
        public string SUBMODULE_ID { get; set; }

    }
    public class RoleWiseAccess
    {
        public int ROLE_ACCESS_ID { get; set; }
        public int ROLE_ID { get; set; }
        public int MODULE_ID { get; set; }
        public int SUBMODULE_ID { get; set; }
        public bool READ_ACCESS { get; set; }
        public bool WRITE_ACCESS { get; set; }
        public bool DELETE_ACCESS { get; set; }
        public bool UPDATE_ACCESS { get; set; }
        public bool EXPORT_ACCESS { get; set; }
        public bool IMPORT_ACCESS { get; set; }

        public string SUBMODULE_NAME { get; set; }
        public int OUTLET_ID { get; set; }
    }
    public class RoleWiseSubModule
    {
        public int MODULE_ID { get; set; }
        public int SUBMODULE_ID { get; set; }
        public string SUBMODULE_NAME { get; set; }

    }
    public class RoleWiseModule
    {

        public int MODULE_ID { get; set; }
        public string MODULE_NAME { get; set; }
    }
    public class AssignPermissionRoleWise
    {
        public int ROLE_ID { get; set; }
        public string ROLE_NAME { get; set; }
        public List<RoleWiseModule> RlCModule { get; set; }
        public List<RoleWiseSubModule> RlCSModule { get; set; }
        public List<RoleWiseAccess> lRoleAccess { get; set; }



    }
}