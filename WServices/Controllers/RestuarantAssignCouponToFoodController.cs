using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.AssignScreens
{
    public class RestuarantAssignCouponToFoodController : ApiController
    {
        WFramework.AssignScreens.ClsRestuarantAssignCouponToFoodMenu objAssignCoupon = new WFramework.AssignScreens.ClsRestuarantAssignCouponToFoodMenu();



        //Get top 1000 All AssignCoupon ///
        [Route("RestuarantAssignCouponToFood/readAssignCouponDetail")]
        [HttpGet]
        public string readAssignCouponDetail()
        {
            try
            {

                string readAssignCouponDetail = objAssignCoupon.getAssignCouponToFoodMenu(1,0,0,0,0,0,"",0,0,0,"",0,"");

                if (readAssignCouponDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readAssignCouponDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All AssignCoupons by outlet ID///
        [Route("RestuarantAssignCouponToFood/readAssignCouponsDetailbyoutletID")]
        [HttpPost]
        public string readAssignCouponsDetailbyoutletID( int intOutletID)
        {
            try
            { 

                string readAssignCouponsDetailbyoutletID = objAssignCoupon.getAssignCouponToFoodMenu(2, 0,0, intOutletID, 0,0,"", 0, 0, 0, "", 0, "");

                if (readAssignCouponsDetailbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readAssignCouponsDetailbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add AssignCoupons  /////

        [Route("RestuarantAssignCouponToFood/createAssignCoupons")]
        [HttpPost]
        public string createAssignCoupons(int intCouponID, int intOutletID, int intFoodMenuID, int intTempOne, string strTempTwo, int intCreatedBy, int intModifiedBy)
        {
            try
            {
                string readAssignCouponsDetailbyoutletID = objAssignCoupon.getAssignCouponToFoodMenu(2, 0, 0, intOutletID, 0, 0, "", 0, 0, 0, "", 0, "");

                JArray objtJSON = JArray.Parse(readAssignCouponsDetailbyoutletID);
                int intAssignCouponToFoodMenandOuletID = Convert.ToInt32(objtJSON[0]["AssignCouponToFoodMenandOuletID"]);

                if(readAssignCouponsDetailbyoutletID=="" || readAssignCouponsDetailbyoutletID == null)
                {
                    int insertAssignCouponsdetail = objAssignCoupon.manageAssignCouponToFoodMenu(3, 0, intCouponID, intOutletID, intFoodMenuID, intTempOne, strTempTwo, 1, 0,intCreatedBy, "", intModifiedBy, "");
                    if (insertAssignCouponsdetail == 0)
                    {
                        return "Coupon Assigned successfully";
                    }
                    else if (insertAssignCouponsdetail == -1)
                    {
                        return "Coupon Assigned already exist";
                    }
                    else
                    {
                        return "Error occured either component or strore Procedure";
                    }
                }
                else
                {
                    int updateCouponAssigned = objAssignCoupon.manageAssignCouponToFoodMenu(4, intAssignCouponToFoodMenandOuletID, intCouponID, intOutletID, intFoodMenuID, intTempOne, strTempTwo, 1, 0, intCreatedBy, "", intModifiedBy, "");
                    if (updateCouponAssigned == 0)
                    {
                        return "Coupon Assigned updated successfully";
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


        ////Update Coupon Assigned/////
        //[Route("updateCouponAssigned")]
        //[HttpPost]
        //public string updateCouponAssigned(int intAssignCouponToFoodMenandOuletID,int intCouponID, int OutletID, int intFoodMenuID, int intTempOne, string strTempTwo)
        //{
        //    try
        //    {

        //        int updateCouponAssigned = objAssignCoupon.manageAssignCouponToFoodMenu(4, intAssignCouponToFoodMenandOuletID, intCouponID, OutletID, intFoodMenuID, intTempOne, strTempTwo, 1, 1, 0, "", 0, "");
        //        if (updateCouponAssigned == 0)
        //        {
        //            return "Coupon Assigned updated successfully";
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



        //Delete CouponAssigned /////
        [Route("RestuarantAssignCouponToFood/deleteCouponAssigned")]
        [HttpPost]
        public string deleteCouponAssigned(int intAssignCouponToFoodMenandOuletID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteCouponAssignedByID = objAssignCoupon.manageAssignCouponToFoodMenu(6, intAssignCouponToFoodMenandOuletID, 0, intOutletID,0,0,"", 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteCouponAssignedByID == 0)
                {
                    return "Coupon Assigned  deleted successfully";
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

        //Get All CouponAssigned  by ID///
        [Route("RestuarantAssignCouponToFood/editByCouponAssignedID")]
        [HttpPost]
        public string editByCouponAssignedID(int intAssignCouponToFoodMenandOuletID)
        {
            try
            {

                string editByCouponAssignedID = objAssignCoupon.getAssignCouponToFoodMenu(7, intAssignCouponToFoodMenandOuletID, 0, 0,0,0,"", 1, 0, 0, "", 0, "");

                if (editByCouponAssignedID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByCouponAssignedID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of activeStatusAssignCoupon /////
        [Route("RestuarantAssignCouponToFood/activeStatusAssignCoupon")]
        [HttpPost]
        public string activeStatusAssignCoupon(int intAssignCouponToFoodMenandOuletID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusAssignCoupon = objAssignCoupon.manageAssignCouponToFoodMenu(9, intAssignCouponToFoodMenandOuletID, 0, intOutletID,0,0,"",1,0, intCreatedBy,"", intModifiedBy, "");

                if (activeStatusAssignCoupon == 0)
                {
                    return "AssignCoupons Activated successfully";
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
        //Active Status of activeStatusAssignCoupon /////
        [Route("RestuarantAssignCouponToFood/deactiveStatusAssignCoupon")]
        [HttpPost]
        public string deactiveStatusAssignCoupon(int intAssignCouponToFoodMenandOuletID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusAssignCoupon = objAssignCoupon.manageAssignCouponToFoodMenu(5, intAssignCouponToFoodMenandOuletID, 0, intOutletID, 0, 0, "",0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusAssignCoupon == 0)
                {
                    return "AssignCoupons deActivated successfully";
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
