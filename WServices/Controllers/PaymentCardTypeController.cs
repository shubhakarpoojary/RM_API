using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class PaymentCardTypeController : ApiController
    {

        WFramework.Masters.ClsPaymentCardTypeMaster objPaymentCardType = new WFramework.Masters.ClsPaymentCardTypeMaster();

        //Get top 1000 All PaymentCardType ///
        [Route("PaymentCardType/readPaymentCardTypeDetail")]
        [HttpGet]
        public string readPaymentCardTypeDetail()
        {
            try
            {

                string readPaymentCardTypeDetail = objPaymentCardType.getPaymentCardType(1, 0,"","",  0, 0, 0, 0, 0, "", 0, "");

                if (readPaymentCardTypeDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readPaymentCardTypeDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All PaymentCardType by outlet ID///
        [Route("PaymentCardType/readPaymentCardTypebyoutletID")]
        [HttpPost]
        public string readPaymentCardTypebyoutletID(int intKitchenID, int intOutletID)
        {
            try
            {

                string readPaymentCardTypebyoutletID = objPaymentCardType.getPaymentCardType(2, 0, "", "", intKitchenID, intOutletID, 0, 0, 0, "", 0, "");

                if (readPaymentCardTypebyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readPaymentCardTypebyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add PaymentCardTypeDetail /////

        [Route("PaymentCardType/createPaymentCardType")]
        [HttpPost]
        public string createPaymentCardType(string strCardType, string strCardTypeDescription, 
        int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertPaymentCardType = objPaymentCardType.managePaymentCardType(3, 0, strCardType, strCardTypeDescription, intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertPaymentCardType == 0)
                {
                    return "PaymentMethoddetail added successfully";
                }
                else if (insertPaymentCardType == -1)
                {
                    return "PaymentCardTypedetail already exist";
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


        //Update PaymentCardType /////
        [Route("PaymentCardType/updatePaymentCardType")]
        [HttpPost]
        public string updatePaymentCardType(int intCardTypeID, string strCardType, string strCardTypeDescription, 
        int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updatePaymentCardType = objPaymentCardType.managePaymentCardType(4, intCardTypeID, strCardType, strCardTypeDescription, intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updatePaymentCardType == 0)
                {
                    return "Payment Card Type detail updated successfully";
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



        //Delete PaymentCardType /////
        [Route("PaymentCardType/deletePaymentCardType")]
        [HttpPost]
        public string deletePaymentCardType(int intCardTypeID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deletePaymentCardType = objPaymentCardType.managePaymentCardType(6, intCardTypeID, "", "", intKitchenID, intOutletID, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deletePaymentCardType == 0)
                {
                    return "Payment Card Type  deleted successfully";
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

        //Get All PaymentMethodDetail  by ID///
        [Route("PaymentCardType/editByPaymentCardTypeID")]
        [HttpPost]
        public string editByPaymentCardTypeID(int intCardTypeID)
        {
            try
            {

                string editByPaymentCardTypeID = objPaymentCardType.getPaymentCardType(7, intCardTypeID, "", "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByPaymentCardTypeID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByPaymentCardTypeID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of PaymentMethod /////
        [Route("PaymentCardType/activeStatusPaymentCardType")]
        [HttpPost]
        public string activeStatusPaymentCardType(int intCardTypeID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusPaymentMethod = objPaymentCardType.managePaymentCardType(9, intCardTypeID, "", "", intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");

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
        //Active Status of PaymentMethod /////
        [Route("PaymentCardType/deactiveStatusPaymentCardType")]
        [HttpPost]
        public string deactiveStatusPaymentCardType(int intCardTypeID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusPaymentMethod = objPaymentCardType.managePaymentCardType(5, intCardTypeID, "", "", intKitchenID, intOutletID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusPaymentMethod == 0)
                {
                    return "PaymentCardType  Deactivated successfully";
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
