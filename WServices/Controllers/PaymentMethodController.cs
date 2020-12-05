using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class PaymentMethodController : ApiController
    {
        WFramework.Masters.ClsPaymentMethodMaster objPaymentMethod = new WFramework.Masters.ClsPaymentMethodMaster();

        //Get top 1000 All PaymentMethod ///
        [Route("PaymentMethod/readPaymentMethodDetail")]
        [HttpGet]
        public string readPaymentMethodDetail()
        {
            try
            {

                string readPaymentMethodDetail = objPaymentMethod.getPaymentMethod(1,0,"","",0,"",0,0,0, 0, 0, "", 0, "");

                if (readPaymentMethodDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readPaymentMethodDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All PaymentMethod by outlet ID///
        [Route("PaymentMethod/readPaymentMethodDetailbyoutletID")]
        [HttpPost]
        public string readPaymentMethodDetailbyoutletID(int intKitchenID, int intOutletID)
        {
            try
            {

                string readPaymentMethodDetailbyoutletID = objPaymentMethod.getPaymentMethod(2, 0,"","",0,"", intKitchenID, intOutletID, 0, 0, 0, "", 0, "");

                if (readPaymentMethodDetailbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readPaymentMethodDetailbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add PaymentMethodDetail /////

        [Route("PaymentMethod/createPaymentMethod")]
        [HttpPost]
        public string createPaymentMethod(string strPaymentMethodName, string strPaymentMethodDescription, int intTempOne,string strTempTwo,
        int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertPaymentMethoddetail = objPaymentMethod.managePaymentMethod(3, 0, strPaymentMethodName,  strPaymentMethodDescription,  intTempOne,  strTempTwo, intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertPaymentMethoddetail == 0)
                {
                    return "PaymentMethoddetail added successfully";
                }
                else if (insertPaymentMethoddetail == -1)
                {
                    return "PaymentMethoddetail already exist";
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


        //Update PaymentMethodDetail /////
        [Route("PaymentMethod/updatePaymentMethod")]
        [HttpPost]
        public string updatePaymentMethod(int intPaymentMethodID, string strPaymentMethodName, string strPaymentMethodDescription, int intTempOne, string strTempTwo,
        int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updatePaymentMethod = objPaymentMethod.managePaymentMethod(4, intPaymentMethodID, strPaymentMethodName, strPaymentMethodDescription, intTempOne, strTempTwo, intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updatePaymentMethod == 0)
                {
                    return "Payment Method detail updated successfully";
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



        //Delete PaymentMethodDetail /////
        [Route("PaymentMethod/deletePaymentMethod")]
        [HttpPost]
        public string deletePaymentMethod(int intPaymentMethodID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deletePaymentMethodByID = objPaymentMethod.managePaymentMethod(6, intPaymentMethodID, "", "",0, "", intKitchenID, intOutletID, 1, 1, intCreatedBy, "",intModifiedBy, "");

                if (deletePaymentMethodByID == 0)
                {
                    return "Payment Method  deleted successfully";
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
        [Route("PaymentMethod/editByPaymentMethodID")]
        [HttpPost]
        public string editByPaymentMethodID(int intPaymentMethodID)
        {
            try
            {

                string editByPaymentMethodID = objPaymentMethod.getPaymentMethod(7, intPaymentMethodID, "", "",0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByPaymentMethodID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByPaymentMethodID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of PaymentMethod /////
        [Route("PaymentMethod/activeStatusPaymentMethod")]
        [HttpPost]
        public string activeStatusPaymentMethod(int intPaymentMethodID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusPaymentMethod = objPaymentMethod.managePaymentMethod(9, intPaymentMethodID, "", "",0, "", intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusPaymentMethod == 0)
                {
                    return "PaymentMethod  Activated successfully";
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

        //deActive Status of PaymentMethod /////
        [Route("PaymentMethod/deactiveStatusPaymentMethod")]
        [HttpPost]
        public string deactiveStatusPaymentMethod(int intPaymentMethodID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusPaymentMethod = objPaymentMethod.managePaymentMethod(5, intPaymentMethodID, "", "", 0, "", intKitchenID, intOutletID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusPaymentMethod == 0)
                {
                    return "PaymentMethod  DeActivated successfully";
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
