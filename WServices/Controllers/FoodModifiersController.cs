 using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class FoodModifiersController : ApiController
    {
        WFramework.Masters.ClsFoodModifierMaster objFoodModifier = new WFramework.Masters.ClsFoodModifierMaster();

        //Get top 1000 All FoodModifier ///
        [Route("FoodModifiers/readFoodModifierDetail")]
        [HttpGet]
        public string readFoodModifierDetail()
        {
            try
            {

                string readFoodModifierDetail = objFoodModifier.getFoodModifiers(1, 0,"","","",0,0,0,0,0,"",0,"");

                if (readFoodModifierDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readFoodModifierDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All FoodModifier by outlet ID///
        [Route("FoodModifiers/readFoodModifierDetailbyoutletID")]
        [HttpPost]
        public string readFoodModifierDetailbyoutletID(int intKitchenID, int intOutletID)
        {
            try
            {

                string readFoodModifierDetailbyoutletID = objFoodModifier.getFoodModifiers(2, 0,"","","", intKitchenID, intOutletID, 0, 0, 0, "", 0, "");

                if (readFoodModifierDetailbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readFoodModifierDetailbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add Food Modifier /////

        [Route("FoodModifiers/createFoodModifier")]
        [HttpPost]
        public string createFoodModifier(string strModifierName,string decModifierPrice, string strModifierDecription, 
        int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertFoodModifierdetail = objFoodModifier.manageFoodModifiers(3, 0, strModifierName, decModifierPrice, strModifierDecription, intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (insertFoodModifierdetail == 0)
                {
                    return "FoodMenu added successfully";
                }
                else if (insertFoodModifierdetail == -1)
                {
                    return "FoodModifier already exist";
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


        //Update Food Modifier Category/////
        [Route("FoodModifiers/updateFoodModifier")]
        [HttpPost]
        public string updateFoodModifier(int intModifierID, string strModifierName, string decModifierPrice, string strModifierDecription,
        int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateFoodModifier = objFoodModifier.manageFoodModifiers(4, intModifierID, strModifierName, decModifierPrice, strModifierDecription, intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateFoodModifier == 0)
                {
                    return "Food Modifier detail updated successfully";
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



        //Delete Food Modifier /////
        [Route("FoodModifiers/deleteFoodModifier")]
        [HttpPost]
        public string deleteFoodModifier(int intModifierID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteFoodModifierByID = objFoodModifier.manageFoodModifiers(6, intModifierID,"","","", intKitchenID, intOutletID,1,1,intCreatedBy,"",intModifiedBy,"");

                if (deleteFoodModifierByID == 0)
                {
                    return "Food Modifier  deleted successfully";
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

        //Get All Food Modifier  by ID///
        [Route("FoodModifiers/editByFoodModifierID")]
        [HttpPost]
        public string editByFoodModifierID(int intModifierID)
        {
            try
            {

                string editByFoodModifierID = objFoodModifier.getFoodModifiers(7, intModifierID,"","","",0,0,1,0,0,"",0,"");

                if (editByFoodModifierID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByFoodModifierID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //deActive Status of Food Modifier /////
        [Route("FoodModifiers/activeStatusFoodModifierDeactive")]
        [HttpPost]
        public string activeStatusFoodModifierDeactive(int intModifierID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusFoodModifierDeactive = objFoodModifier.manageFoodModifiers(5, intModifierID,"","","", intKitchenID, intOutletID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusFoodModifierDeactive == 0)
                {
                    return "Food Modifier  DeActivated successfully";
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

        //Active Status of Food ModifierOn /////
        [Route("FoodModifiers/activeStatusFoodModifier")]
        [HttpPost]
        public string activeStatusFoodModifier(int intModifierID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusFoodModifier = objFoodModifier.manageFoodModifiers(9, intModifierID, "", "", "", intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusFoodModifier == 0)
                {
                    return "Food Modifier  Activated successfully";
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
