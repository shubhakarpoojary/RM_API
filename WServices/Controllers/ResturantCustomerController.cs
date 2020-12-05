using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class ResturantCustomerController : ApiController
    {
        WFramework.Masters.ClsRestuarantCustomerMaster objPaymentRestCustomer = new WFramework.Masters.ClsRestuarantCustomerMaster();


        //Get top 1000 All RestuarantCustomer ///
        [Route("ResturantCustomer/readRestuarantCustomerDetail")]
        [HttpGet]
        public string readRestuarantCustomerDetail()
        {
            try
            {

                string readRestuarantCustomerDetail = objPaymentRestCustomer.getRestuarantCustomer(1,0,"","","","","","","","","","","",0,0,"","",0,0,0,0,"",0,"");

                if (readRestuarantCustomerDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantCustomerDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All RestuarantCustomer by outlet ID///
        [Route("ResturantCustomer/readRestuarantCustomerbyoutletID")]
        [HttpPost]
        public string readRestuarantCustomerbyoutletID( int intOutletID)
        {
            try
            {

                string readRestuarantCustomerbyoutletID = objPaymentRestCustomer.getRestuarantCustomer(2, 0,"","","","","","","","","","","",0,0,"","", intOutletID, 0, 0, 0, "", 0, "");

                if (readRestuarantCustomerbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantCustomerbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add RestuarantCustomerDetail /////

        [Route("ResturantCustomer/createRestuarantCustomer")]
        [HttpPost]
        public string createRestuarantCustomer(string strCustomerName, string strCustomerMobileNumber, string strCustomerEmail, string strCustomerDOB,string strCustomerDOA,string strFloorNumber, string strFlatNumber, string strDeliveryAdress,string strDeliveryAdressTwo, string GSTNumber,string strVehicleNumber, int intTempOne, int intTempTwo,string strTempThree,string strTempFour,
        int intOutletID,int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertRestuarantCustomer = objPaymentRestCustomer.manageRestuarantCustomer(3, 0, strCustomerName, strCustomerMobileNumber, strCustomerEmail, strCustomerDOB, strCustomerDOA, strFloorNumber, strFloorNumber,strDeliveryAdress, strDeliveryAdressTwo, GSTNumber, strVehicleNumber, intTempOne, intTempTwo, strTempThree, strTempFour, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertRestuarantCustomer == 0)
                {
                    return "RestuarantCustomerDetail added successfully";
                }
                else if (insertRestuarantCustomer == -1)
                {
                    return "RestuarantCustomerDetail already exist";
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


        //Update RestuarantCustomerDetail /////
        [Route("ResturantCustomer/updateRestuarantCustomer")]
        [HttpPost]
        public string updateRestuarantCustomer(int intCustomerID, string strCustomerName, string strCustomerMobileNumber, string strCustomerEmail, string strCustomerDOB, string strCustomerDOA, string strFloorNumber, string strFlatNumber, string strDeliveryAdress, string strDeliveryAdressTwo, string GSTNumber,string strVehicleNumber, int intTempOne, int intTempTwo, string strTempThree, string strTempFour,
        int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateRestuarantCustomer = objPaymentRestCustomer.manageRestuarantCustomer(4, intCustomerID, strCustomerName, strCustomerMobileNumber, strCustomerEmail, strCustomerDOB, strCustomerDOA, strFloorNumber, strFloorNumber, strDeliveryAdress, strDeliveryAdressTwo, GSTNumber, strVehicleNumber, intTempOne, intTempTwo, strTempThree, strTempFour, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateRestuarantCustomer == 0)
                {
                    return "Restuarant Customer detail updated successfully";
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



        //Delete Restuarant Customer /////
        [Route("ResturantCustomer/deleteRestuarantCustomer")]
        [HttpPost]
        public string deleteRestuarantCustomer(int intCustomerID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteRestuarantCustomer = objPaymentRestCustomer.manageRestuarantCustomer(6, intCustomerID,"","","","","","","", "", "", "","",0,0,"","", intOutletID, 1,1, intCreatedBy, "", intModifiedBy, "");

                if (deleteRestuarantCustomer == 0)
                {
                    return "Restuarant Customer  deleted successfully";
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

        //Get All RestuarantCustomer  by ID///
        [Route("ResturantCustomer/editByRestuarantCustomerID")]
        [HttpPost]
        public string editByRestuarantCustomerID(int intCustomerID)
        {
            try
            {

                string editByRestuarantCustomerID = objPaymentRestCustomer.getRestuarantCustomer(7, intCustomerID, "","","","","","","", "", "", "","",0,0,"","",0,1,0,0,"",0,"");

                if (editByRestuarantCustomerID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByRestuarantCustomerID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of RestuarantCustomer /////
        [Route("ResturantCustomer/activeStatusRestuarantCustomer")]
        [HttpPost]
        public string activeStatusRestuarantCustomer(int intCustomerID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusPaymentMethod = objPaymentRestCustomer.manageRestuarantCustomer(9, intCustomerID, "","","","","","","", "", "", "","",0,0,"","", intOutletID,1, 0, intCreatedBy, "", intModifiedBy, "");

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

        //deActive Status of RestuarantCustomer /////
        [Route("ResturantCustomer/deactiveStatusRestuarantCustomer")]
        [HttpPost]
        public string deactiveStatusRestuarantCustomer(int intCustomerID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusPaymentMethod = objPaymentRestCustomer.manageRestuarantCustomer(5, intCustomerID, "", "", "", "", "", "", "", "", "", "","", 0, 0, "", "", intOutletID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusPaymentMethod == 0)
                {
                    return "PaymentCardType  deActivated successfully";
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
