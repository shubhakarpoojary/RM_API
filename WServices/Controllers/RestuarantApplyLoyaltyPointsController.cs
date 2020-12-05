using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.AssignScreens
{
    public class RestuarantApplyLoyaltyPointsController : ApiController
    {

        WFramework.AssignScreens.ClsRestuarantApplyLoyaltyPoints objApplyLoyaltyPoints = new WFramework.AssignScreens.ClsRestuarantApplyLoyaltyPoints();



        //Get top 1000 All ApplyLoyaltyPoints ///
        [Route("RestuarantApplyLoyaltyPoints/readApplyLoyaltyPointsDetail")]
        [HttpGet]
        public string readApplyLoyaltyPointsDetail()
        {
            try
            {

                string readApplyLoyaltyPointsDetail = objApplyLoyaltyPoints.getApplyLoyaltyPoints(1,0,0,0,"", 0, 0, 0, "", 0, "");

                if (readApplyLoyaltyPointsDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readApplyLoyaltyPointsDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All ApplyLoyaltyPoints by outlet ID///
        [Route("RestuarantApplyLoyaltyPoints/readApplyLoyaltyPointsbyoutletID")]
        [HttpPost]
        public string readApplyLoyaltyPointsbyoutletID(int intOutletID)
        {
            try
            {

                string readApplyLoyaltyPointsbyoutletID = objApplyLoyaltyPoints.getApplyLoyaltyPoints(2, 0, intOutletID, 0,  "", 0,0, 0, "", 0, "");

                if (readApplyLoyaltyPointsbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readApplyLoyaltyPointsbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add ApplyLoyaltyPoints  /////

        [Route("RestuarantApplyLoyaltyPoints/createApplyLoyaltyPoints")]
        [HttpPost]
        public string createApplyLoyaltyPoints(int intOutletID, int intFoodMenuID, string strLoyaltyPoints, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                string readApplyLoyaltyPointsbyoutletID = objApplyLoyaltyPoints.getApplyLoyaltyPoints(2, 0, intOutletID, 0, "", 0, 0, 0, "", 0, "");

                JArray objtJSON = JArray.Parse(readApplyLoyaltyPointsbyoutletID);
                int intApplyLoyaltyPointsToFoodMenuID = Convert.ToInt32(objtJSON[0]["ApplyLoyaltyPointsToFoodMenuID"]);

                if (readApplyLoyaltyPointsbyoutletID == null || readApplyLoyaltyPointsbyoutletID == "")
                {
                    int insertApplyLoyaltyPoints = objApplyLoyaltyPoints.manageApplyLoyaltyPoints(3, 0, intOutletID, intFoodMenuID, strLoyaltyPoints, 1, 0, intCreatedBy, "", intModifiedBy, "");

                    if (insertApplyLoyaltyPoints == 0)
                    {
                        return "Loyalty Points Added successfully";
                    }
                    else
                    {
                        return "Error occured either component or strore Procedure";
                    }
                }
                else
                {
                    int updateLoyaltyPoints = objApplyLoyaltyPoints.manageApplyLoyaltyPoints(4, intApplyLoyaltyPointsToFoodMenuID, intOutletID, intFoodMenuID, strLoyaltyPoints, 1, 0, intCreatedBy, "", intModifiedBy, "");
                    if (updateLoyaltyPoints == 0)
                    {
                        return "Loyalty Points updated successfully";
                    }
                    else
                    {
                        return "Error occured either component or strore Procedure";
                    }
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
            return "";
        }


        ////Update LoyaltyPoints/////
        //[Route("updateLoyaltyPoints")]
        //[HttpPost]
        //public string updateLoyaltyPoints(int intApplyLoyaltyPointsToFoodMenuID, int OutletID, int intFoodMenuID, string strLoyaltyPoints)
        //{
        //    try
        //    {

        //        int updateLoyaltyPoints = objApplyLoyaltyPoints.manageApplyLoyaltyPoints(4, intApplyLoyaltyPointsToFoodMenuID, OutletID, intFoodMenuID, strLoyaltyPoints, 1, 1, 0, "", 0, "");
        //        if (updateLoyaltyPoints == 0)
        //        {
        //            return "Loyalty Points updated successfully";
        //        }
        //        else
        //        {
        //            return "Error occured either component or strore Procedure";
        //        }
        //    }

        //    catch (Exception ex)
        //    {
        //        return "Error occured either component or strore Procedure";
        //    }
        //}



        //Delete LoyaltyPoints /////
        [Route("RestuarantApplyLoyaltyPoints/deleteLoyaltyPoints")]
        [HttpPost]
        public string deleteLoyaltyPoints(int intApplyLoyaltyPointsToFoodMenuID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteLoyaltyPointsByID = objApplyLoyaltyPoints.manageApplyLoyaltyPoints(6, intApplyLoyaltyPointsToFoodMenuID, intOutletID, 0, "", 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteLoyaltyPointsByID == 0)
                {
                    return "Loyalty Points deleted successfully";
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

        //Get All AppliedLoyaltyPoints  by ID///
        [Route("RestuarantApplyLoyaltyPoints/editByAppliedLoyaltyPointsID")]
        [HttpPost]
        public string editByAssignTabletoOutletID(int intApplyLoyaltyPointsToFoodMenuID)
        {
            try
            {

                string editByAssignTabletoOutletID = objApplyLoyaltyPoints.getApplyLoyaltyPoints(7, intApplyLoyaltyPointsToFoodMenuID, 0, 0,  "", 1, 0, 0, "", 0, "");

                if (editByAssignTabletoOutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByAssignTabletoOutletID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of activeStatusAppliedLoyaltyPoints /////
        [Route("RestuarantApplyLoyaltyPoints/activeStatusAppliedLoyaltyPoints")]
        [HttpPost]
        public string activeStatusAppliedLoyaltyPoints(int intApplyLoyaltyPointsToFoodMenuID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusAppliedLoyaltyPoints = objApplyLoyaltyPoints.manageApplyLoyaltyPoints(9, intApplyLoyaltyPointsToFoodMenuID, intOutletID, 0,  "",1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusAppliedLoyaltyPoints == 0)
                {
                    return "AppliedLoyaltyPoints Activated successfully";
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

        //deActive Status of activeStatusAppliedLoyaltyPoints /////
        [Route("RestuarantApplyLoyaltyPoints/deactiveStatusAppliedLoyaltyPoints")]
        [HttpPost]
        public string deactiveStatusAppliedLoyaltyPoints(int intApplyLoyaltyPointsToFoodMenuID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusAppliedLoyaltyPoints = objApplyLoyaltyPoints.manageApplyLoyaltyPoints(5, intApplyLoyaltyPointsToFoodMenuID, intOutletID, 0, "",0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusAppliedLoyaltyPoints == 0)
                {
                    return "AppliedLoyaltyPoints deActivated successfully";
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
