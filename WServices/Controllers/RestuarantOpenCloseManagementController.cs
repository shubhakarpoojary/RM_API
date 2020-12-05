using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers
{
    public class RestuarantOpenCloseManagementController : ApiController
    {
        WFramework.POS.ClsRestuarantOpenCloseManagement objOpenCloseInfo = new WFramework.POS.ClsRestuarantOpenCloseManagement();


        //Get top 1000 All RestuarantOpenCloseManagement ///
        [Route("RestuarantOpenCloseManagement/readRestuarantOpenCloseManagement")]
        [HttpGet]
        public string readRestuarantOpenCloseManagement()
        {
            try
            {

                string readRestuarantOpenCloseManagement = objOpenCloseInfo.getRestuarantOpenCloseManagement(1, 0, "", "", 0, "", 0, 0, 0, 0, 0, "", 0, "");

                if (readRestuarantOpenCloseManagement == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantOpenCloseManagement;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All RestuarantOpenCloseManagement by outlet ID///
        [Route("RestuarantOpenCloseManagement/readRestuarantOpenClosebyoutletID")]
        [HttpPost]
        public string readRestuarantOpenClosebyoutletID(int intOutletID)
        {
            try
            {

                string readRestuarantOpenClosebyoutletID = objOpenCloseInfo.getRestuarantOpenCloseManagement(2, 0, "", "", 0, "", intOutletID, 0, 0, 0, 0, "", 0, "");

                if (readRestuarantOpenClosebyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantOpenClosebyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add RestuarantOpenCloseManagement /////

        [Route("RestuarantOpenCloseManagement/createRestuarantOpenClose")]
        [HttpPost]
        public string createRestuarantOpenClose(string strOpeningBalance, string strClosingBalance, int intTempOne, string strTempTwo, int intOutletID, int intKitchenID
       , int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertRestuarantOpenClose = objOpenCloseInfo.manageRestuarantOpenCloseManagement(3, 0, strOpeningBalance, strClosingBalance, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertRestuarantOpenClose == 0)
                {
                    return "RestuarantOpenCloseInfoDetail added successfully";
                }
                else if (insertRestuarantOpenClose == -1)
                {
                    return "RestuarantOpenCloseInfoDetail already exist";
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


        //Update RestuarantOpenCloseManagement /////
        [Route("RestuarantOpenCloseManagement/updateRestuarantOpenClose")]
        [HttpPost]
        public string updateRestuarantOpenClose(int intOpenCloseMnagementID, string strOpeningBalance, string strClosingBalance, int intTempOne, string strTempTwo, int intOutletID, int intKitchenID
       , int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateRestuarantOpenClose = objOpenCloseInfo.manageRestuarantOpenCloseManagement(4, intOpenCloseMnagementID, strOpeningBalance, strClosingBalance, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateRestuarantOpenClose == 0)
                {
                    return "RestuarantOpenCloseManagement Info detail updated successfully";
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



        //Delete RestuarantOpenCloseManagement Info /////
        [Route("RestuarantOpenCloseManagement/deleteRestuarantOpenCloseInfo")]
        [HttpPost]
        public string deleteRestuarantOpenCloseInfo(int intOpenCloseMnagementID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteRestuarantOpenCloseInfo = objOpenCloseInfo.manageRestuarantOpenCloseManagement(6, intOpenCloseMnagementID, "", "", 0, "", intOutletID, 0, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteRestuarantOpenCloseInfo == 0)
                {
                    return "RestuarantOpenClose Info   deleted successfully";
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

        //Get All RestuarantOpenCloseManagement  by ID///
        [Route("RestuarantOpenCloseManagement/editByRestuarantOpenCloseInfoID")]
        [HttpPost]
        public string editByRestuarantOpenCloseInfoID(int intOpenCloseMnagementID)
        {
            try
            {

                string editByRestuarantOpenCloseInfoID = objOpenCloseInfo.getRestuarantOpenCloseManagement(7, intOpenCloseMnagementID, "", "", 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByRestuarantOpenCloseInfoID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByRestuarantOpenCloseInfoID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of RestuarantOpenCloseManagement /////
        [Route("RestuarantOpenCloseManagement/activeStatusRestuarantOpenCloseInfo")]
        [HttpPost]
        public string activeStatusRestuarantOpenCloseInfo(int intOpenCloseMnagementID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusRestuarantOpenCloseInfo = objOpenCloseInfo.manageRestuarantOpenCloseManagement(9, intOpenCloseMnagementID, "", "", 0, "", intOutletID, 0, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusRestuarantOpenCloseInfo == 0)
                {
                    return "RestuarantOpenCloseManagement  Activated successfully";
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

        //deActive Status of RestuarantOpenCloseManagement /////
        [Route("RestuarantOpenCloseManagement/deactiveStatusRestuarantOpenCloseInfo")]
        [HttpPost]
        public string deactiveStatusRestuarantOpenCloseInfo(int intOpenCloseMnagementID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusRestuarantOpenCloseInfo = objOpenCloseInfo.manageRestuarantOpenCloseManagement(5, intOpenCloseMnagementID, "", "", 0, "", intOutletID, 0, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusRestuarantOpenCloseInfo == 0)
                {
                    return "RestuarantOpenCloseInfo  DeActivated successfully";
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
