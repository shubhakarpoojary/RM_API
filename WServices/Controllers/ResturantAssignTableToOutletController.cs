using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.AssignScreens
{
    public class ResturantAssignTableToOutletController : ApiController
    {
        WFramework.AssignScreens.ClsRestuarantAssignTableToOutlet objAssignTabletoOutlet = new WFramework.AssignScreens.ClsRestuarantAssignTableToOutlet();



        //Get top 1000 All AssignTabletoOutlet ///
        [Route("ResturantAssignTableToOutlet/readAssignTabletoOutletDetail")]
        [HttpGet]
        public string readAssignTabletoOutletDetail()
        {
            try
            {

                string readAssignTabletoOutletDetail = objAssignTabletoOutlet.getAssignTableToOutlet(1, 0, 0, 0, 0, 0, "", 0, 0, 0, "", 0, "");

                if (readAssignTabletoOutletDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readAssignTabletoOutletDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All AssignTabletoOutlet by outlet ID///
        [Route("ResturantAssignTableToOutlet/readAssignTabletoOutletbyoutletID")]
        [HttpPost]
        public string readAssignTabletoOutletbyoutletID(int intOutletID)
        {
            try
            {

                string readAssignTabletoOutletbyoutletID = objAssignTabletoOutlet.getAssignTableToOutlet(2, 0, intOutletID, 0, 0, 0, "", 0, 0, 0, "", 0, "");
               
                
                if (readAssignTabletoOutletbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readAssignTabletoOutletbyoutletID;
                }

           
            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
           
        }



        //Add AssignTabletoOutlet  /////

        [Route("ResturantAssignTableToOutlet/createAssignTabletoOutlet")]
        [HttpPost]
        public string createAssignTabletoOutlet(int intOutletID, int intTabelID, int intIsSharable, int intTableSeatCapacity, string strTablePosition, int intCreatedBy, int intModifiedBy)
        {
            try
            {
                string readAssignTabletoOutletbyoutletID = objAssignTabletoOutlet.getAssignTableToOutlet(2, 0, intOutletID, 0, 0, 0, "", 0, 0, 0, "", 0, "");
                JArray objtJSON = JArray.Parse(readAssignTabletoOutletbyoutletID);
            int intAssignTableToOutletID = Convert.ToInt32(objtJSON[0]["AssignTableToOutletID"]);

                if (readAssignTabletoOutletbyoutletID == "" || readAssignTabletoOutletbyoutletID == null)
                {

                    int insertAssignCouponsdetail = objAssignTabletoOutlet.manageAssignTableToOutlet(3, 0, intOutletID, intTabelID, intIsSharable, intTableSeatCapacity, strTablePosition, 1, 0, intCreatedBy, "", intModifiedBy, "");
                    if (insertAssignCouponsdetail == 0)
                    {
                        return "Table Assigned successfully";
                    }
                    else if (insertAssignCouponsdetail == -1)
                    {
                        return "Table Assigned already exist";
                    }
                    else
                    {
                        return "Error occured either component or strore Procedure";
                    }


                }
                else
                {
                    int updateAssignTabletoOutlet = objAssignTabletoOutlet.manageAssignTableToOutlet(4, intAssignTableToOutletID, intOutletID, intTabelID, intIsSharable, intTableSeatCapacity, strTablePosition, 1, 0, intCreatedBy, "", intModifiedBy, "");
                    if (updateAssignTabletoOutlet == 0)
                    {
                        return "Table Assigned updated successfully";
                    }
                    else
                    {
                        return "Error occured either component or strore Procedure";
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
            return "";
        }


        //Update AssignTabletoOutlet/////
        [Route("ResturantAssignTableToOutlet/updateAssignTabletoOutlet")]
        [HttpPost]
        public string updateAssignTabletoOutlet(int intAssignTableToOutletID, int OutletID, int intTabelID, int intIsSharable, int intTableSeatCapacity, string strTablePosition, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateAssignTabletoOutlet = objAssignTabletoOutlet.manageAssignTableToOutlet(4, intAssignTableToOutletID, OutletID, intTabelID, intIsSharable, intTableSeatCapacity, strTablePosition, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateAssignTabletoOutlet == 0)
                {
                    return "Table Assigned updated successfully";
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



        //Delete AssignTabletoOutlet /////
        [Route("ResturantAssignTableToOutlet/deleteAssignTabletoOutlet")]
        [HttpPost]
        public string deleteAssignTabletoOutlet(int intAssignTableToOutletID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteTableAssignedByID = objAssignTabletoOutlet.manageAssignTableToOutlet(6, intAssignTableToOutletID, intOutletID, 0, 0, 0, "", 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteTableAssignedByID == 0)
                {
                    return "Table Assigned  deleted successfully";
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

        //Get All AssignTabletoOutlet  by ID///
        [Route("ResturantAssignTableToOutlet/editByAssignTabletoOutletID")]
        [HttpPost]
        public string editByAssignTabletoOutletID(int intAssignTableToOutletID)
        {
            try
            {

                string editByTableAssignedID = objAssignTabletoOutlet.getAssignTableToOutlet(7, intAssignTableToOutletID, 0, 0, 0, 0, "", 1, 0, 0, "", 0, "");

                if (editByTableAssignedID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByTableAssignedID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of activeStatusAssignTabletoOutlet /////
        [Route("ResturantAssignTableToOutlet/activeStatusAssignTabletoOutlet")]
        [HttpPost]
        public string activeStatusAssignTabletoOutlet(int intAssignTableToOutletID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusAssignTabletoOutlet = objAssignTabletoOutlet.manageAssignTableToOutlet(9, intAssignTableToOutletID, intOutletID, 0, 0, 0, "", 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusAssignTabletoOutlet == 0)
                {
                    return "AssignTable Activated successfully";
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


        //deActive Status of activeStatusAssignTabletoOutlet /////
        [Route("ResturantAssignTableToOutlet/deactiveStatusAssignTabletoOutlet")]
        [HttpPost]
        public string deactiveStatusAssignTabletoOutlet(int intAssignTableToOutletID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusAssignTabletoOutlet = objAssignTabletoOutlet.manageAssignTableToOutlet(5, intAssignTableToOutletID, intOutletID, 0, 0, 0, "", 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusAssignTabletoOutlet == 0)
                {
                    return "AssignTable deActivated successfully";
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
