using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class FoodMenuCategoryController : ApiController
    {
        WFramework.Masters.ClsFoodMenuCategoryMaster objFoodMenuCategory = new WFramework.Masters.ClsFoodMenuCategoryMaster();

//Get top 1000 All FoodMenucategory ///
        [Route("FoodMenuCategory/readreadFoodMenuCategoryDetail")]
        [HttpGet]
        public string readreadFoodMenuCategoryDetail()
        {
            try
            {

                string readFoodMenuCategoryDetail = objFoodMenuCategory.getFoodMenuCategory(1,0,"","",0,0,0,0,0,"",0,"");

                if (readFoodMenuCategoryDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readFoodMenuCategoryDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All FoodMenucategory by outlet ID///
        [Route("FoodMenuCategory/readFoodMenuCategoryDetailbyoutletID")]
        [HttpPost]
        public string readFoodMenuCategoryDetailbyoutletID( int intKitchenID, int intOutletID)
        {
            try
            {

                string readFoodMenuCategoryDetailByID = objFoodMenuCategory.getFoodMenuCategory(2,0, "", "", intKitchenID, intOutletID, 0, 0, 0, "", 0, "");

                if (readFoodMenuCategoryDetailByID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readFoodMenuCategoryDetailByID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add Food menu Category/////
    
        [Route("FoodMenuCategory/createFoodMenuCategory")]
        [HttpPost]
        public string createFoodMenuCategory(string strFoodCategoryName,string strFoodCategoryDescription,int intKitchenID,int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertFoodCategorydetail = objFoodMenuCategory.manageFoodMenuCategory(3, 0, strFoodCategoryName, strFoodCategoryDescription, intKitchenID, intOutletID, 1, 0,intCreatedBy, "", intModifiedBy, "");
                if (insertFoodCategorydetail == 0)
                {
                    return "FoodMenuCategory added successfully";
                }
                else if (insertFoodCategorydetail == -1)
                {
                    return "FoodMenuCategory already exist";
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


        //Update Food menu Category/////
        [Route("FoodMenuCategory/updateFoodMenuCategory")]
        [HttpPost]
        public string updateFoodMenuCategory(int FoodCategoryID, string strFoodCategoryName, string strFoodCategoryDescription, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateFoodCtegorydetail = objFoodMenuCategory.manageFoodMenuCategory(4, FoodCategoryID, strFoodCategoryName, strFoodCategoryDescription, intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");
                if (updateFoodCtegorydetail == 0)
                {
                    return "Food Category updated successfully";
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



        //Delete Food menu Category/////
        [Route("FoodMenuCategory/deleteFoodMenuCategory")]
        [HttpPost]
        public string deleteFoodMenuCategory(int intFoodCategoryID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteFoodMenuCategoryByID = objFoodMenuCategory.manageFoodMenuCategory(6, intFoodCategoryID, "", "", intKitchenID, intOutletID,1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteFoodMenuCategoryByID == 0)
                {
                    return "Food Menu Category deleted successfully";
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

      //Get All Food Menu Category by ID///
        [Route("FoodMenuCategory/editByFoodCategoryID")]
        [HttpPost]
        public string editByFoodCategoryID(int intFoodCategoryID)
        {
            try
            {

                string editByFoodCategoryID =  objFoodMenuCategory.getFoodMenuCategory(7, intFoodCategoryID,"","",0,0,1,0,0,"",0,"");

                if (editByFoodCategoryID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByFoodCategoryID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //Active Status of Food menu Category/////
        [Route("FoodMenuCategory/activeStatusFoodMenuCategoryDeactivate")]
        [HttpPost]
        public string activeStatusFoodMenuCategoryDeactivate(int intFoodCategoryID,int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusFoodMenuCategoryDeactivate = objFoodMenuCategory.manageFoodMenuCategory(5, intFoodCategoryID, "", "", intKitchenID, intOutletID, 0, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusFoodMenuCategoryDeactivate == 0)
                {
                    return "Food Menu Category Deactivated successfully";
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



        //Active Status On of Food menu Category/////
        [Route("FoodMenuCategory/activeStatusFoodMenuCategory")]
        [HttpPost]
        public string activeStatusFoodMenuCategory(int intFoodCategoryID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusFoodMenuCategoryOn = objFoodMenuCategory.manageFoodMenuCategory(9, intFoodCategoryID, "", "", intKitchenID, intOutletID, 1,0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusFoodMenuCategoryOn == 0)
                {
                    return "Food Menu Category Activated successfully";
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
