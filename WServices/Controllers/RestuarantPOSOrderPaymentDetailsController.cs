using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WServices.Classes;

namespace WServices.Controllers
{
    public class RestuarantPOSOrderPaymentDetailsController : ApiController
    {

        WFramework.POS.ClsRestuarantPOSOrderPaymentDetails objOrderPayment = new WFramework.POS.ClsRestuarantPOSOrderPaymentDetails();
        WFramework.POS.ClsRestuarantPOSOrder objPOSOrder = new WFramework.POS.ClsRestuarantPOSOrder();

        //Get top 1000 All OrderPaymentDetails ///
        [Route("RestuarantOrderPaymentDetails/GetRestuarantOrderPaymentDetails")]
        [HttpGet]
        public string GetRestuarantOrderPaymentDetails()
        {
            try
            {

                string GetRestuarantOrderPaymentDetails = objOrderPayment.getRestuarantOrderPaymentDetails(1, 0, 0, 0, 0, "", "", "", "", "", "", "", "", 0, 0, 1, 0, 0, "", 0, "");

                if (GetRestuarantOrderPaymentDetails == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return GetRestuarantOrderPaymentDetails;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All OrderPaymentDetails by outlet ID///
        [Route("RestuarantOrderPaymentDetails/readRestuarantOrderPaymentDetailsbyoutletID")]
        [HttpPost]
        public string readRestuarantOrderPaymentDetailsbyoutletID(int intOutletID)
        {
            try
            {

                string readRestuarantOrderPaymentDetailsbyoutletID = objOrderPayment.getRestuarantOrderPaymentDetails(2, 0, 0, 0, 0, "", "", "", "", "", "", "", "", intOutletID, 0, 1, 0, 0, "", 0, "");

                if (readRestuarantOrderPaymentDetailsbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantOrderPaymentDetailsbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add OrderPaymentDetails /////

        [Route("RestuarantOrderPaymentDetails/createOrderPaymentDetails")]
        [HttpPost]
        public string createOrderPaymentDetails(int intOrderID, int intOrderPaymentType, int intCardType, string strPayAmount, string strDenomination_TwoThousnd, string strDenomination_FiveHndrd, string strDenomination_TwoHndrd, string strDenomination_OneHndr, string strDenomination_Fifty, string strDenomination_Twnty, string strDenomination_Ten, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertOrderPaymentDetails = objOrderPayment.manageRestuarantOrderPaymentDetails(3, 0, intOrderID, intOrderPaymentType, intCardType, strPayAmount, strDenomination_TwoThousnd, strDenomination_FiveHndrd, strDenomination_TwoHndrd, strDenomination_OneHndr, strDenomination_Fifty, strDenomination_Twnty, strDenomination_Ten, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertOrderPaymentDetails == 0)
                {
                    return "PaymentDetails added successfully";
                }
                else if (insertOrderPaymentDetails == -1)
                {
                    return "PaymentDetails already exist";
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


        //Update PaymentDetails/////
        [Route("RestuarantOrderPaymentDetails/updateOrderPaymentDetails")]
        [HttpPost]
        public string updateOrderPaymentDetails(int intOrderPaymentDetailsID, int intOrderID, int intOrderPaymentType, int intCardType, string strPayAmount, string strDenomination_TwoThousnd, string strDenomination_FiveHndrd, string strDenomination_TwoHndrd, string strDenomination_OneHndr, string strDenomination_Fifty, string strDenomination_Twnty, string strDenomination_Ten, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateOrderPaymentDetails = objOrderPayment.manageRestuarantOrderPaymentDetails(4, intOrderPaymentDetailsID, intOrderID, intOrderPaymentType, intCardType, strPayAmount, strDenomination_TwoThousnd, strDenomination_FiveHndrd, strDenomination_TwoHndrd, strDenomination_OneHndr, strDenomination_Fifty, strDenomination_Twnty, strDenomination_Ten, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateOrderPaymentDetails == 0)
                {
                    return "Payment Details updated successfully";
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



        //Delete PaymentDetails /////
        [Route("RestuarantOrderPaymentDetails/deleteOrderPaymentDetails")]
        [HttpPost]
        public string deleteOrderPaymentDetails(int intOrderPaymentDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteOrderPaymentDetailsByID = objOrderPayment.manageRestuarantOrderPaymentDetails(6, intOrderPaymentDetailsID, 0, 0, 0, "", "", "", "", "", "", "", "", intOutletID, 0, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteOrderPaymentDetailsByID == 0)
                {
                    return "Order Payment Details  deleted successfully";
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

        //Get All Order PaymentDetails  by ID///
        [Route("RestuarantOrderPaymentDetails/editByOrderPaymentDetailsID")]
        [HttpPost]
        public string editByOrderPaymentDetailsID(int intOrderPaymentDetailsID)
        {
            try
            {

                string editByOrderPaymentDetailsID = objOrderPayment.getRestuarantOrderPaymentDetails(7, intOrderPaymentDetailsID, 0, 0, 0, "", "", "", "", "", "", "", "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByOrderPaymentDetailsID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByOrderPaymentDetailsID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //deActive Status of Order PaymentDetails /////
        [Route("RestuarantOrderPaymentDetails/activeStatusOrderPaymentDetailsDeActive")]
        [HttpPost]
        public string activeStatusOrderPaymentDetailsDeActive(int intOrderPaymentDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusOrderPaymentDetailsDeActive = objOrderPayment.manageRestuarantOrderPaymentDetails(5, intOrderPaymentDetailsID, 0, 0, 0, "", "", "", "", "", "", "", "", intOutletID, 0, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusOrderPaymentDetailsDeActive == 0)
                {
                    return "OrderPaymentDetails  DeActivated successfully";
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



        //Active Status oOrderPaymentDetailsON /////
        [Route("RestuarantOrderPaymentDetails/activeStatusOrderPaymentDetails")]
        [HttpPost]
        public string activeStatusOrderPaymentDetails(int intOrderPaymentDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusOrderPaymentDetails = objOrderPayment.manageRestuarantOrderPaymentDetails(9, intOrderPaymentDetailsID, 0, 0, 0, "", "", "", "", "", "", "", "", intOutletID, 0, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusOrderPaymentDetails == 0)
                {
                    return "Order PaymentDetails  Activated successfully";
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






        //Update Order Tablee/////
        //[Route("RestuarantOrderPaymentDetails/updateOrderTableDetails")]
        //[HttpPost]
        //public string updateOrderTableDetails(int intOrderPaymentDetailsID, int intOrderID,  string strPayAmount,  string strDenomination_TwoThousnd,  int intOutletID,  int intCreatedBy, int intModifiedBy)
        //{
        //    try
        //    {

        //        int updateOrderPaymentDetails = objOrderPayment.manageRestuarantOrderPaymentDetails(10, intOrderPaymentDetailsID, intOrderID,0,0, strPayAmount, strDenomination_TwoThousnd, "", "", "", "", "", "",  intOutletID, 0, 1, 0, intCreatedBy, "", intModifiedBy, "");
        //        if (updateOrderPaymentDetails == 0)
        //        {
        //            return "Payment Details updated successfully";
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

        [Route("RestuarantOrderPaymentDetails/CreatePaymentDetails")]
        [HttpPost]
        public string CreatePaymentDetail(string strGivenAmount, string strChangeAmount, string strCouponCode, string strCouponAmount, string strLoyaltyPoints, string strLoyaltyAmount, int intOrderID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy, List<ClsResturantPaymentDetails> PaymentDetails)
        {
            try
            {
                ////CouponAmount,CouponCode,LoyaltyPoints,LoyaltyAmount////
                int insertOrderPaymentDetails = 0;
                foreach (var x in PaymentDetails)
                {
                    insertOrderPaymentDetails = objOrderPayment.manageRestuarantOrderPaymentDetails(3, 0, x.OrderID, x.OrderPaymentType, x.CardType, x.PayAmount, x.TwoT, x.FiveH, x.TwoH, x.OneH, x.Fifty, x.Twenty, x.Ten, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");



                }

                ///update ordeer table//

                int updatePOSRestuarantOrder = objPOSOrder.manageRestuarantPOSOrder(12, intOrderID, "", "", 0, 0, 0, 0, "", "", "", "", strGivenAmount, strChangeAmount, "", "", 0, strCouponCode, strCouponAmount, strLoyaltyPoints, strLoyaltyAmount, 0, "", intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertOrderPaymentDetails == 0)
                {
                    return "PaymentDetails added successfully";
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