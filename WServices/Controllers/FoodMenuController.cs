using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WServices.Controllers.Masters
{
    public class FoodMenuController : ApiController
    {
        WFramework.Masters.ClsFoodMenuMaster objFoodMenu = new WFramework.Masters.ClsFoodMenuMaster();


        //Get top 1000 All FoodMenu ///
        [Route("FoodMenu/readFoodMenuDetail")]
        [HttpGet]
        public string readFoodMenuDetail()
        {
            try
            {

                string readFoodMenuDetail = objFoodMenu.getFoodMenu(1,0,"","",0,"","","","",0,0,0,"","","","",0,0,0,0,0,"",0,"");

                if (readFoodMenuDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readFoodMenuDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All FoodMenu by outlet ID///
        [Route("FoodMenu/readFoodMenuDetailbyoutletID")]
        [HttpPost]
        public string readFoodMenuDetailbyoutletID(int intKitchenID, int intOutletID)
        {
            try
            {

                string readFoodMenuDetailbyoutletID = objFoodMenu.getFoodMenu(2, 0,"", "",0,"","","","",0,0,0,"","","","", intKitchenID, intOutletID, 0, 0, 0, "", 0, "");

                if (readFoodMenuDetailbyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readFoodMenuDetailbyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add Food menu /////

        [Route("FoodMenu/createFoodMenu")]
        [HttpPost]
        public string createFoodMenu(string strFoodName, string strFoodCode,int intFoodCategoryID,string decSalePrice, string strFoodMenuDescription,string strFoodMenuPhoto,string strImagePath,int intIsVeg, int intIsBeverage,
            int intIsBarItem,string decVAT,string decIGST,string decSGST,string decCGST, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int insertFoodMenudetail = objFoodMenu.manageFoodMenu(3, 0, strFoodName,  strFoodCode,  intFoodCategoryID,  decSalePrice,  strFoodMenuDescription,  strFoodMenuPhoto, strImagePath,  intIsVeg,  intIsBeverage,
             intIsBarItem, decVAT, decIGST, decIGST, decSGST,  intKitchenID,  intOutletID, 1,0, intCreatedBy, "", intModifiedBy, "");
                if (insertFoodMenudetail == 0)
                {
                    return "FoodMenu added successfully";
                }
                else if (insertFoodMenudetail == -1)
                {
                    return "FoodMenu already exist";
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
        [Route("FoodMenu/updateFoodMenu")]
        [HttpPost]
        public string updateFoodMenu(int intFoodMenuID, string strFoodName, string strFoodCode, int intFoodCategoryID, string decSalePrice, string strFoodMenuDescription, string strFoodMenuPhoto,string strImagePath, int intIsVeg, int intIsBeverage,
            int intIsBarItem, string decVAT, string decIGST, string decSGST, string decCGST, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int updateFoodMenudetail = objFoodMenu.manageFoodMenu(4, intFoodMenuID, strFoodName, strFoodCode, intFoodCategoryID, decSalePrice, strFoodMenuDescription, strFoodMenuPhoto, strImagePath, intIsVeg, intIsBeverage,
             intIsBarItem, decVAT, decIGST, decSGST, decCGST, intKitchenID, intOutletID, 1,0, intCreatedBy, "", intModifiedBy, "");
                if (updateFoodMenudetail == 0)
                {
                    return "Food Menu detail updated successfully";
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



        //Delete Food menu /////
        [Route("FoodMenu/deleteFoodMenu")]
        [HttpPost]
        public string deleteFoodMenu(int intFoodMenuID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int deleteFoodMenuByID = objFoodMenu.manageFoodMenu(6, intFoodMenuID, "", "",0,"","","","",0,0,0,"","","","", intKitchenID, intOutletID, 1, 1, intCreatedBy, "", intModifiedBy, "");

                if (deleteFoodMenuByID == 0)
                {
                    return "Food Menu  deleted successfully";
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

        //Get All Food Menu  by ID///
        [Route("FoodMenu/editByFoodMenuID")]
        [HttpPost]
        public string editByFoodMenuID(int intFoodMenuID)
        {
            try
            {

                string editByFoodMenuID = objFoodMenu.getFoodMenu(7, intFoodMenuID, "", "", 0,"","","","",0,0,0,"","","","",0,0,1,0,0, "",1,"");

                if (editByFoodMenuID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editByFoodMenuID;
                }
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        //deActive Status of Food menu /////
        [Route("FoodMenu/activeStatusFoodMenuDeActive")]
        [HttpPost]
        public string activeStatusFoodMenuDeActive(int intFoodMenuID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusFoodMenuDeActive = objFoodMenu.manageFoodMenu(5, intFoodMenuID, "", "", 0, "", "", "","", 0, 0, 0, "","","","", intKitchenID, intOutletID, 0, 0,intCreatedBy, "", intModifiedBy, "");

                if (activeStatusFoodMenuDeActive == 0)
                {
                    return "Food Menu  DeActivated successfully";
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



        //Active Status of Food menu ON /////
        [Route("FoodMenu/activeStatusFoodMenu")]
        [HttpPost]
        public string activeStatusFoodMenu(int intFoodMenuID, int intKitchenID, int intOutletID, int intCreatedBy, int intModifiedBy)
        {
            try
            {

                int activeStatusFoodMenuON = objFoodMenu.manageFoodMenu(9, intFoodMenuID, "", "", 0, "", "", "","", 0, 0, 0, "", "", "", "", intKitchenID, intOutletID, 1, 0, intCreatedBy, "", intModifiedBy, "");

                if (activeStatusFoodMenuON == 0)
                {
                    return "Food Menu  Activated successfully";
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
