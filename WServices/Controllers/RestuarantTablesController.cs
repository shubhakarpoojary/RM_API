using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class RestuarantTablesController : ApiController
    {

        WFramework.Masters.ClsRestuarantTablesMaster objPaymentRestTables = new WFramework.Masters.ClsRestuarantTablesMaster();

        //Get top 1000 All RestuarantTables ///
        [Route("RestuarantTables/readRestuarantTablesDetail")]
        [HttpGet]
        public string readRestuarantTablesDetail()
        {
            try
            {

                string readRestuarantTablesDetail = objPaymentRestTables.getRestuarantTables(1, 0,"",0,"","",0,0,"",0,0,0,0,"",0,"");

                if (readRestuarantTablesDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantTablesDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All RestuarantTables by outlet ID///
        [Route("RestuarantTables/readRestuarantTablesbyoutletID")]
        [HttpPost]
        public string readRestuarantTablesbyoutletID( int intOutletID)
        {
            try
            {

                string readRestuarantTablesbyoutletID = objPaymentRestTables.getRestuarantTables(2, 0, "",0, "","",0,0,"", intOutletID, 0, 0, 0, "", 0, "");

                if (readRestuarantTablesbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantTablesbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add RestuarantTablesDetail /////

        [Route("RestuarantTables/createRestuarantTables")]
        [HttpPost]
        public string createRestuarantTables(string strTableName, int intTableSeatCapacity, string strTablePosition,string strTableDescription,int IsSharable,int intTempOne,string strTempTwo,
        int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertRestuarantTables = objPaymentRestTables.manageRestuarantTables(3, 0, strTableName, intTableSeatCapacity, strTablePosition, strTableDescription, IsSharable, intTempOne, strTempTwo, intOutletID, 1,0, intCreatedBy, "", intModifiedBy, "");
                if (insertRestuarantTables == 0)
                {
                    return "RestuarantTablesDetail added successfully";
                }
                else if (insertRestuarantTables == -1)
                {
                    return "RestuarantTablesDetail already exist";
                }
                else
                {
                    return "Error occured either component or strore Procedure";
                }


            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        //Update RestuarantTablesDetail /////
        [Route("RestuarantTables/updateRestuarantTables")]
        [HttpPost]
        public string updateRestuarantTables(int intTableNameID, string strTableName, int intTableSeatCapacity, string strTablePosition, string strTableDescription,int IsSharable, int intTempOne, string strTempTwo,
        int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateRestuarantTables = objPaymentRestTables.manageRestuarantTables(4, intTableNameID, strTableName, intTableSeatCapacity, strTablePosition, strTableDescription, IsSharable, intTempOne, strTempTwo, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateRestuarantTables == 0)
                {
                    return "Restuarant Tables detail updated successfully";
                }
                else
                {
                    return "Error occured either component or strore Procedure";
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Delete Restuarant Tables /////
        [Route("RestuarantTables/deleteRestuarantTable")]
        [HttpPost]
        public string deleteRestuarantTable(int intTableNameID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteRestuarantTable = objPaymentRestTables.manageRestuarantTables(6, intTableNameID, "",0, "","",0,0,"", intOutletID, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteRestuarantTable == 0)
                {
                    return "Restuarant Table  deleted successfully";
                }
                else
                {
                    return "Error occured either component or strore Procedure";
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Get All RestuarantTable  by ID///
        [Route("RestuarantTables/editByRestuarantTableID")]
        [HttpPost]
        public string editByRestuarantTableID(int intTableNameID)
        {
            try
            {

                string editByRestuarantTableID = objPaymentRestTables.getRestuarantTables(7, intTableNameID, "",0, "","",0, 0, "", 0, 1, 0, 0, "", 0, "");

                if (editByRestuarantTableID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByRestuarantTableID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of RestuarantTable /////
        [Route("RestuarantTables/activeStatusRestuarantTable")]
        [HttpPost]
        public string activeStatusRestuarantTable(int intTableNameID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusPaymentMethod = objPaymentRestTables.manageRestuarantTables(9, intTableNameID, "",0,"", "",0,0,"", intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusPaymentMethod == 0)
                {
                    return "PaymentCardType  Activated successfully";
                }
                else
                {
                    return "Error occured either component or strore Procedure";
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //deActive Status of RestuarantTable /////
        [Route("RestuarantTables/deactiveStatusRestuarantTable")]
        [HttpPost]
        public string deactiveStatusRestuarantTable(int intTableNameID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusPaymentMethod = objPaymentRestTables.manageRestuarantTables(5, intTableNameID, "", 0, "", "", 0, 0, "", intOutletID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusPaymentMethod == 0)
                {
                    return "PaymentCardType  deActivated successfully";
                }
                else
                {
                    return "Error occured either component or strore Procedure";
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }
    }
}
