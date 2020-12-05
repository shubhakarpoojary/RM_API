using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WServices.Classes;

namespace WServices.Controllers.Masters
{
    public class RestuarantInfoMasterController : ApiController
    {


        WFramework.Masters.ClsRestuarantInfoMaster objPaymentRestInfo = new WFramework.Masters.ClsRestuarantInfoMaster();
        WFramework.clsUser objUser = new WFramework.clsUser();

        //Get top 1000 All Restuarantinfo ///
        [Route("RestuarantInfoMaster/readRestuarantInfoDetail")]
        [HttpGet]
        public string readRestuarantInfoDetail()
        {
            try
            {

                string readRestuarantInfoDetail = objPaymentRestInfo.getRestuarantInfo(1, 0,"","","","","","",0,0,"","",1,1,0,"",0,"");

                if (readRestuarantInfoDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantInfoDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Get All RestuarantInfo by outlet ID///
        [Route("RestuarantInfoMaster/readRestuarantInfobyoutletID")]
        [HttpPost]
        public string readRestuarantInfobyoutletID()
        {
            try
            {

                string readRestuarantInfobyoutletID = objPaymentRestInfo.getRestuarantInfo(2, 0, "", "","","","","",0,0,"","",1,1,0,"",0,"");

                if (readRestuarantInfobyoutletID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readRestuarantInfobyoutletID;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Add RestuarantInfoDetail /////

        [Route("RestuarantInfoMaster/createRestuarantInfo")]
        [HttpPost]
        public string createRestuarantInfo(string strRestuarantName, string strRestuarantContactPerson, string strRestuarantAddress, string strRestuarantEmail, string strRestuarantPassword, string strPoweredByText,  int intTempOne, int intTempTwo, string strTempThree, string strTempFour
        )
        {
            try
            {
          
                int insertRestuarantInfo = objPaymentRestInfo.manageRestuarantInfo(3, 0, strRestuarantName, strRestuarantContactPerson,  strRestuarantAddress,  strRestuarantEmail,  strRestuarantPassword,  strPoweredByText, intTempOne, intTempTwo, strTempThree, strTempFour,  1, 1, 0, "", 0, "");
                UserManager objUMG = new UserManager();
                string strUserName = objUMG.encryptData(strRestuarantEmail);
                string strPassword = objUMG.encryptData(strRestuarantPassword);
                int createUser = objUser.ManageUser(3, 0, strUserName, strRestuarantContactPerson, "", strRestuarantContactPerson, strPassword, strTempFour, strRestuarantEmail, "", 0, "Web", 2, "", 0, 1, 1, 0, "", 0, "");

                if (insertRestuarantInfo == 0)
                {
                    return "RestuarantInfoDetail added successfully";
                }
                else if (insertRestuarantInfo == -1)
                {
                    return "RestuarantInfoDetail already exist";
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


        //Update RestuarantInfoDetail /////
        [Route("RestuarantInfoMaster/updateRestuarantInfo")]
        [HttpPost]
        public string updateRestuarantInfo(int intRestuarantID, string strRestuarantName, string strRestuarantContactPerson, string strRestuarantAddress, string strRestuarantEmail, string strRestuarantPassword, string strPoweredByText, int intTempOne, int intTempTwo, string strTempThree, string strTempFour
        )
        {
            try
            {
               
                int updateRestuarantInfo = objPaymentRestInfo.manageRestuarantInfo(4, intRestuarantID, strRestuarantName, strRestuarantContactPerson, strRestuarantAddress, strRestuarantEmail, strRestuarantPassword, strPoweredByText, intTempOne, intTempTwo, strTempThree, strTempFour,  1, 1, 0, "", 0, "");

                UserManager objUMG = new UserManager();
                string strUserName = objUMG.encryptData(strRestuarantEmail);
                string strPassword = objUMG.encryptData(strRestuarantPassword);
                int createUser = objUser.ManageUser(3, 0, strUserName, strRestuarantContactPerson, "", strRestuarantContactPerson, strPassword, strTempFour, strRestuarantEmail, "", 0, "Web", 2, "", 0, 1, 1, 0, "", 0, "");

                if (updateRestuarantInfo == 0)
                {
                    return "Restuarant Info detail updated successfully";
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


       

        //Delete Restuarant Info /////
        [Route("RestuarantInfoMaster/deleteRestuarantInfo")]
        [HttpPost]
        public string deleteRestuarantInfo(int intRestuarantID)
        {
            try
            {

                int deleteRestuarantInfo = objPaymentRestInfo.manageRestuarantInfo(6, intRestuarantID,"","","","","","",0,0,"","",1,1,0,"",0,"");

                if (deleteRestuarantInfo == 0)
                {
                    return "Restuarant Info  deleted successfully";
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

        //Get All RestuarantInfo  by ID///
        [Route("RestuarantInfoMaster/editByRestuarantInfoID")]
        [HttpPost]
        public string editByRestuarantInfoID(int intRestuarantID)
        {
            try
            {

                string editByRestuarantCustomerID = objPaymentRestInfo.getRestuarantInfo(7, intRestuarantID, "","","","","","",0,0,"","",1,1,0,"",0,"");

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

        //Active Status of RestuarantInfo /////
        [Route("RestuarantInfoMaster/activeStatusRestuarantInfo")]
        [HttpPost]
        public string activeStatusRestuarantInfo(int intRestuarantID,int intActiveDeatcive)
        {
            try
            {

                int activeStatusRestuarantInfo = objPaymentRestInfo.manageRestuarantInfo(5, intRestuarantID,"","","","","","",0,0,"","", intActiveDeatcive, 0,0,"",0,"");

                if (activeStatusRestuarantInfo == 0)
                {
                    return "Success";
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
