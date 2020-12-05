using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers
{
    public class RestuarantPOSDineInController : ApiController
    {
        WFramework.POS.ClsRestuarantPOSDineInDetails objPOSDineInDetails = new WFramework.POS.ClsRestuarantPOSDineInDetails();



        //Get top 1000 All Order ///
        [Route("RestuarantPOSDineIn/GetRestuarantPOSDineIn")]
        [HttpGet]
        public string GetRestuarantPOSDineIn()
        {
            try
            {

                string GetRestuarantPOSDineIn = objPOSDineInDetails.getRestuarantDineInDetails(1, 0, 0, "", 0, 0, 0, "", 0, 0, 0, 0, 0, "", 0, "");

                if (GetRestuarantPOSDineIn == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return GetRestuarantPOSDineIn;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All RestuarantPOSDineIn by outlet ID///
        [Route("RestuarantPOSDineIn/readRestuarantPOSDineInID")]
        [HttpPost]
        public string readRestuarantPOSDineInID(int intOutletID)
        {
            try
            {

                string readRestuarantPOSDineInID = objPOSDineInDetails.getRestuarantDineInDetails(2, 0, 0, "", 0, 0, 0, "", intOutletID, 0, 0, 0, 0, "", 0, "");

                if (readRestuarantPOSDineInID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantPOSDineInID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add RestuarantPOSDineIn /////

        [Route("RestuarantPOSDineIn/createRestuarantPOSDineIn")]
        [HttpPost]
        public string createRestuarantPOSDineIn(int intOrderID, string strTableNumber, int intTableNameID, int intTableSeatCapacity, int intAvailablePersons, string strTime, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertRestuarantPOSOrder = objPOSDineInDetails.manageRestuarantDineInDetails(3, 0, intOrderID, strTableNumber, intTableNameID, intTableSeatCapacity, intAvailablePersons, strTime, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertRestuarantPOSOrder == 0)
                {
                    return "Dine In Details Added Successfully";
                }
                else if (insertRestuarantPOSOrder == -1)
                {
                    return "Dine In Details already exist";
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


        //Update RestuarantPOSDineIn/////
        [Route("RestuarantPOSDineIn/updateRestuarantPOSDineIn")]
        [HttpPost]
        public string updateRestuarantPOSDineIn(int intDineInDetailsID, int intOrderID, string strTableNumber, int intTableNameID, int intTableSeatCapacity, int intAvailablePersons, string strTime, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updatePOSRestuarantOrder = objPOSDineInDetails.manageRestuarantDineInDetails(4, intDineInDetailsID, intOrderID, strTableNumber, intTableNameID, intTableSeatCapacity, intAvailablePersons, strTime, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updatePOSRestuarantOrder == 0)
                {
                    return "Dine In Details updated successfully";
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



        //Delete RestuarantPOSDineIn /////
        [Route("RestuarantPOSDineIn/deleteRestuarantPOSDineIn")]
        [HttpPost]
        public string deleteRestuarantPOSDineIn(int intDineInDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteRestuarantPOSDineInByID = objPOSDineInDetails.manageRestuarantDineInDetails(6, intDineInDetailsID, 0, "", 0, 0, 0, "", intOutletID, 0, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteRestuarantPOSDineInByID == 0)
                {
                    return "Restuarant DineIn deleted successfully";
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

        //Get All Order RestuarantPOSDineIn  by ID///
        [Route("RestuarantPOSDineIn/editByRestuarantPOSDineIn")]
        [HttpPost]
        public string editByRestuarantPOSDineIn(int intDineInDetailsID)
        {
            try
            {

                string editByRestuarantPOSDineIn = objPOSDineInDetails.getRestuarantDineInDetails(7, intDineInDetailsID, 0, "", 0, 0, 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByRestuarantPOSDineIn == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByRestuarantPOSDineIn;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //deActive Status of RestuarantPOSDineIn /////
        [Route("RestuarantPOSDineIn/deactiveStatusRestuarantPOSDineIn")]
        [HttpPost]
        public string deactiveStatusRestuarantPOSDineIn(int intDineInDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusRestuarantPOSDineIn = objPOSDineInDetails.manageRestuarantDineInDetails(5, intDineInDetailsID, 0, "", 0, 0, 0, "", intOutletID, 0, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusRestuarantPOSDineIn == 0)
                {
                    return "Restuarant Dine In DeActivated successfully";
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



        //Active Status RestuarantPOSDineIn /////
        [Route("RestuarantPOSDineIn/activeRestuarantPOSDineIn")]
        [HttpPost]
        public string activeRestuarantPOSDineIn(int intDineInDetailsID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeRestuarantPOSDineIn = objPOSDineInDetails.manageRestuarantDineInDetails(9, intDineInDetailsID, 0, "", 0, 0, 0, "", intOutletID, 0, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeRestuarantPOSDineIn == 0)
                {
                    return "Restuarant Dine In Activated successfully";
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
