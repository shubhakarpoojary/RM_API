using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers
{
    public class RestuarantPOSOrderController : ApiController
    {

        WFramework.POS.ClsRestuarantPOSOrder objPOSOrder = new WFramework.POS.ClsRestuarantPOSOrder();


        //Get top 1000 All Order ///
        [Route("RestuarantPOSOrder/GetRestuarantPOSOrder")]
        [HttpGet]
        public string GetRestuarantPOSOrder()
        {
            try
            {

                string GetRestuarantPOSOrder = objPOSOrder.getRestuarantPOSOrder(1, 0, "", "", 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", "", "", "", 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (GetRestuarantPOSOrder == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return GetRestuarantPOSOrder;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All RestuarantPOSOrder by outlet ID///
        [Route("RestuarantPOSOrder/readRestuarantPOSOrderbyoutletID")]
        [HttpPost]
        public string readRestuarantPOSOrderbyoutletID(int intOutletID)
        {
            try
            {

                string readRestuarantPOSOrderbyoutletID = objPOSOrder.getRestuarantPOSOrder(2, 0, "", "", 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0, 1, 0, 0, "", 0, "");

                if (readRestuarantPOSOrderbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantPOSOrderbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add RestuarantPOSOrder /////

        [Route("RestuarantPOSOrder/createRestuarantPOSOrder")]
        [HttpPost]
        public string createRestuarantPOSOrder(string strOrderCode, string strOrderType, int intOrderTypeValue, int intWaiter, int intCustomerID, int intTableID, string strSubTotal, string strDisCount, string strServiceOrDeliveryCharge, string strTotalPayable, string strGivenAmount, string strChangeAmount, string strDueAmount, string strOrderStatus, int intOrderStatusValue, string strCouponCode, string strCouponAmount, string strLoyaltyPoints, string strLoyaltyAmount, int intTempOne, string strTempTwo, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertRestuarantPOSOrder = objPOSOrder.manageRestuarantPOSOrder(3, 0, strOrderCode, strOrderType, intOrderTypeValue, intWaiter, intCustomerID, intTableID, strSubTotal, strDisCount, strServiceOrDeliveryCharge, strTotalPayable, strGivenAmount, strChangeAmount, strDueAmount, strOrderStatus, intOrderStatusValue, strCouponCode, strCouponAmount, strLoyaltyPoints, strLoyaltyAmount, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertRestuarantPOSOrder == 0)
                {
                    return "Order Placed successfully";
                }
                else if (insertRestuarantPOSOrder == -1)
                {
                    return "Order Details already exist";
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


        //Update RestuarantPOSOrder/////
        [Route("RestuarantPOSOrder/updatePOSRestuarantOrder")]
        [HttpPost]
        public string updatePOSRestuarantOrder(int intOrderID, string strOrderCode, string strOrderType, int intOrderTypeValue, int intWaiter, int intCustomerID, int intTableID, string strSubTotal, string strDisCount, string strServiceOrDeliveryCharge, string strTotalPayable, string strGivenAmount, string strChangeAmount, string strDueAmount, string strOrderStatus, int intOrderStatusValue, string strCouponCode, string strCouponAmount, string strLoyaltyPoints, string strLoyaltyAmount, int intTempOne, string strTempTwo, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updatePOSRestuarantOrder = objPOSOrder.manageRestuarantPOSOrder(4, intOrderID, strOrderCode, strOrderType, intOrderTypeValue, intWaiter, intCustomerID, intTableID, strSubTotal, strDisCount, strServiceOrDeliveryCharge, strTotalPayable, strGivenAmount, strChangeAmount, strDueAmount, strOrderStatus, intOrderStatusValue, strCouponCode, strCouponAmount, strLoyaltyPoints, strLoyaltyAmount, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updatePOSRestuarantOrder == 0)
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



        //Delete RestuarantPOSOrder /////
        [Route("RestuarantPOSOrder/deleteRestuarantPOSOrder")]
        [HttpPost]
        public string deleteRestuarantPOSOrder(int intOrderID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteRestuarantPOSOrderByID = objPOSOrder.manageRestuarantPOSOrder(6, intOrderID, "", "", 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteRestuarantPOSOrderByID == 0)
                {
                    return "Restuarant POS Order deleted successfully";
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

        //Get All Order RestuarantPOSOrder  by ID///
        [Route("RestuarantPOSOrder/editByRestuarantPOSOrderID")]
        [HttpPost]
        public string editByRestuarantPOSOrderID(int intOrderID)
        {
            try
            {

                string editByRestuarantPOSOrderID = objPOSOrder.getRestuarantPOSOrder(7, intOrderID, "", "", 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", "", "", "", 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByRestuarantPOSOrderID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByRestuarantPOSOrderID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //deActive Status of RestuarantPOSOrder /////
        [Route("RestuarantPOSOrder/deactiveStatusRestuarantPOSOrder")]
        [HttpPost]
        public string deactiveStatusRestuarantPOSOrder(int intOrderID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusRestuarantPOSOrder = objPOSOrder.manageRestuarantPOSOrder(5, intOrderID, "", "", 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusRestuarantPOSOrder == 0)
                {
                    return "Restuarant Order DeActivated successfully";
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



        //Active Status RestuarantPOSOrder /////
        [Route("RestuarantPOSOrder/activeRestuarantPOSOrder")]
        [HttpPost]
        public string activeRestuarantPOSOrder(int intOrderID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeRestuarantPOSOrder = objPOSOrder.manageRestuarantPOSOrder(9, intOrderID, "", "", 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, "", "", "", "", 0, "", intOutletID, 0,1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeRestuarantPOSOrder == 0)
                {
                    return "Restuarant Order Activated successfully";
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

        //Hold Status RestuarantPOSOrder /////
        [Route("RestuarantPOSOrder/OrderStausRestuarantPOSOrder")]
        [HttpPost]
        public string OrderStausRestuarantPOSOrder(int intOrderID, int intOrderStatusValue, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int OrderStausRestuarantPOSOrder = objPOSOrder.manageRestuarantPOSOrder(10, intOrderID, "", "", 0, 0, 0, 0, "", "", "", "", "", "", "", "", intOrderStatusValue, "", "", "", "", 0, "", intOutletID, 0, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (OrderStausRestuarantPOSOrder == 0)
                {
                    return "Restuarant Order Status Changed successfully";
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


        //Get All Order RestuarantPOSOrder  by Hold///
        [Route("RestuarantPOSOrder/editByRestuarantPOSOrderStatusValue")]
        [HttpPost]
        public string editByRestuarantPOSOrderStatusValue(int intOrderID, int intOrderStatusValue)
        {
            try
            {

                string editByRestuarantPOSOrderStatusValue = objPOSOrder.getRestuarantPOSOrder(11, intOrderID, "", "", 0, 0, 0, 0, "", "", "", "", "", "", "", "", intOrderStatusValue, "", "", "", "", 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByRestuarantPOSOrderStatusValue == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByRestuarantPOSOrderStatusValue;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


    }
}
