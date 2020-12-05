using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers
{
    public class RestuarantPOSOrderDetailsController : ApiController
    {
        WFramework.POS.ClsRestuarantPOSOrderDetails objOrderDetails = new WFramework.POS.ClsRestuarantPOSOrderDetails();


        //Get top 1000 All OrderDetails ///
        [Route("RestuarantOrderDetails/GetRestuarantOrderDetails")]
        [HttpGet]
        public string GetRestuarantOrderDetails()
        {
            try
            {

                string GetRestuarantOrderDetails = objOrderDetails.getRestuarantOrderDetails(1, 0, 0, 0, 0, "", 0, "", "", "", 0, "", "", "", "", 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (GetRestuarantOrderDetails == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return GetRestuarantOrderDetails;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All RestuarantOrderDetails by outlet ID///
        [Route("RestuarantOrderDetails/readRestuarantOrderDetailsbyoutletID")]
        [HttpPost]
        public string readRestuarantOrderDetailsbyoutletID(int intOutletID)
        {
            try
            {

                string readRestuarantOrderDetailsbyoutletID = objOrderDetails.getRestuarantOrderDetails(2, 0, 0, 0, 0, "", 0, "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0, 1, 0, 0, "", 0, "");

                if (readRestuarantOrderDetailsbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantOrderDetailsbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add RestuarantOrderDetails /////

        [Route("RestuarantOrderDetails/createRestuarantOrderDetails")]
        [HttpPost]
        public string createRestuarantOrderDetails(int intOrderID, int intFoodCategoryID, int intFoodMenuID, string strPrice, int intQuantity, string strDiscount, string strTotalAmount, string strOrderStatus, int intOrderStatusValue, string strCouponCode, string strCouponAmount, string strLoyaltyPoints, string strLoyaltyAmount, int intTempOne, string strTempTwo, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {
                string readOrderDetails = objOrderDetails.getRestuarantOrderDetails(2, 0, 0, 0, 0, "", 0, "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0, 1, 0, 0, "", 0, "");
                JArray objtJSON = JArray.Parse(readOrderDetails);
                int OrderId = 0;
                int FoodId = 0;
                int intOrderDetailsID = 0;
                for (int i = 0; i < readOrderDetails.Count(); i++)
                {
                    OrderId = Convert.ToInt32(objtJSON[0]["OrderID"]);
                    FoodId = Convert.ToInt32(objtJSON[0]["FoodMenuID"]);

                    if (intOrderID == OrderId && intFoodMenuID == FoodId)
                    {
                        int updateRestuarantOrderDetails = objOrderDetails.manageRestuarantOrderDetails(4, intOrderDetailsID, intOrderID, intFoodCategoryID, intFoodMenuID, strPrice, intQuantity, strDiscount, strTotalAmount, strOrderStatus, intOrderStatusValue, strCouponCode, strCouponAmount, strLoyaltyPoints, strLoyaltyAmount, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                        if (updateRestuarantOrderDetails == 0)
                        {
                            return "Order Details updated successfully";
                        }
                        else
                        {
                            return "Error occured either component or strore Procedure";
                        }
                    }
                }
                int insertOrderDetails = objOrderDetails.manageRestuarantOrderDetails(3, 0, intOrderID, intFoodCategoryID, intFoodMenuID, strPrice, intQuantity, strDiscount, strTotalAmount, strOrderStatus, intOrderStatusValue, strCouponCode, strCouponAmount, strLoyaltyPoints, strLoyaltyAmount, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertOrderDetails == 0)
                {
                    return "Order Details added successfully";
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


        //Update RestuarantOrderDetails/////
        [Route("RestuarantOrderDetails/updateRestuarantOrderDetails")]
        [HttpPost]
        public string updateRestuarantOrderDetails(int intOrderDetailsID, int intOrderID, int intFoodCategoryID, int intFoodMenuID, string strPrice, int intQuantity, string strDiscount, string strTotalAmount, string strOrderStatus, int intOrderStatusValue, string strCouponCode, string strCouponAmount, string strLoyaltyPoints, string strLoyaltyAmount, int intTempOne, string strTempTwo, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateRestuarantOrderDetails = objOrderDetails.manageRestuarantOrderDetails(4, intOrderDetailsID, intOrderID, intFoodCategoryID, intFoodMenuID, strPrice, intQuantity, strDiscount, strTotalAmount, strOrderStatus, intOrderStatusValue, strCouponCode, strCouponAmount, strLoyaltyPoints, strLoyaltyAmount, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateRestuarantOrderDetails == 0)
                {
                    return "Order Details updated successfully";
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



        //Delete RestuarantOrderDetails /////
        [Route("RestuarantOrderDetails/deleteRestuarantOrderDetails")]
        [HttpPost]
        public string deleteRestuarantOrderDetails(int intOrderDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteRestuarantOrderDetailsByID = objOrderDetails.manageRestuarantOrderDetails(6, intOrderDetailsID, 0, 0, 0, "", 0, "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteRestuarantOrderDetailsByID == 0)
                {
                    return "Order Details  deleted successfully";
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

        //Get All Order RestuarantOrderDetails  by ID///
        [Route("RestuarantOrderDetails/editByRestuarantOrderDetailsID")]
        [HttpPost]
        public string editByRestuarantOrderDetailsID(int intOrderDetailsID)
        {
            try
            {

                string editByRestuarantOrderDetailsID = objOrderDetails.getRestuarantOrderDetails(7, intOrderDetailsID, 0, 0, 0, "", 0, "", "", "", 0, "", "", "", "", 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByRestuarantOrderDetailsID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByRestuarantOrderDetailsID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //deActive Status of RestuarantOrderDetails /////
        [Route("RestuarantOrderDetails/activeStatusRestuarantOrderDetailsDeActive")]
        [HttpPost]
        public string activeStatusRestuarantOrderDetailsDeActive(int intOrderDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusRestuarantOrderDetailsDeActive = objOrderDetails.manageRestuarantOrderDetails(5, intOrderDetailsID, 0, 0, 0, "", 0, "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusRestuarantOrderDetailsDeActive == 0)
                {
                    return "Restuarant Order Details  DeActivated successfully";
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



        //Active Status RestuarantOrderDetails /////
        [Route("RestuarantOrderDetails/activeStatusRestuarantOrderDetails")]
        [HttpPost]
        public string activeStatusRestuarantOrderDetails(int intOrderDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusRestuarantOrderDetails = objOrderDetails.manageRestuarantOrderDetails(9, intOrderDetailsID, 0, 0, 0, "", 0, "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusRestuarantOrderDetails == 0)
                {
                    return "Restuarant Order Details  Activated successfully";
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
