using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.AssignScreens
{
    public class RestuarantAssignModifiersController : ApiController
    {


        WFramework.AssignScreens.ClsRestuarantAssignModifiers objAssignModifiers = new WFramework.AssignScreens.ClsRestuarantAssignModifiers();

        //Get top 1000 All AssignModifiers ///
        [Route("RestuarantAssignModifiers/readAssignModifiersDetail")]
        [HttpGet]
        public string readAssignModifiersDetail()
        {
            try
            {

                string readAssignModifiersDetail = objAssignModifiers.getAssignModifiers(1,0,0,0,0,"",0,0,0,0,0,"",0,"");

                if (readAssignModifiersDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readAssignModifiersDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All AssignModifiers by outlet ID///
        [Route("RestuarantAssignModifiers/readAssignModifiersDetailbyoutletID")]
        [HttpPost]
        public string readAssignModifiersDetailbyoutletID(int intKitchenID, int intOutletID)
        {
            try
            {

                string readAssignModifiersDetailbyoutletID = objAssignModifiers.getAssignModifiers(2, 0,0,0,0,"",  intOutletID, intKitchenID, 0, 0, 0, "", 0, "");

                if (readAssignModifiersDetailbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readAssignModifiersDetailbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add AssignModifiers  /////

        [Route("RestuarantAssignModifiers/createAssignModifiers")]
        [HttpPost]
        public string createAssignModifiers(int intFoodMenuID, int intFoodModifierID, int intTempOne, string strTempTwo, 
         int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {
                string readAssignModifiersDetailbyoutletID = objAssignModifiers.getAssignModifiers(2, 0, 0, 0, 0, "", intOutletID, intKitchenID, 0, 0, 0, "", 0, "");

                JArray objtJSON = JArray.Parse(readAssignModifiersDetailbyoutletID);
                int intAssignModifierstoFoodMenuID = Convert.ToInt32(objtJSON[0]["AssignModifierstoFoodMenuID"]);
                if(readAssignModifiersDetailbyoutletID==""|| readAssignModifiersDetailbyoutletID == null)
                {
                    int insertAssignModifiersdetail = objAssignModifiers.manageAssignModifiers(3, 0, intFoodMenuID, intFoodModifierID, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                    if (insertAssignModifiersdetail == 0)
                    {
                        return "Modifier Assigned successfully";
                    }
                    else if (insertAssignModifiersdetail == -1)
                    {
                        return "Modifier Assignedr already exist";
                    }
                    else
                    {
                        return "Error occured either component or strore Procedure";
                    }
                }

                else
                {
                    int updateModifierAssigned = objAssignModifiers.manageAssignModifiers(4, intAssignModifierstoFoodMenuID, intFoodMenuID, intFoodModifierID, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                    if (updateModifierAssigned == 0)
                    {
                        return "Modifier Assigned updated successfully";
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
        }


        //Update Modifier Assigned/////
        [Route("RestuarantAssignModifiers/updateModifierAssigned")]
        [HttpPost]
        public string updateModifierAssigned(int intAssignModifierstoFoodMenuID, int intFoodMenuID, int intFoodModifierID, int intTempOne, string strTempTwo,
         int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateModifierAssigned = objAssignModifiers.manageAssignModifiers(4, intAssignModifierstoFoodMenuID, intFoodMenuID, intFoodModifierID, intTempOne, strTempTwo, intOutletID, intKitchenID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateModifierAssigned == 0)
                {
                    return "Modifier Assigned updated successfully";
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



        //Delete ModifierAssigned /////
        [Route("RestuarantAssignModifiers/deleteModifierAssigned")]
        [HttpPost]
        public string deleteModifierAssigned(int intAssignModifierstoFoodMenuID,  int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteModifierAssignedByID = objAssignModifiers.manageAssignModifiers(6, intAssignModifierstoFoodMenuID,0,0,0,"", intOutletID, intKitchenID, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteModifierAssignedByID == 0)
                {
                    return "Modifier Assigned  deleted successfully";
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

        //Get All AssignedModifiers  by ID///
        [Route("RestuarantAssignModifiers/editByAssignedModifiersID")]
        [HttpPost]
        public string editByAssignedModifiersID(int intAssignModifierstoFoodMenuID)
        {
            try
            {

                string editByAssignedModifiersID = objAssignModifiers.getAssignModifiers(7, intAssignModifierstoFoodMenuID,0,0,0,"",0,0,1,0,0,"",0,"");

                if (editByAssignedModifiersID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByAssignedModifiersID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of activeStatusAssignModifiers /////
        [Route("RestuarantAssignModifiers/activeStatusAssignModifiers")]
        [HttpPost]
        public string activeStatusAssignModifiers(int intAssignModifierstoFoodMenuID,  int intOutletID ,int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusAssignModifiers = objAssignModifiers.manageAssignModifiers(9, intAssignModifierstoFoodMenuID,0,0,0,"", intOutletID, intKitchenID,1,0,intCreatedBy,"",intModifiedBy,"");

                if (activeStatusAssignModifiers == 0)
                {
                    return "AssignModifiers Activated successfully";
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


        //Active Status of activeStatusAssignModifiers /////
        [Route("RestuarantAssignModifiers/deactiveStatusAssignModifiers")]
        [HttpPost]
        public string deactiveStatusAssignModifiers(int intAssignModifierstoFoodMenuID, int intOutletID, int intKitchenID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusAssignModifiers = objAssignModifiers.manageAssignModifiers(5, intAssignModifierstoFoodMenuID, 0, 0, 0, "", intOutletID, intKitchenID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusAssignModifiers == 0)
                {
                    return "AssignModifiers deactivated successfully";
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
