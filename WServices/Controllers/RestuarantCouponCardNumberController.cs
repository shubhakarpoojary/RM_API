using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class RestuarantCouponCardNumberController : ApiController
    {

        WFramework.Masters.ClsRestuarantCouponCardNumberMaster objCouponCardNumber = new WFramework.Masters.ClsRestuarantCouponCardNumberMaster();

        //Get top 1000 All CouponCardNumberMaster ///
        [Route("RestuarantCouponCardNumber/readCouponCardNumberMaster")]
        [HttpGet]
        public string readCouponCardNumberMaster()
        {
            try
            {

                string readCouponCardNumberMaster = objCouponCardNumber.getCouponCardNumber(1, 0,"","",0,0,"","",0,0,0,0,0,"",0,"");

                if (readCouponCardNumberMaster == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readCouponCardNumberMaster;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }
        //Get All CouponCardNumber by outlet ID///
        [Route("RestuarantCouponCardNumber/readCouponCardNumberbyoutletID")]
        [HttpPost]
        public string readCouponCardNumberbyoutletID(int intOutletID, int intKitchenID)
        {
            try
            {

                string readCouponCardNumberbyoutletID = objCouponCardNumber.getCouponCardNumber(2, 0,"","",0,0,"","", intOutletID, intKitchenID, 0, 0, 0, "", 0, "");

                if (readCouponCardNumberbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readCouponCardNumberbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add CouponCardNumber/////

        [Route("RestuarantCouponCardNumber/createCouponCardNumber")]
        [HttpPost]
        public string createCouponCardNumber(string strCouponCode, string strCouponNumber, int intIsUsed, int intUsedBy, string strUsedDate, string UsedAmount,  int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int createCouponCardNumber = objCouponCardNumber.manageCouponCardNumber(3, 0, strCouponCode, strCouponNumber, intIsUsed, intUsedBy, strUsedDate, UsedAmount , intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (createCouponCardNumber == 0)
                {
                    return "Coupon Card Number added successfully";
                }
                else if (createCouponCardNumber == -1)
                {
                    return "Coupon Card Number already exist";
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


        //Update CouponCardNumber/////
        [Route("RestuarantCouponCardNumber/updateCouponCardNumber")]
        [HttpPost]
        public string updateCouponCardNumber(int intCouponCardNumberID, string strCouponCode, string strCouponNumber, int intIsUsed, int intUsedBy, string strUsedDate, string UsedAmount, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateCouponCardNumber = objCouponCardNumber.manageCouponCardNumber(4, intCouponCardNumberID, strCouponCode, strCouponNumber, intIsUsed, intUsedBy, strUsedDate, UsedAmount, intOutletID, intKitchenID, 1,0, intCreatedBy, "", intModifiedBy, "");
                if (updateCouponCardNumber == 0)
                {
                    return "CouponCardNumber updated successfully";
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



        //Delete CouponCardNumber/////
        [Route("RestuarantCouponCardNumber/deleteCouponCardNumber")]
        [HttpPost]
        public string deleteCouponCardNumber(int intCouponCardNumberID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteCouponCardNumberByID = objCouponCardNumber.manageCouponCardNumber(6, intCouponCardNumberID,"","",0,0,"","", intOutletID, intKitchenID, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteCouponCardNumberByID == 0)
                {
                    return "Coupon Card Number deleted successfully";
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

        //Get All CouponCardNumber by ID///
        [Route("RestuarantCouponCardNumber/editByCouponCardNumberID")]
        [HttpPost]
        public string editByCouponCardNumberID(int intCouponCardNumberID)
        {
            try
            {

                string editByCouponCardNumberID = objCouponCardNumber.getCouponCardNumber(7, intCouponCardNumberID, "", "", 0,0, "", "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByCouponCardNumberID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByCouponCardNumberID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of CouponCardNumber/////
        [Route("RestuarantCouponCardNumber/activeStatusCouponCardNumber")]
        [HttpPost]
        public string activeStatusCouponCardNumber(int intCouponCardNumberID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusCouponMaster = objCouponCardNumber.manageCouponCardNumber(11, intCouponCardNumberID, "", "",0, 0, "", "",  intOutletID, intKitchenID,1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusCouponMaster == 0)
                {
                    return "Coupon Card Status Category Activated successfully";
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

        //DEActive Status of CouponCardNumber/////
        [Route("RestuarantCouponCardNumber/deactiveStatusCouponCardNumber")]
        [HttpPost]
        public string deactiveStatusCouponCardNumber(int intCouponCardNumberID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusCouponMaster = objCouponCardNumber.manageCouponCardNumber(5, intCouponCardNumberID, "", "", 0, 0, "", "", intOutletID, intKitchenID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusCouponMaster == 0)
                {
                    return "Coupon Card Status Category Deactivated successfully";
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

        //edit  Used Coupon  ByCouponCardNumber by ID///
        [Route("RestuarantCouponCardNumber/editUsedCouponByCouponCardNumberID")]
        [HttpPost]
        public string editUsedCouponByCouponCardNumberID(int intCouponCardNumberID,int intOutletID)
        {
            try
            {

                string editUsedCouponByCouponCardNumberID = objCouponCardNumber.getCouponCardNumber(7, intCouponCardNumberID, "", "", 0, 0, "", "", intOutletID, 0, 1, 0, 0, "", 0, "");

                if (editUsedCouponByCouponCardNumberID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editUsedCouponByCouponCardNumberID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

    }
}
