using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class RestuarantCouponController : ApiController
    {
        WFramework.Masters.ClsResturantCouponMaster objCouponMaster = new WFramework.Masters.ClsResturantCouponMaster();

        //Get top 1000 All CouponMaster ///
        [Route("RestuarantCoupon/readCouponMasterDetail")]
        [HttpGet]
        public string readCouponMasterDetail()
        {
            try
            {

                string readCouponMasterDetail = objCouponMaster.getCouponInfo(1, 0,"","","","","","","",0,0,0,0,0,"",0,"");

                if (readCouponMasterDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readCouponMasterDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All CouponMaster by outlet ID///
        [Route("RestuarantCoupon/readCouponMasterbyoutletID")]
        [HttpPost]
        public string readCouponMasterbyoutletID( int intOutletID, int intKitchenID)
        {
            try
            {

                string readCouponMasterbyoutletID = objCouponMaster.getCouponInfo(2, 0,"","","","","","", "", intOutletID, intKitchenID, 0, 0, 0, "", 0, "");

                if (readCouponMasterbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readCouponMasterbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add CouponMaster/////

        [Route("RestuarantCoupon/createCouponMaster")]
        [HttpPost]
        public string createCouponMaster(string strNumberOfCoupons,string strStartDate, string strEndDate, string strDiscType, string strAmount, string strCouponNoStartWith, string  strDescription, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int createCouponMaster = objCouponMaster.manageCouponInfo(3, 0, strNumberOfCoupons, strStartDate, strEndDate, strDiscType, strAmount, strCouponNoStartWith, strDescription,  intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (createCouponMaster == 0)
                {
                    return "CouponMaster added successfully";
                }
                else if (createCouponMaster == -1)
                {
                    return "CouponMaster already exist";
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


        //Update CouponMaster/////
        [Route("RestuarantCoupon/updateCouponMaster")]
        [HttpPost]
        public string updateCouponMaster(int intCouponID, string strNumberOfCoupons, string strStartDate, string strEndDate, string strDiscType, string strAmount, string strCouponNoStartWith, string strDescription, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateCouponMaster = objCouponMaster.manageCouponInfo(4, intCouponID, strNumberOfCoupons, strStartDate, strEndDate, strDiscType, strAmount, strCouponNoStartWith, strDescription, intOutletID, intKitchenID, 1, 0,intCreatedBy, "", intModifiedBy, "");
                if (updateCouponMaster == 0)
                {
                    return "CouponMaster updated successfully";
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



        //Delete CouponMaster/////
        [Route("RestuarantCoupon/deleteCouponMaster")]
        [HttpPost]
        public string deleteCouponMaster(int intCouponID,  int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteCouponMasterByID = objCouponMaster.manageCouponInfo(6, intCouponID, "", "","","","","","",  intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (deleteCouponMasterByID == 0)
                {
                    return "Coupon Master deleted successfully";
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

        //Get All CouponMaster by ID///
        [Route("RestuarantCoupon/editByCouponMasterID")]
        [HttpPost]
        public string editByCouponMasterID(int intCouponID)
        {
            try
            {

                string editByCouponMasterID = objCouponMaster.getCouponInfo(7, intCouponID, "", "","","","","","", 0, 0, 1, 0, 0, "", 0, "");

                if (editByCouponMasterID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByCouponMasterID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of CouponMaster/////
        [Route("RestuarantCoupon/activeStatusCouponMaster")]
        [HttpPost]
        public string activeStatusCouponMaster(int intCouponID,  int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusCouponMaster = objCouponMaster.manageCouponInfo(9, intCouponID,"","","","","", "", "", intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusCouponMaster == 0)
                {
                    return "Coupon Status Category Activated successfully";
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
        //deActive Status of CouponMaster/////
        [Route("RestuarantCoupon/deactiveStatusCouponMaster")]
        [HttpPost]
        public string deactiveStatusCouponMaster(int intCouponID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusCouponMaster = objCouponMaster.manageCouponInfo(5, intCouponID, "", "", "", "", "", "", "", intKitchenID, intOutletID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusCouponMaster == 0)
                {
                    return "Coupon Status Category DeActivated successfully";
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
