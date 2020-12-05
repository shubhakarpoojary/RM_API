using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class KitchenInfoController : ApiController
    {

        WFramework.Masters.ClsKitchenInfoMaster objKitchenInfo = new WFramework.Masters.ClsKitchenInfoMaster();


        //Get top 1000 All Outletinfo ///
        [Route("KitchenInfo/readKitcheninfoDetail")]
        [HttpGet]
        public string readKitcheninfoDetail()
        {
            try
            {

                string readKitcheninfoDetail = objKitchenInfo.getKitchenInfo(1,0,"",0,0,"",0,0,0,"",0,"");

                if (readKitcheninfoDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readKitcheninfoDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All KitchenInfo by outlet ID///
        [Route("KitchenInfo/readKitchenInfobyoutletID")]
        [HttpPost]
        public string readKitchenInfobyoutletID(int intOutletID)
        {
            try
            {

                string readKitchenInfobyoutletID = objKitchenInfo.getKitchenInfo(2,0,"", intOutletID,0,"",0,0,0,"",0,"");

                if (readKitchenInfobyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readKitchenInfobyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add KitchenInfoDetail /////

        [Route("KitchenInfo/createKitchenInfoDetail")]
        [HttpPost]
        public string createKitchenInfoDetail(string strKitchenName, int intOutletID, int intTempOne, string strTempTwo, int intCreatedBy, int intModifiedBy
        )
        {
            try
            {

                int insertKitchenInfoDetail = objKitchenInfo.manageKitchenInfo(3, 0, strKitchenName, intOutletID, intTempOne, strTempTwo, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertKitchenInfoDetail == 0)
                {
                    return "insertKitchenInfoDetail added successfully";
                }
                else if (insertKitchenInfoDetail == -1)
                {
                    return "KitchenInfoDetail already exist";
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


        //Update KitchenInfoDetail /////
        [Route("KitchenInfo/updateKitchenInfo")]
        [HttpPost]
        public string updateKitchenInfo(int intKitchenInfoID, string strKitchenName, int intOutletID, int intTempOne, string strTempTwo
        , int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateKitchenInfo = objKitchenInfo.manageKitchenInfo(4, intKitchenInfoID, strKitchenName, intOutletID, intTempOne, strTempTwo, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateKitchenInfo == 0)
                {
                    return "KitchenInfo detail updated successfully";
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



        //Delete KitchenInfo  /////
        [Route("KitchenInfo/deleteKitchenInfo")]
        [HttpPost]
        public string deleteKitchenInfo(int intKitchenInfoID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteKitchenInfo = objKitchenInfo.manageKitchenInfo(6, intKitchenInfoID,"", intOutletID, 0,"",1,1,intCreatedBy,"",intModifiedBy,"");

                if (deleteKitchenInfo == 0)
                {
                    return "Kitchen Info  deleted successfully";
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

        //Get All KitchenInfo  by ID///
        [Route("KitchenInfo/editByKitchenInfoID")]
        [HttpPost]
        public string editByKitchenInfoID(int intKitchenInfoID, int intOutletID)
        {
            try
            {

                string editByKitchenInfoID = objKitchenInfo.getKitchenInfo(7, intKitchenInfoID, "", intOutletID,0,"",1,0,0,"",0,"");

                if (editByKitchenInfoID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByKitchenInfoID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //deActive Status of KitchenInfo /////
        [Route("KitchenInfo/deactiveStatusKitchenInfo")]
        [HttpPost]
        public string deactiveStatusKitchenInfo(int intKitchenInfoID,int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int DeactiveStatusKitchenInfo = objKitchenInfo.manageKitchenInfo(5, intKitchenInfoID, "", intOutletID, 0,"",0,0,intCreatedBy,"",intModifiedBy,"");

                if (DeactiveStatusKitchenInfo == 0)
                {
                    return "KitchenInfo  DeActivated successfully";
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

    

        //Active Status of KitchenInfo /////
        [Route("KitchenInfo/activeStatusKitchenInfo")]
        [HttpPost]
        public string activeStatusKitchenInfo(int intKitchenInfoID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusKitchenInfo = objKitchenInfo.manageKitchenInfo(9, intKitchenInfoID, "", intOutletID, 0, "", 1, 0,intCreatedBy, "", intModifiedBy, "");

                if (activeStatusKitchenInfo == 0)
                {
                    return "KitchenInfo  Activated successfully";
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
