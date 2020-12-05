using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers
{
    public class RestuarantKitchenManagementController : ApiController
    {

        WFramework.Kitchen.ClsResturantKitchenManagement objKitchenManagement = new WFramework.Kitchen.ClsResturantKitchenManagement();

        //Get top 1000 All KitchenManagement ///
        [Route("RestuarantKitchenManagement/readRestuarantKitchenManagement")]
        [HttpGet]
        public string readRestuarantKitchenManagement()
        {
            try
            {

                string readRestuarantKitchenManagement = objKitchenManagement.getResturantKitchenManagement(1, 0, 0, "", 0, 0, "", 0, "", 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (readRestuarantKitchenManagement == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantKitchenManagement;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        [Route("RestuarantKitchenManagement/readKitchenManagementbyoutletID")]
        [HttpPost]
        public string readKitchenManagementbyoutletID(int intOutletID, int intKitchenID)
        {
            try
            {

                string readKitchenManagementbyoutletID = objKitchenManagement.getResturantKitchenManagement(2, 0, 0, "", 0, 0, "", 0, "", 0, "", intOutletID, intKitchenID, 1, 0, 0, "", 0, "");

                if (readKitchenManagementbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readKitchenManagementbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        //Add KitchenManagement  /////

        [Route("RestuarantKitchenManagement/createKitchenManagement")]
        [HttpPost]
        public string createKitchenManagement(int intOrderID, string strOrderNumber, int intWaiter, int intTableID, string strCustomerTimer, int intCustomerID, string strOrderStatus, int intOrderStatusValue, string strDishTime, int intOutletID, int intKitchenID,
          int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertKitchenManagement = objKitchenManagement.manageResturantKitchenManagement(3, 0, intOrderID, strOrderNumber, intWaiter, intTableID, strCustomerTimer, intCustomerID, strOrderStatus, intOrderStatusValue, strDishTime, intOutletID, 0, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertKitchenManagement == 0)
                {
                    return "KitchenManagement Added successfully";
                }
                else if (insertKitchenManagement == -1)
                {
                    return "KitchenManagement already exist";
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


        //Update Assign FoodMenu/////
        [Route("RestuarantKitchenManagement/updateKitchenManagement")]
        [HttpPost]
        public string updateKitchenManagement(int intKitchenManagementID, int intOrderID, string strOrderNumber, int intWaiter, int intTableID, string strCustomerTimer, int intCustomerID, string strOrderStatus, int intOrderStatusValue, string strDishTime, int intOutletID, int intKitchenID,
          int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateKitchenManagement = objKitchenManagement.manageResturantKitchenManagement(4, intKitchenManagementID, intOrderID, strOrderNumber, intWaiter, intTableID, strCustomerTimer, intCustomerID, strOrderStatus, intOrderStatusValue, strDishTime, intOutletID, 0, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateKitchenManagement == 0)
                {
                    return "KitchenManagement updated successfully";
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



        //Delete KitchenManagement /////
        [Route("RestuarantKitchenManagement/deleteKitchenManagement")]
        [HttpPost]
        public string deleteKitchenManagement(int intKitchenManagementID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteKitchenManagementByID = objKitchenManagement.manageResturantKitchenManagement(6, intKitchenManagementID, 0, "", 0, 0, "", 0, "", 0, "", intOutletID, intKitchenID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deleteKitchenManagementByID == 0)
                {
                    return "KitchenManagement  deleted successfully";
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

        //Get All KitchenManagement  by ID///
        [Route("RestuarantKitchenManagement/editByKitchenManagement")]
        [HttpPost]
        public string editByKitchenManagement(int intKitchenManagementID)
        {
            try
            {

                string editByKitchenManagement = objKitchenManagement.getResturantKitchenManagement(7, intKitchenManagementID, 0, "", 0, 0, "", 0, "", 0, "", 0, 0, 1, 0, 0, "", 0, "");

                if (editByKitchenManagement == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByKitchenManagement;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of activeStatusKitchenManagement /////
        [Route("RestuarantKitchenManagement/activeStatusKitchenManagement")]
        [HttpPost]
        public string activeStatusKitchenManagement(int intKitchenManagementID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusKitchenManagement = objKitchenManagement.manageResturantKitchenManagement(9, intKitchenManagementID, 0, "", 0, 0, "", 1, "", 0, "", intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusKitchenManagement == 0)
                {
                    return "KitchenManagement  Activated successfully";
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


        //deActive Status of KitchenManagement /////
        [Route("RestuarantKitchenManagement/deactiveStatusKitchenManagement")]
        [HttpPost]
        public string deactiveStatusKitchenManagement(int intKitchenManagementID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusKitchenManagement = objKitchenManagement.manageResturantKitchenManagement(5, intKitchenManagementID, 0, "", 0, 0, "", 0, "", 0, "", intOutletID, intKitchenID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusKitchenManagement == 0)
                {
                    return "KitchenManagement  deActivated successfully";
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

        //Order Status/////
        [Route("RestuarantKitchenManagement/OrderStatusKitchenManagement")]
        [HttpPost]
        public string OrderStatusKitchenManagement(int OrderID, int intOrderStatusValue, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int OrderStatusKitchenManagement = objKitchenManagement.manageResturantKitchenManagement(10, 0, OrderID, "", 0, 0, "", 0, "", intOrderStatusValue, "", intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (OrderStatusKitchenManagement == 0)
                {
                    return "KitchenManagement  Order Status Updated successfully";
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
