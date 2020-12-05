using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.AssignScreens
{
    public class RestuarantAssignFoodMenuController : ApiController
    {

        WFramework.AssignScreens.ClsRestuarantAssignFoodMenu objAssignFoodMenu = new WFramework.AssignScreens.ClsRestuarantAssignFoodMenu();

        //Get top 1000 All AssignFoodMenu ///
        [Route("RestuarantAssignFoodMenu/readAssignFoodMenuDetail")]
        [HttpGet]
        public string readAssignFoodMenuDetail()
        {
            try
            {

                string readAssignFoodMenuDetail = objAssignFoodMenu.getAssignFoodMenu(1,0,0,0,0,"",0,0,0,"",0,"");

                if (readAssignFoodMenuDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readAssignFoodMenuDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }






        //Add AssignFoodMenu  /////

        [Route("RestuarantAssignFoodMenu/createAssignFoodMenu")]
        [HttpPost]
        public string createAssignFoodMenu( int intOutletID, int intKitchenID, int intFoodMenuID,
         string strAmount, int intCreatedBy, int intModifiedBy)
        {
            try
            {
                string readAssignFoodMenuDetail = objAssignFoodMenu.getAssignFoodMenu(1, 0, 0, 0, 0, "", 0, 0, 0, "", 0, "");

                JArray objtJSON = JArray.Parse(readAssignFoodMenuDetail);
                int intAssignFoodMenuToOutletID = Convert.ToInt32(objtJSON[0]["AssignFoodMenuToOutletID"]);
                if(readAssignFoodMenuDetail==""|| readAssignFoodMenuDetail == null)
                {
                    int insertAssignFoodMenu = objAssignFoodMenu.manageAssignFoodMenu(3, 0, intOutletID, intKitchenID, intFoodMenuID, strAmount, 1, 0,intCreatedBy, "", intModifiedBy, "");
                    if (insertAssignFoodMenu == 0)
                    {
                        return "FoodMenu Assigned successfully";
                    }
                    else if (insertAssignFoodMenu == -1)
                    {
                        return "FoodMenu Assigned already exist";
                    }
                    else
                    {
                        return "Error occured either component or strore Procedure";
                    }
                }
               else
                {
                    int updateModifierAssigned = objAssignFoodMenu.manageAssignFoodMenu(4, intAssignFoodMenuToOutletID, intOutletID, intKitchenID, intFoodMenuID, strAmount, 1, 0, intCreatedBy, "", intModifiedBy, "");
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


        //Update Assign FoodMenu/////
        [Route("RestuarantAssignFoodMenu/updateAssignFoodMenu")]
        [HttpPost]
        public string updateAssignFoodMenu(int intAssignFoodMenuToOutletID, int intOutletID, int intKitchenID, int intFoodMenuID,
         string strAmount, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateModifierAssigned = objAssignFoodMenu.manageAssignFoodMenu(4, intAssignFoodMenuToOutletID,  intOutletID,  intKitchenID,  intFoodMenuID,strAmount, 1, 0, intCreatedBy, "", intModifiedBy, "");
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



        //Delete AssignFoodMenu /////
        [Route("RestuarantAssignFoodMenu/deleteAssignFoodMenu")]
        [HttpPost]
        public string deleteAssignFoodMenu(int intAssignFoodMenuToOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteAssignFoodMenuByID = objAssignFoodMenu.manageAssignFoodMenu(6, intAssignFoodMenuToOutletID,0,0,0,"",0,1,intCreatedBy,"",intModifiedBy,"");

                if (deleteAssignFoodMenuByID == 0)
                {
                    return "Food Menu Assigned  deleted successfully";
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

        //Get All AssignedFoodMenu  by ID///
        [Route("RestuarantAssignFoodMenu/editByAssignedFoodMenuID")]
        [HttpPost]
        public string editByAssignedFoodMenuID(int intAssignFoodMenuToOutletID)
        {
            try
            {

                string editByAssignedFoodMenuID = objAssignFoodMenu.getAssignFoodMenu(7, intAssignFoodMenuToOutletID,0,0,0,"",1,0,0,"",0,"");

                if (editByAssignedFoodMenuID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByAssignedFoodMenuID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of activeStatusAssignFoodMenu /////
        [Route("RestuarantAssignFoodMenu/activeStatusAssignFoodMenu")]
        [HttpPost]
        public string activeStatusAssignFoodMenu(int intAssignModifierstoFoodMenuID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusAssignFoodMenu = objAssignFoodMenu.manageAssignFoodMenu(9, intAssignModifierstoFoodMenuID,0,0,0,"",1,0,intCreatedBy,"",intModifiedBy,"");

                if (activeStatusAssignFoodMenu == 0)
                {
                    return "AssignFoodMenu  Activated successfully";
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


        //deActive Status of activeStatusAssignFoodMenu /////
        [Route("RestuarantAssignFoodMenu/deactiveStatusAssignFoodMenu")]
        [HttpPost]
        public string deactiveStatusAssignFoodMenu(int intAssignModifierstoFoodMenuID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deactiveStatusAssignFoodMenu = objAssignFoodMenu.manageAssignFoodMenu(5, intAssignModifierstoFoodMenuID, 0, 0, 0, "", 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (deactiveStatusAssignFoodMenu == 0)
                {
                    return "AssignFoodMenu  deActivated successfully";
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
