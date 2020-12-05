using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;
using WServices.ClassCode;
using WServices.Classes;
using System.Web.UI.WebControls;
using System.Drawing;
using System.IO;
using System.Web.UI;
using System.Net.Http.Headers;
using System.Data;
using System.Text;
using WinApps.Infrastructure;
using System.Web;
using System.Configuration;
using iTextSharp.text.pdf;
using iTextSharp.text;
using ExcelDataReader;

namespace WServices.Controllers
{
    public class WServicesController : ApiController
    {
        
        WFramework.clsUser objUser = new WFramework.clsUser();
        WFramework.clsSMS objSMS = new WFramework.clsSMS();     
        WFramework.ClsPaymentType objPaymentType = new WFramework.ClsPaymentType();
        WFramework.ClsForgetPassword objForgetPassword = new WFramework.ClsForgetPassword();
     
        WFramework.clsEmailVpsGodaddy objEmailVpsGodaddy = new WFramework.clsEmailVpsGodaddy();
        WFramework.clsWalletManagement objWalletManagement = new WFramework.clsWalletManagement();
        WFramework.clsCouponManagement objCouponManagement = new WFramework.clsCouponManagement();
        WFramework.clsRoles objRoles = new WFramework.clsRoles();
        WFramework.ClsModuleCreation ObjModuleSubmodule = new WFramework.ClsModuleCreation();
        WFramework.ClsBranchMaster objBranchMaster = new WFramework.ClsBranchMaster();
        WFramework.clsNumberSequence ObjNumberSequence = new WFramework.clsNumberSequence();
        WFramework.ClsTabConfiguration ObjTabConfiguration = new WFramework.ClsTabConfiguration();
        WFramework.ClsLicenseInfo ObjLicensceInfo = new WFramework.ClsLicenseInfo();
        WFramework.ClsApplicationLicenseInfo ObjLicensceInfomation = new WFramework.ClsApplicationLicenseInfo();     
        WFramework.ClsNotoficationManagement ObjNotification = new WFramework.ClsNotoficationManagement();

        WFramework.Masters.ClsOutletInfoMaster objOutletInfo = new WFramework.Masters.ClsOutletInfoMaster();
        WFramework.Masters.ClsKitchenInfoMaster objKitchenInfo = new WFramework.Masters.ClsKitchenInfoMaster();
        // user auth api
        [Route("userAuth")]
        [HttpPost]
        public string userAuth(string strUserName, string strPassword)
        {
            try
            {

                UserManager objUMG = new UserManager();
                strUserName = objUMG.encryptData(strUserName);
                strPassword = objUMG.encryptData(strPassword);
                string checkCredentials = "";
                checkCredentials = objUser.ReadUser(7, 0, strUserName, "", "", "", strPassword, "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");

                if (checkCredentials == "Error")
                {
                    return "Error";
                }
                else if (checkCredentials == "[]")
                {
                    return "Credentials Wrong";
                }
                else
                {
                    return checkCredentials;
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        //get menu and submenus based on role of user
        [Route("getAllMenuSubmenuList")]
        [HttpPost]
        public HttpResponseMessage getAllMenuSubmenuList(int intRoled)
        {
            try
            {
                string strResponse = ObjModuleSubmodule.GetAllMainMenu(1, intRoled);
                string ResponseSubModule = ObjModuleSubmodule.GetAllMainMenu(2, intRoled);
                var parentList = new { strResponse, ResponseSubModule };
                return Request.CreateResponse(HttpStatusCode.OK, parentList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error");
            }
        }




        [Route("readPaymentType")]
        [HttpGet]
        public string readPaymentType()
        {
            try
            {

                string readPaymentTypeDetail = objPaymentType.ReadPaymentType(1, 0, "", 1, 1, 0, "", 0, "");

                if (readPaymentTypeDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readPaymentTypeDetail;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        [Route("GetNexPaymentType")]
        [HttpPost]
        public string GetNexPaymentType(int intRowOne, int intRowTwo)
        {
            try
            {

                string readPaymentTypeDetail = objPaymentType.ReadPaymentType(6, intRowOne, "", intRowTwo, 1, 0, "", 0, "");

                if (readPaymentTypeDetail == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readPaymentTypeDetail;
                }

            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }

        }



        [Route("createPaymentType")]
        [HttpPost]
        public string createPaymentType(string strPaymentType)
        {
            try
            {

                int createPaymentType = objPaymentType.ManagePaymentType(2, 0, strPaymentType, 1, 1, 0, "", 0, "");
                if (createPaymentType == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else if (createPaymentType == -1)
                {
                    return "Area name already exist";
                }
                else
                {
                    return "Area added successfully";
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("UpdatePaymentType")]
        [HttpPost]
        public string UpdatePaymentType(int @intPaymentID, string strPaymentType)
        {
            try
            {

                int UpdatePaymentType = objPaymentType.ManagePaymentType(3, intPaymentID, strPaymentType, 1, 1, 0, "", 0, "");
                if (UpdatePaymentType == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "Area updated successfully";
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("DeletePaymentType")]
        [HttpPost]
        public string DeletePaymentType(int @intPaymentID)
        {
            try
            {

                int DeletePaymentType = objPaymentType.ManagePaymentType(4, intPaymentID, "", 1, 1, 0, "", 0, "");
                if (DeletePaymentType == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "Area deleted successfully";
                }


            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("EditByPaymentType")]
        [HttpPost]
        public string EditByPaymentType(int @intPaymentID)
        {
            try
            {

                int EditByPaymentType = objPaymentType.ManagePaymentType(5, intPaymentID, "", 1, 1, 0, "", 0, "");
                if (EditByPaymentType == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "Area deleted successfully";
                }


            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        [Route("setnewPassword")]
        [HttpPost]
        public string setnewPassword(int intEmployeeId, string strEmailid, string strMobilenumber, string strnewPassword)
        {
            try
            {

                int setnewPassword = objForgetPassword.ManageForgetPassword(1, 0, intEmployeeId, strEmailid, strMobilenumber, strnewPassword, 1, 1, 0, "", 0, "");

                if (setnewPassword == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "New Password Saved Sucessfully";
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        

        [Route("readUserAllDropDown")]
        [HttpGet]
        public string readUserAllDropDown()
        {
            try
            {

                string readUserAllDropDown = objUser.ReadUser(33, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");

                if (readUserAllDropDown == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readUserAllDropDown;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        [Route("readUserAll")]
        [HttpGet]
        public string readUserAll()
        {
            try
            {

                string readUserAll = objUser.ReadUser(2, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");

                if (readUserAll == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readUserAll;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("readNextUserAll")]
        [HttpPost]
        public string readNextUserAll(int intRowOne, int intRowTwo)
        {
            try
            {

                string readUserAll = objUser.ReadUser(17, intRowOne, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, intRowTwo, 1, 0, "", 0, "");

                if (readUserAll == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readUserAll;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        [Route("readUserAllonRoles")]
        [HttpPost]
        public string readUserAllonRoles(int intRoleID)
        {
            try
            {

                string readUserAll = objUser.ReadUser(25, 0, "", "", "", "", "", "", "", "", 0, "", intRoleID, "", 0, 0, 1, 0, "", 0, "");

                if (readUserAll == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readUserAll;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        [Route("createUser")]
        [HttpPost]
        public string createUser(string strFirstName, string strLastName, string UserName, string strPassword, string strMobileNumber, string strEmailId, string strUserType, int intRoleId, int intBranchId)
        {
            try
            {

                UserManager user = new UserManager();

                string readUserAll = objUser.ReadUser(22, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");
                JArray obj1 = JArray.Parse(readUserAll);

                string CategoryLimit = ObjLicensceInfomation.GetAllWincentShopLicenseInfomation(9, 0, 0, "", "", 1);
                JArray obj2 = JArray.Parse(CategoryLimit);

                string CateLimit = obj2[0]["SC_Limit"].ToString();
                var limit = user.decryptData(CateLimit);

                if (obj1.Count >= Convert.ToInt32(limit))
                {
                    return "Limit Exceeded";
                }
                else
                {


                    string checkUserExists = objUser.ReadUser(6, 0, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, "", 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");

                    if (checkUserExists == "[]")
                    {
                        int createUser = objUser.ManageUser(3, 0, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, "", 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");

                        if (createUser == 1)
                        {
                            return "Error occured either component or strore Procedure";
                        }
                        else
                        {
                            return "User created Sucessfully";
                        }
                    }
                    else
                    {
                        return "already exist";
                    }

                }
            

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("createUserFromWeb")]
        [HttpPost]
        public string createUserFromWeb(string strFirstName, string strLastName, string UserName, string strPassword, string strMobileNumber, string strEmailId, string strUserType, int intRoleId, int intBranchId)
        {
            try
            {
                string checkUserExists = objUser.ReadUser(6, 0, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, "", 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");
                Random random = new Random();
                var Data = random.Next(1000, 100000);
                string OTP = Convert.ToString(Data);
                if (OTP.Length > 4)
                {
                    OTP = OTP.Substring(0, 4);
                }
                if (checkUserExists == "[]")
                {
                   
                   
                    int createUser = objUser.ManageUser(21, 0, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, OTP, 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");


                    string strMessage = "Dear User , Your One Time Password(OTP) is" + ' ' + OTP;

                    if (strMobileNumber != null && strMobileNumber != "" && strMobileNumber != "undefined")
                    {
                        sendSMS(strMobileNumber,strMessage);
                    }


                    string strSubject = "One Time Password(OTP)";
                    string strBody = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional //EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'><head> <meta content='text/html; charset=utf-8' http-equiv='Content-Type' /> <meta content='width=device-width' name='viewport' /> <meta content='IE=edge' http-equiv='X-UA-Compatible' /> <title></title> <style type='text/css'> body { margin: 0; padding: 0; } table, td, tr { vertical-align: top; border-collapse: collapse; } * { line-height: inherit; } a[x-apple-data-detectors=true] { color: inherit !important; text-decoration: none !important; } </style> <style id='media-query' type='text/css'> @media (max-width: 620px) { .block-grid, .col { min-width: 320px !important; max-width: 100% !important; display: block !important; } .block-grid { width: 100% !important; } .col { width: 100% !important; } .col > div { margin: 0 auto; } img.fullwidth, img.fullwidthOnMobile { max-width: 100% !important; } .no-stack .col { min-width: 0 !important; display: table-cell !important; } .no-stack.two-up .col { width: 50% !important; } .no-stack .col.num4 { width: 33% !important; } .no-stack .col.num8 { width: 66% !important; } .no-stack .col.num4 { width: 33% !important; } .no-stack .col.num3 { width: 25% !important; } .no-stack .col.num6 { width: 50% !important; } .no-stack .col.num9 { width: 75% !important; } .video-block { max-width: none !important; } .mobile_hide { min-height: 0px; max-height: 0px; max-width: 0px; display: none; overflow: hidden; font-size: 0px; } .desktop_hide { display: block !important; max-height: none !important; } } </style></head><body class='clean-body' style='margin: 0; padding: 0; -webkit-text-size-adjust: 100%; background-color: #EAE3DD;'> <table bgcolor='#EAE3DD' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='table-layout: fixed; vertical-align: top; min-width: 320px; Margin: 0 auto; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #EAE3DD; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top;' valign='top'> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#ffffff;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:15px; padding-bottom:15px; padding-right: 0px; padding-left: 0px;'> <div align='center' class='img-container center autowidth' style='padding-right: 0px;padding-left: 0px;'><img align='center' alt='Image' border='0' class='center autowidth' src='http://eshopapi.wtipl.in/Images/CompanyLogo/CompanyLogo.png' style='text-decoration: none; -ms-interpolation-mode: bicubic; border: 0; height: auto; width: 100%; max-width: 100px; display: block;' title='Image' width='100' /> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #892C63;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#892C63;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; text-align: center; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 14px;'><span style='font-size: 28px;'><span style='font-size: 28px;'>One Time Password(OTP)</span></span></div> </div> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.8;padding-top:0px;padding-right:20px;padding-bottom:25px;padding-left:20px;'> <div style='line-height: 1.8; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 22px;'> <p style='font-size: 14px; line-height: 1.8; text-align: center; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 25px; margin: 0;'><span style='font-size: 14px;'>Hi " + UserName + ",your One Time Password(OTP) is" + " " + OTP + ".</span></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:transparent;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'> <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left: 5px;' valign='top'> <table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #892C63;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#892C63;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> </div> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.8;padding-top:0px;padding-right:20px;padding-bottom:25px;padding-left:20px;'> <div style='line-height: 1.8; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 22px;'> <p style='font-size: 14px; line-height: 1.8; text-align: center; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 25px; margin: 0;'><span style='font-size: 14px;color:white !importanat;'>Note: If you do not send the request to us, please disregard this email.<br /> If you have any questions regarding your account, please send an email to us via <a href='emailto:sameer.wincent@gmail.com' style='color:white'>sameer.wincent@gmail.com</a></span></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:transparent;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'> <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left: 5px;' valign='top'> <table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> <!--<![endif]--> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#892C63;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:10px;padding-right:20px;padding-bottom:10px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #892C63; mso-line-height-alt: 14px;'> <p style='font-size: 18px; line-height: 1.2; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><strong><span mce-data-marked='1' style='font-size: 14px;'>Contact info</span></strong></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #EDEDED;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#EDEDED;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#555555;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.5;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> <div style='line-height: 1.5; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #555555; mso-line-height-alt: 18px;'> <p style='font-size: 14px; line-height: 1.5; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 21px; margin: 0;'> <span style='font-size: 14px;'> Phone : (+91) 988 678 3967 <br> Email  : sameer.wincent@gmail.com </span> </p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#892C63;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:10px;padding-right:20px;padding-bottom:10px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #892C63; mso-line-height-alt: 14px;'> <p style='font-size: 18px;text-align:center; line-height: 1.2; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><strong><span mce-data-marked='1' style='font-size: 14px;'>--Thank you--</span></strong></p> </div> </div> </div> </div> </div> </div> </div> </div> </td> </tr> </tbody> </table></body></html>";

                    if (strEmailId != null && strEmailId != "" && strEmailId != "undefined")
                    {
                        SendEmail(strEmailId,  strSubject, strBody);
                    }

                    if (createUser == 1)
                    {
                        return "Error occured either component or strore Procedure";
                    }
                    else
                    {

                        return "User created Sucessfully";
                    }
                }
                else
                {
                    JArray objJson = JArray.Parse(checkUserExists);

                    int EmailVerified = Convert.ToInt32(objJson[0]["EmailVerfied"]);

                    if (EmailVerified == 1)
                    {
                        return "already exist";
                    }
                    else
                    {
                        int createUser1 = objUser.ManageUser(23, 0, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, OTP, 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");


                        string strMessage = "Dear User , Your One Time Password(OTP) is" + ' ' + OTP;
                        if (strMobileNumber != null && strMobileNumber != "" && strMobileNumber != "undefined")
                        {
                            sendSMS(strMobileNumber, strMessage);
                        }


                        string strSubject = "One Time Password(OTP)";
                        string strBody = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional //EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'><head> <meta content='text/html; charset=utf-8' http-equiv='Content-Type' /> <meta content='width=device-width' name='viewport' /> <meta content='IE=edge' http-equiv='X-UA-Compatible' /> <title></title> <style type='text/css'> body { margin: 0; padding: 0; } table, td, tr { vertical-align: top; border-collapse: collapse; } * { line-height: inherit; } a[x-apple-data-detectors=true] { color: inherit !important; text-decoration: none !important; } </style> <style id='media-query' type='text/css'> @media (max-width: 620px) { .block-grid, .col { min-width: 320px !important; max-width: 100% !important; display: block !important; } .block-grid { width: 100% !important; } .col { width: 100% !important; } .col > div { margin: 0 auto; } img.fullwidth, img.fullwidthOnMobile { max-width: 100% !important; } .no-stack .col { min-width: 0 !important; display: table-cell !important; } .no-stack.two-up .col { width: 50% !important; } .no-stack .col.num4 { width: 33% !important; } .no-stack .col.num8 { width: 66% !important; } .no-stack .col.num4 { width: 33% !important; } .no-stack .col.num3 { width: 25% !important; } .no-stack .col.num6 { width: 50% !important; } .no-stack .col.num9 { width: 75% !important; } .video-block { max-width: none !important; } .mobile_hide { min-height: 0px; max-height: 0px; max-width: 0px; display: none; overflow: hidden; font-size: 0px; } .desktop_hide { display: block !important; max-height: none !important; } } </style></head><body class='clean-body' style='margin: 0; padding: 0; -webkit-text-size-adjust: 100%; background-color: #EAE3DD;'> <table bgcolor='#EAE3DD' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='table-layout: fixed; vertical-align: top; min-width: 320px; Margin: 0 auto; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #EAE3DD; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top;' valign='top'> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#ffffff;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:15px; padding-bottom:15px; padding-right: 0px; padding-left: 0px;'> <div align='center' class='img-container center autowidth' style='padding-right: 0px;padding-left: 0px;'><img align='center' alt='Image' border='0' class='center autowidth' src='http://eshopapi.wtipl.in/Images/CompanyLogo/CompanyLogo.png' style='text-decoration: none; -ms-interpolation-mode: bicubic; border: 0; height: auto; width: 100%; max-width: 100px; display: block;' title='Image' width='100' /> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #892C63;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#892C63;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; text-align: center; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 14px;'><span style='font-size: 28px;'><span style='font-size: 28px;'>One Time Password(OTP)</span></span></div> </div> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.8;padding-top:0px;padding-right:20px;padding-bottom:25px;padding-left:20px;'> <div style='line-height: 1.8; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 22px;'> <p style='font-size: 14px; line-height: 1.8; text-align: center; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 25px; margin: 0;'><span style='font-size: 14px;'>Hi " + UserName + ",your One Time Password(OTP) is" + " " + OTP + ".</span></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:transparent;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'> <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left: 5px;' valign='top'> <table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #892C63;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#892C63;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> </div> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.8;padding-top:0px;padding-right:20px;padding-bottom:25px;padding-left:20px;'> <div style='line-height: 1.8; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 22px;'> <p style='font-size: 14px; line-height: 1.8; text-align: center; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 25px; margin: 0;'><span style='font-size: 14px;color:white !importanat;'>Note: If you do not send the request to us, please disregard this email.<br /> If you have any questions regarding your account, please send an email to us via <a href='emailto:sameer.wincent@gmail.com' style='color:white'>sameer.wincent@gmail.com</a></span></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:transparent;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'> <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left: 5px;' valign='top'> <table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> <!--<![endif]--> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#892C63;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:10px;padding-right:20px;padding-bottom:10px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #892C63; mso-line-height-alt: 14px;'> <p style='font-size: 18px; line-height: 1.2; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><strong><span mce-data-marked='1' style='font-size: 14px;'>Contact info</span></strong></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #EDEDED;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#EDEDED;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#555555;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.5;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> <div style='line-height: 1.5; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #555555; mso-line-height-alt: 18px;'> <p style='font-size: 14px; line-height: 1.5; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 21px; margin: 0;'> <span style='font-size: 14px;'> Phone : (+91) 988 678 3967 <br> Email  : sameer.wincent@gmail.com </span> </p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#892C63;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:10px;padding-right:20px;padding-bottom:10px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #892C63; mso-line-height-alt: 14px;'> <p style='font-size: 18px;text-align:center; line-height: 1.2; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><strong><span mce-data-marked='1' style='font-size: 14px;'>--Thank you--</span></strong></p> </div> </div> </div> </div> </div> </div> </div> </div> </td> </tr> </tbody> </table></body></html>";

                        if (strEmailId != null && strEmailId != "" && strEmailId != "undefined")
                        {
                            SendEmail(strEmailId,  strSubject, strBody);
                        }


                        return "EmailNotYetVerfied";
                    }

                   
                }


            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        [Route("editUserManagementByID")]
        [HttpPost]
        public string editUserManagementByID(int intUserId)
        {
            try
            {
                string editUserManagementByID;
                editUserManagementByID = objUser.ReadUser(13, intUserId, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 0, 0, "", 0, "");
                if (editUserManagementByID == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editUserManagementByID;
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("deleteUserManagement")]
        [HttpPost]
        public string deleteUserManagement(int intUserId)
        {
            try
            {
                int deleteUserManagement;
                deleteUserManagement = objUser.ManageUser(14, intUserId, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 0, 0, 0, "", 0, "");
                if (deleteUserManagement == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "User deleted sucessfully";
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }
        [Route("GetDetailsOnSerach")]
        [HttpPost]
        public string GetDetailsOnSerach(string strSearchTerm)
        {
            try
            {
                string GetDetailsOnSerach;
                GetDetailsOnSerach = objUser.ReadUser(15, 0, strSearchTerm, "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 0, 0, "", 0, "");
                if (GetDetailsOnSerach == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return GetDetailsOnSerach;
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }
        [Route("changePassword")]
        [HttpPost]
        public string changePassword(int intUserId, string strMobileNumber, string strEmailId, string strPassword)
        {
            try
            {


                changePasswordEmail(strEmailId, strMobileNumber, strPassword);

                int changePassword = objUser.ManageUser(11, intUserId, "", "", "", "", strPassword, strMobileNumber, strEmailId, "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");




                if (changePassword == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "Password changed Sucessfully";
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }




        [Route("updateUserManagement")]
        [HttpPost]
        public string updateUserManagement(int intUserId, string strFirstName, string strLastName, string UserName, string strPassword, string strMobileNumber, string strEmailId, string strUserType, int intRoleId, int intBranchId)
        {
            try
            {


              
                        int createUser = objUser.ManageUser(12, intUserId, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, "", 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");

                        if (createUser == 1)
                        {
                            return "Error occured either component or strore Procedure";
                        }
                        else
                        {
                            return "User Updated Sucessfully";
                        }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }




        [Route("changePasswordEmail")]
        [HttpPost]
        public string changePasswordEmail(string strEmailID, string strMobileNumber, string strPassword)
        {
            try
            {

                strMobileNumber = "";
                string strFrom = "";
                string strBody = "";

                if (strFrom == "" || strFrom == null || strFrom == "undefined")
                {
                    strFrom = "";
                }
                if (strPassword == "" || strPassword == null || strPassword == "undefined")
                {
                    strPassword = "";
                }
                string getPassword = objUser.ReadUser(16, 0, "", "", "", "", "", "", strEmailID, "", 0, "", 0, "", 0, 1, 0, 0, "", 0, "");
                
                    JArray objJson = JArray.Parse(getPassword);

                    string UserName = (objJson[0]["FirstName"]).ToString() + ' ' + (objJson[0]["LastName"]).ToString();
                    if (strFrom == "" || strFrom == null || strFrom == "undefined")
                    {
                        strFrom = "";
                    }

                string strSubject = "Your Password";
                strBody = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional //EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'><head> <meta content='text/html; charset=utf-8' http-equiv='Content-Type' /> <meta content='width=device-width' name='viewport' /> <meta content='IE=edge' http-equiv='X-UA-Compatible' /> <title></title> <style type='text/css'> body { margin: 0; padding: 0; } table, td, tr { vertical-align: top; border-collapse: collapse; } * { line-height: inherit; } a[x-apple-data-detectors=true] { color: inherit !important; text-decoration: none !important; } </style> <style id='media-query' type='text/css'> @media (max-width: 620px) { .block-grid, .col { min-width: 320px !important; max-width: 100% !important; display: block !important; } .block-grid { width: 100% !important; } .col { width: 100% !important; } .col > div { margin: 0 auto; } img.fullwidth, img.fullwidthOnMobile { max-width: 100% !important; } .no-stack .col { min-width: 0 !important; display: table-cell !important; } .no-stack.two-up .col { width: 50% !important; } .no-stack .col.num4 { width: 33% !important; } .no-stack .col.num8 { width: 66% !important; } .no-stack .col.num4 { width: 33% !important; } .no-stack .col.num3 { width: 25% !important; } .no-stack .col.num6 { width: 50% !important; } .no-stack .col.num9 { width: 75% !important; } .video-block { max-width: none !important; } .mobile_hide { min-height: 0px; max-height: 0px; max-width: 0px; display: none; overflow: hidden; font-size: 0px; } .desktop_hide { display: block !important; max-height: none !important; } } </style></head><body class='clean-body' style='margin: 0; padding: 0; -webkit-text-size-adjust: 100%; background-color: #EAE3DD;'> <table bgcolor='#EAE3DD' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='table-layout: fixed; vertical-align: top; min-width: 320px; Margin: 0 auto; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #EAE3DD; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top;' valign='top'> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#ffffff;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:15px; padding-bottom:15px; padding-right: 0px; padding-left: 0px;'> <div align='center' class='img-container center autowidth' style='padding-right: 0px;padding-left: 0px;'><img align='center' alt='Image' border='0' class='center autowidth' src='http://eshopapi.wtipl.in/Images/CompanyLogo/CompanyLogo.png' style='text-decoration: none; -ms-interpolation-mode: bicubic; border: 0; height: auto; width: 100%; max-width: 100px; display: block;' title='Image' width='100' /> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #892C63;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#892C63;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; text-align: center; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 14px;'><span style='font-size: 28px;'><span style='font-size: 28px;'>Your Password</span></span></div> </div> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.8;padding-top:0px;padding-right:20px;padding-bottom:25px;padding-left:20px;'> <div style='line-height: 1.8; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 22px;'> <p style='font-size: 14px; line-height: 1.8; text-align: center; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 25px; margin: 0;'><span style='font-size: 14px;'>Hi " + UserName + ",your password is  " + " " + strPassword + ".</span></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:transparent;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'> <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left: 5px;' valign='top'> <table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #892C63;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#892C63;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> </div> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.8;padding-top:0px;padding-right:20px;padding-bottom:25px;padding-left:20px;'> <div style='line-height: 1.8; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 22px;'> <p style='font-size: 14px; line-height: 1.8; text-align: center; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 25px; margin: 0;'><span style='font-size: 14px;color:white !importanat;'>Note: If you do not send the request to us, please disregard this email.<br /> If you have any questions regarding your account, please send an email to us via <a href='emailto:sameer.wincent@gmail.com' style='color:white'>sameer.wincent@gmail.com</a></span></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:transparent;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'> <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left: 5px;' valign='top'> <table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> <!--<![endif]--> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#892C63;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:10px;padding-right:20px;padding-bottom:10px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #892C63; mso-line-height-alt: 14px;'> <p style='font-size: 18px; line-height: 1.2; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><strong><span mce-data-marked='1' style='font-size: 14px;'>Contact info</span></strong></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #EDEDED;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#EDEDED;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#555555;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.5;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> <div style='line-height: 1.5; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #555555; mso-line-height-alt: 18px;'> <p style='font-size: 14px; line-height: 1.5; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 21px; margin: 0;'> <span style='font-size: 14px;'> Phone : (+91) 988 678 3967 <br> Email  : sameer.wincent@gmail.com </span> </p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#892C63;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:10px;padding-right:20px;padding-bottom:10px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #892C63; mso-line-height-alt: 14px;'> <p style='font-size: 18px;text-align:center; line-height: 1.2; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><strong><span mce-data-marked='1' style='font-size: 14px;'>--Thank you--</span></strong></p> </div> </div> </div> </div> </div> </div> </div> </div> </td> </tr> </tbody> </table></body></html>";

                if (strEmailID != null && strEmailID != "" && strEmailID != "undefined")
                {
                    SendEmail(strEmailID,  strSubject, strBody);
                }



                return "Success";

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }
       

        [Route("setUserNamePassword")]
        [HttpPost]
        public string setUserNamePassword(int intEmployeeId, string strUserName, string strPassword)
        {
            try
            {

                int setUserNamePassword = objUser.ManageUser(4, intEmployeeId, "", "", "", strUserName, strPassword, "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");

                if (setUserNamePassword == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "UserName and Password created Sucessfully";
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("forgetPassword")]
        [HttpPost]
        public string forgetPassword(string strEmailId)
        {
            try
            {

                string getPassword;
                getPassword = objUser.ReadUser(16, 0, "", "", "", "", "", "", strEmailId, "", 0, "", 0, "", 0, 1, 0, 0, "", 0, "");
                if (getPassword != "[]")
                {
                    JArray objJson = JArray.Parse(getPassword);
                    string strPassword = (objJson[0]["Password"]).ToString();
                    string strFrom = "";
                    string strBody = "";
                    string UserName = (objJson[0]["FirstName"]).ToString() + ' ' + (objJson[0]["LastName"]).ToString();
                    if (strFrom == "" || strFrom == null || strFrom == "undefined")
                    {
                        strFrom = "";
                    }
                    string strSubject = "Your Password";
                    strBody = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional //EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:v='urn:schemas-microsoft-com:vml'><head> <meta content='text/html; charset=utf-8' http-equiv='Content-Type' /> <meta content='width=device-width' name='viewport' /> <meta content='IE=edge' http-equiv='X-UA-Compatible' /> <title></title> <style type='text/css'> body { margin: 0; padding: 0; } table, td, tr { vertical-align: top; border-collapse: collapse; } * { line-height: inherit; } a[x-apple-data-detectors=true] { color: inherit !important; text-decoration: none !important; } </style> <style id='media-query' type='text/css'> @media (max-width: 620px) { .block-grid, .col { min-width: 320px !important; max-width: 100% !important; display: block !important; } .block-grid { width: 100% !important; } .col { width: 100% !important; } .col > div { margin: 0 auto; } img.fullwidth, img.fullwidthOnMobile { max-width: 100% !important; } .no-stack .col { min-width: 0 !important; display: table-cell !important; } .no-stack.two-up .col { width: 50% !important; } .no-stack .col.num4 { width: 33% !important; } .no-stack .col.num8 { width: 66% !important; } .no-stack .col.num4 { width: 33% !important; } .no-stack .col.num3 { width: 25% !important; } .no-stack .col.num6 { width: 50% !important; } .no-stack .col.num9 { width: 75% !important; } .video-block { max-width: none !important; } .mobile_hide { min-height: 0px; max-height: 0px; max-width: 0px; display: none; overflow: hidden; font-size: 0px; } .desktop_hide { display: block !important; max-height: none !important; } } </style></head><body class='clean-body' style='margin: 0; padding: 0; -webkit-text-size-adjust: 100%; background-color: #EAE3DD;'> <table bgcolor='#EAE3DD' cellpadding='0' cellspacing='0' class='nl-container' role='presentation' style='table-layout: fixed; vertical-align: top; min-width: 320px; Margin: 0 auto; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #EAE3DD; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top;' valign='top'> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #ffffff;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#ffffff;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:15px; padding-bottom:15px; padding-right: 0px; padding-left: 0px;'> <div align='center' class='img-container center autowidth' style='padding-right: 0px;padding-left: 0px;'><img align='center' alt='Image' border='0' class='center autowidth' src='http://eshopapi.wtipl.in/Images/CompanyLogo/CompanyLogo.png' style='text-decoration: none; -ms-interpolation-mode: bicubic; border: 0; height: auto; width: 100%; max-width: 100px; display: block;' title='Image' width='100' /> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #892C63;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#892C63;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; text-align: center; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 14px;'><span style='font-size: 28px;'><span style='font-size: 28px;'>Your Password</span></span></div> </div> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.8;padding-top:0px;padding-right:20px;padding-bottom:25px;padding-left:20px;'> <div style='line-height: 1.8; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 22px;'> <p style='font-size: 14px; line-height: 1.8; text-align: center; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 25px; margin: 0;'><span style='font-size: 14px;'>Hi " + UserName + ",your password is " + " " + strPassword + ".</span></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:transparent;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'> <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left: 5px;' valign='top'> <table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #892C63;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#892C63;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> </div> <div style='color:#FFFFFF;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.8;padding-top:0px;padding-right:20px;padding-bottom:25px;padding-left:20px;'> <div style='line-height: 1.8; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #FFFFFF; mso-line-height-alt: 22px;'> <p style='font-size: 14px; line-height: 1.8; text-align: center; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 25px; margin: 0;'><span style='font-size: 14px;color:white !importanat;'>Note: If you do not send the request to us, please disregard this email.<br /> If you have any questions regarding your account, please send an email to us via <a href='emailto:sameer.wincent@gmail.com' style='color:white'>sameer.wincent@gmail.com</a></span></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:transparent;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: transparent;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:transparent;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:5px; padding-bottom:5px; padding-right: 0px; padding-left: 0px;'> <table border='0' cellpadding='0' cellspacing='0' class='divider' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td class='divider_inner' style='word-break: break-word; vertical-align: top; min-width: 100%; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%; padding-top: 5px; padding-right: 5px; padding-bottom: 5px; padding-left: 5px;' valign='top'> <table align='center' border='0' cellpadding='0' cellspacing='0' class='divider_content' role='presentation' style='table-layout: fixed; vertical-align: top; border-spacing: 0; border-collapse: collapse; mso-table-lspace: 0pt; mso-table-rspace: 0pt; border-top: 0px solid transparent; width: 100%;' valign='top' width='100%'> <tbody> <tr style='vertical-align: top;' valign='top'> <td style='word-break: break-word; vertical-align: top; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;' valign='top'><span></span></td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </div> <!--<![endif]--> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#892C63;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:10px;padding-right:20px;padding-bottom:10px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #892C63; mso-line-height-alt: 14px;'> <p style='font-size: 18px; line-height: 1.2; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><strong><span mce-data-marked='1' style='font-size: 14px;'>Contact info</span></strong></p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #EDEDED;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#EDEDED;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#555555;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.5;padding-top:20px;padding-right:20px;padding-bottom:20px;padding-left:20px;'> <div style='line-height: 1.5; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #555555; mso-line-height-alt: 18px;'> <p style='font-size: 14px; line-height: 1.5; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 21px; margin: 0;'> <span style='font-size: 14px;'> Phone : (+91) 988 678 3967 <br> Email  : sameer.wincent@gmail.com </span> </p> </div> </div> </div> </div> </div> </div> </div> </div> <div style='background-color:#EAE3DD;'> <div class='block-grid' style='Margin: 0 auto; min-width: 320px; max-width: 600px; overflow-wrap: break-word; word-wrap: break-word; word-break: break-word; background-color: #FFFFFF;'> <div style='border-collapse: collapse;display: table;width: 100%;background-color:#FFFFFF;'> <div class='col num12' style='min-width: 320px; max-width: 600px; display: table-cell; vertical-align: top; width: 600px;'> <div style='width:100% !important;'> <div style='border-top:0px solid transparent; border-left:0px solid transparent; border-bottom:0px solid transparent; border-right:0px solid transparent; padding-top:0px; padding-bottom:0px; padding-right: 0px; padding-left: 0px;'> <div style='color:#892C63;font-family:Arial, Helvetica Neue, Helvetica, sans-serif;line-height:1.2;padding-top:10px;padding-right:20px;padding-bottom:10px;padding-left:20px;'> <div style='line-height: 1.2; font-size: 12px; font-family: Arial, Helvetica Neue, Helvetica, sans-serif; color: #892C63; mso-line-height-alt: 14px;'> <p style='font-size: 18px;text-align:center; line-height: 1.2; font-family: lucida sans unicode, lucida grande, sans-serif; word-break: break-word; mso-line-height-alt: 22px; margin: 0;'><strong><span mce-data-marked='1' style='font-size: 14px;'>--Thank you--</span></strong></p> </div> </div> </div> </div> </div> </div> </div> </div> </td> </tr> </tbody> </table></body></html>";


                    if (strEmailId != null && strEmailId != "" && strEmailId != "undefined")
                    {
                        SendEmail(strEmailId,  strSubject, strBody);
                    }

                   

                    return "Mail Sent";
                }
                else
                {
                    return "EmailId not Found";
                }

                //int forgetPassword = objUser.ManageUser(4, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");

                //if (forgetPassword == 1)
                //{
                //    return "Error occured either component or strore Procedure";
                //}
                //else
                //{
                //    return "Password updated Sucessfully";
                //}
                return "Success";
            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

     
        [Route("createUserFromMobile")]
        [HttpPost]
        public string createUserFromMobile(string strMobileNumber,string DeviceToken)
        {
            try
            {

                DeviceToken = " ";
                string checkUserExists = objUser.ReadUser(6, 0, "", "", "", DeviceToken, "", strMobileNumber, "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");
                Random random = new Random();
                var Data = random.Next(1000, 100000);
                string OTP = Convert.ToString(Data);
                if (OTP.Length > 4)
                {
                    OTP = OTP.Substring(0, 4);
                }
                if (checkUserExists == "[]")
                {


                    int createUser = objUser.ManageUser(26, 0, "", "", "", DeviceToken, "", strMobileNumber, "", OTP, 0, "", 0, "", 0, 1, 1, 0, "", 0, "");


                    string strMessage = "Dear User , Your One Time Password(OTP) is" + ' ' + OTP;
                    sendSMS(strMobileNumber, strMessage);

                    if (createUser == 1)
                    {
                        return "Error occured either component or strore Procedure";
                    }
                    else
                    {

                        return "UsercreatedSucessfully";
                    }
                }
                else
                {
                    int createUser1 = objUser.ManageUser(28, 0, "", "", "", DeviceToken, "", strMobileNumber, "", OTP, 0, "", 0, "", 0, 1, 1, 0, "", 0, "");

                    string strMessage = "Dear User , Your One Time Password(OTP) is" + ' ' + OTP;
                    sendSMS(strMobileNumber, strMessage);
                    return "UsercreatedSucessfully";          

                }


            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("createUserFromGoogleorFB")]
        [HttpPost]
        public string createUserFromGoogleorFB(string strFirstName, string strLastName, string UserName, string strPassword, string strMobileNumber, string strEmailId, string strUserType, int intRoleId, int intBranchId)
        {
            try
            {
                string checkUserExists = objUser.ReadUser(31, 0, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, "", 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");

                if (checkUserExists == "[]")
                {
                    int createUser = objUser.ManageUser(32, 0, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, "", 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");

                    string checkUserExists1 = objUser.ReadUser(31, 0, "", strFirstName, strLastName, UserName, strPassword, strMobileNumber, strEmailId, "", 0, strUserType, intRoleId, "", 0, 1, intBranchId, 0, "", 0, "");

                    return checkUserExists1;
                }
                else
                {
                    return checkUserExists;

                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        [Route("ResendOTP")]
        [HttpPost]
        public string ResendOTP(string strMobileNumber)
        {
            Random random = new Random();
            var Data = random.Next(1000, 100000);
            string OTP = Convert.ToString(Data);
            if (OTP.Length > 4)
            {
                OTP = OTP.Substring(0, 4);
            }
            int createUser1 = objUser.ManageUser(29, 0, "", "", "", "", "", strMobileNumber, "", OTP, 0, "", 0, "", 0, 1, 1, 0, "", 0, "");

            string strMessage = "Dear User , Your One Time Password(OTP) is" + ' ' + OTP;
            sendSMS(strMobileNumber,strMessage);
            return "OtpResentSuccessfully";

        }


        [Route("verifySMSOTPbyMbl")]
        [HttpPost]
        public string verifySMSOTPbyMbl(string strOTPNumber, string strMobileNumber)
        {
            try
            {
                string verifySMSOTP;
                verifySMSOTP = objUser.ReadUser(27, 0, "", "", "", "", "", strMobileNumber, "", strOTPNumber, 0, "", 0, "", 0, 1, 1, 0, "", 0, "");
                if (verifySMSOTP == "[]")
                {
                    return "Enter OTP is not valid";
                }
                else if (verifySMSOTP == "Error")
                {
                    return "Error";
                }
                else
                {
                    return verifySMSOTP;
                }

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        [Route("readCouponManagement")]
        [HttpGet]
        public string readCouponManagement()
        {
            try
            {
                string readCouponManagement = "";
                readCouponManagement = objCouponManagement.ReadCouponMangement(1, 0, "", 0, "", "", "", "", "", 1, 1, 0, "", 0, "");
                if (readCouponManagement == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readCouponManagement;
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("readNextCouponManagement")]
        [HttpPost]
        public string readNextCouponManagement(int intRowOne, int intRowTwo)
        {
            try
            {
                string readCouponManagement = "";
                readCouponManagement = objCouponManagement.ReadCouponMangement(7, intRowOne, "", 0, "", "", "", "", "", intRowTwo, 1, 0, "", 0, "");
                if (readCouponManagement == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readCouponManagement;
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        [Route("createCouponManagement")]
        [HttpPost]
        public string createCouponManagement(int IntMaxNoOfUse, string strStartDate, string strEndDate, string strDiscountType, string strDiscount, string strComment)
        {
            try
            {

                string strSequenceType = "COUPON_CODE";
                string getBillSequence = "";
                getBillSequence = objBranchMaster.GetAllNextSequences(1, strSequenceType, 1, "");
                JArray objJSON5 = JArray.Parse(getBillSequence);

                string StrSequenceTypeCode = objJSON5[0]["Sequence"].ToString();
                string Prefix = objJSON5[0]["Prefix"].ToString();

                string lastno = StrSequenceTypeCode;
                DateTime today = DateTime.Today;
                int createCouponManagement;
                createCouponManagement = objCouponManagement.MangaeCouponMangement(2, 0, StrSequenceTypeCode, IntMaxNoOfUse, strStartDate, strEndDate, strDiscountType, strDiscount, strComment, 1, 1, 0, "", 0, "");
                ClsNumberSequence Cls = new ClsNumberSequence();
                string dateyear = Convert.ToDateTime(today).ToString("yy/");
                string[] splits12 = lastno.Split(new string[] { Prefix }, StringSplitOptions.None);

                Cls.Incrementsequence("COUPON_CODE", Convert.ToInt32(splits12[1]), "");

                if (createCouponManagement == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "Coupon added sucessfully";
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("updateCouponManagement")]
        [HttpPost]
        public string updateCouponManagement(int intCouponId, string strCouponCode, int IntMaxNoOfUse, string strStartDate, string strEndDate, string strDiscountType, string strDiscount, string strComment)
        {
            try
            {
                int updateTaxManagement;
                updateTaxManagement = objCouponManagement.MangaeCouponMangement(3, intCouponId, strCouponCode, IntMaxNoOfUse, strStartDate, strEndDate, strDiscountType, strDiscount, strComment, 1, 1, 0, "", 0, "");
                if (updateTaxManagement == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "Coupon updated sucessfully";
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        [Route("deleteCouponManagement")]
        [HttpPost]
        public string deleteCouponManagement(int intCouponId)
        {
            try
            {
                int deleteCouponManagement;
                deleteCouponManagement = objCouponManagement.MangaeCouponMangement(4, intCouponId, "", 0, "", "", "", "", "", 1, 1, 0, "", 0, "");
                if (deleteCouponManagement == 1)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "Coupon deleted sucessfully";
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        [Route("editCouponManagementById")]
        [HttpPost]
        public string editCouponManagementById(int intCouponId)
        {
            try
            {
                string editCouponManagementById;
                editCouponManagementById = objCouponManagement.ReadCouponMangement(5, intCouponId, "", 0, "", "", "", "", "", 1, 1, 0, "", 0, "");
                if (editCouponManagementById == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return editCouponManagementById;
                }


            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        [Route("UserCouponInsert")]
        [HttpPost]
        public string UserCouponInsert(string StrCoupon, int UserId)
        {
            try
            {
                string readCouponManagement = "";
                readCouponManagement = objCouponManagement.ReadCouponMangement(6, 0, StrCoupon, 0, "", "", "", "", "", 1, 1, 0, "", 0, "");

                if (readCouponManagement != "[]")
                {
                    string readUserCouponManagement = "";
                    readUserCouponManagement = objCouponManagement.ReadUserIDManegement(2, 0, UserId, StrCoupon, 1, 1, 1, "", 1, "");


                    if (readUserCouponManagement == "[]")
                    {

                        int IntreadUserCouponManagement = objCouponManagement.MangaeUserIDManegement(3, 0, UserId, StrCoupon, 1, 1, 1, "", 1, "");

                        if (IntreadUserCouponManagement == 0)
                        {
                            return "Copuon Is  Used Sucessufully";
                        }
                        else
                        {
                            return "Error From Server Side";

                        }
                    }

                    else
                    {

                        return "Copuon Is already Used";
                    }

                }
                else
                {


                    return "Copuon Is Expired";
                }
                return "Copuon Is Expired";
            }

            catch (Exception ex)
            {


                return "Error";

            }
        }


        [Route("CouponCheckForUser")]
        [HttpPost]
        public string CouponCheckForUser(string StrCoupon, int UserId)
        {
            try
            {
                string readCouponManagement = "";
                readCouponManagement = objCouponManagement.ReadCouponMangement(6, 0, StrCoupon, 0, "", "", "", "", "", 1, 1, 0, "", 0, "");

                if (readCouponManagement != "[]")
                {
                    string readUserCouponManagement = "";
                    readUserCouponManagement = objCouponManagement.ReadUserIDManegement(2, 0, UserId, StrCoupon, 1, 1, 1, "", 1, "");


                    if (readUserCouponManagement == "[]")
                    {

                        return "Copuon Is ready to use to User";
                    }

                    else
                    {

                        return "Copuon Is already Used By User";
                    }

                }
                else
                {

                    return "Copuon Is Expired";
                }
          
            }

            catch (Exception ex)
            {


                return "Error";

            }
        }


        [Route("CouponCheckExists")]
        [HttpPost]
        public string CouponCheckExists(int intUserID)
        {
            try
            {
                string readCouponManagement = "";
                readCouponManagement = objCouponManagement.ReadCouponMangement(8, intUserID, "", 0, "", "", "", "", "", 1, 1, 0, "", 0, "");
                return readCouponManagement;
            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



        //Settings Module //

                //Get All Role Master
        [Route("GetAllRole")]
        [HttpPost]
        public string GetAllRole(int intRoleId)
        {
            try
            {
                string strResponse = "";
                if (intRoleId == 1)
                {
                    strResponse = objRoles.GetAllRoles(7, intRoleId, "", 1, "");
                }
                else
                {
                    strResponse = objRoles.GetAllRoles(1, intRoleId, "", 1, "");
                }


                if (strResponse == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return strResponse;
                }

            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }

        }


        [Route("GetNextAllRole")]
        [HttpPost]
        public string GetNextAllRole(int intRowOne, int intRowTwo)
        {
            try
            {
                string strResponse = "";

                strResponse = objRoles.GetAllRoles(9, intRowOne, "", intRowTwo, "");

                if (strResponse == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return strResponse;
                }

            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }

        }


        //Add Role Master

        [Route("AddRoles")]
        [HttpPost]
        public string AddRoles(string ROLE_NAME)
        {
            try
            {

                string strResponse = "";
                strResponse = objRoles.GetAllRoles(12, 0, ROLE_NAME, 1, "");

                if (strResponse == "[]")
                {


                    string strResponse1 = objRoles.CreateRole(ROLE_NAME, "Admin");
                    return strResponse;
                }
                else
                {
                    return "already exist";
                }
            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }



        //Update Role Master

        [Route("UpdateRoles")]
        [HttpPost]
        public string UpdateRoles(int ROLE_ID, string ROLE_NAME)
        {
            try
            {

                int x;
                x = objRoles.USP_UPDATE_ROLE_Testing(ROLE_ID, ROLE_NAME, "Admin");
                return "Roles List Updated";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }



        //Get All Role Edit Master
        [Route("GetRolesEdit")]
        [HttpPost]
        public string GetRolesEdit(int id)
        {
            try
            {
                // WinAppsFrameWork.clsRoles objRoles = new WinAppsFrameWork.clsRoles();
                string strResponse = objRoles.CheckRolesIsExistUpdate_Testing(2, "", id);
                return strResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }




        [Route("DeleteRoles")]
        [HttpPost]
        public string DeleteRoles(string rolesId)
        {
            try
            {
                if (!String.IsNullOrEmpty(rolesId))
                {
                    try
                    {
                        int id = Convert.ToInt32(rolesId);

                        //WinAppsFrameWork.clsRoles objRole = new WinAppsFrameWork.clsRoles();
                        int x = objRoles.USP_DELETE_ROLE_Testing(id);
                        string strResponse = objRoles.USP_Admin_GetEmployee_Testing_Testing(id);
                        int y = objRoles.Usp_DeleteEmployeAssignByRole_Testing(id);
                        JArray objJSON = JArray.Parse(strResponse);
                        int intx = objJSON.Count;
                        int z;
                        for (int i = 0; i < intx; i++)
                        {
                            z = objRoles.Usp_DeleteUserAssignByRole_Testing(Convert.ToInt32(objJSON[i]["EMPLOYEE_ID"]));
                        }
                        return "Role Deleted";

                    }
                    catch (Exception ex)
                    {
                        return "Employee Not Found";
                    }
                }
                else
                {
                    return "Invalid Request";
                }
            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }


        [Route("TreeViewNameTypes")]
        [HttpPost]
        public HttpResponseMessage TreeViewNameTypes(int RoleId)
        {
            try
            {

                string AssignedModules = objRoles.GetAllRoles(5, RoleId, "", 1, "");

                string AssignedSubModules = objRoles.GetAllRoles(6, RoleId, "", 1, "");


                var parentList = new { AssignedModules, AssignedSubModules };
                return Request.CreateResponse(HttpStatusCode.OK, parentList);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, "Error");
            }
        }


        [Route("getModulesSubModulesById")]
        [HttpPost]
        public HttpResponseMessage getModulesSubModulesById(int intRoleId,int intOutletID)
        {
            try
            {
                string RoleAssignedModules = objRoles.GetAllRoles(5, intRoleId, "", 1, "");

                string RoleAssignedSubModules = objRoles.GetAllRoles(6, intRoleId, "", 1, "");

                var FullList = new { RoleAssignedModules, RoleAssignedSubModules };

                return Request.CreateResponse(HttpStatusCode.OK, FullList);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error");
            }
        }

        [Route("Assignvalue")]
        [HttpPost]
        public HttpResponseMessage Assignvalue(string rolename)
        {
            try
            {
                // WinAppsFrameWork.clsRoles objRole = new WinAppsFrameWork.clsRoles();
                string strResponse = objRoles.USP_Admin_GetRoleID_Testing(rolename);
                JArray objJSON = JArray.Parse(strResponse);
                int intRoleID = Convert.ToInt32(objJSON[0]["ROLE_ID"]);
                int intOutletID = Convert.ToInt32(objJSON[0]["OUTLET_ID"]);
                int x = objRoles.USP_UPDATE_ROLE_MODULES_AND_SUBMODULES_Testing(intRoleID,"", intOutletID);
                //return Json("success", JsonRequestBehavior.AllowGet);
                return Request.CreateResponse(HttpStatusCode.OK, "success");
            }
            catch (Exception ex)
            {
                //return Json("", JsonRequestBehavior.AllowGet);
                return Request.CreateResponse(HttpStatusCode.OK, "");
            }
        }





        [Route("AssignModules")]
        [HttpPost]
        public HttpResponseMessage AssignModules(List<AssignRoles> RoleAcc)
        {
            try
            {
                short Role_Id = 0;

                if (RoleAcc == null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Done");
                }
                else
                {
                    foreach (var item in RoleAcc)
                    {
                        Role_Id = item.ROLE_ID;
                        break;
                    }
                    int x;

                    x = objRoles.AssignModuleSubModule(5, 0, 0, Role_Id, "");

                    foreach (var item in RoleAcc)
                    {
                        if (item.SubMenu != null)
                        {
                            int addcustMod = objRoles.ManageCustomerModuleSubModule(1, 0, 1, item.MODULE_ID, "", 0, 0, "", "", "T", "", "", "", "");
                            x = objRoles.AssignModuleSubModule(4, item.MODULE_ID, 0, item.ROLE_ID, "");

                            foreach (var item11 in item.SubMenu)
                            {
                                //string subid = item11.SUBMODULE_ID.Split(',')[0].Trim();
                                int id = Convert.ToInt32(item11.SUBMODULE_ID);

                                int addcustSubMod = objRoles.ManageCustomerModuleSubModule(2, 0, 0, item.MODULE_ID, "", 0, Convert.ToInt16(id), "", "", "T", "", "", "", "");
                                x = objRoles.AssignModuleSubModule(3, item.MODULE_ID, Convert.ToInt16(id), item.ROLE_ID, "");
                            }
                        }


                    }
                    return Request.CreateResponse(HttpStatusCode.OK, "Success");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error");
            }
            //return "fail";
        }

        [Route("AssignPermissionssss")]
        [HttpPost]
        public HttpResponseMessage AssignPermissionssss(int id)
        {
            try
            {


                //  WinAppsFrameWork.clsRoles objAccessPermission = new WinAppsFrameWork.clsRoles();


                string strFlag1Response, strFlag2Response, strFlag3Response, strFlag4Response, strres;

                strres = objRoles.GetAccessPermissionEdit(5, 0, 0, id);
                if (strres == "[]")
                {
                    //return Json("Module not assigned", JsonRequestBehavior.AllowGet);
                    return Request.CreateResponse(HttpStatusCode.OK, "Module not assigned");
                }


                List<AssignPermissionRoleWise> LstRoleWise = new List<AssignPermissionRoleWise>();
                AssignPermissionRoleWise RoleWise = new AssignPermissionRoleWise();
                RoleWise.ROLE_ID = id;
                strFlag1Response = objRoles.GetAccessPermissionEdit(1, 0, 0, RoleWise.ROLE_ID);
                JArray objJSONFlag1Response1 = JArray.Parse(strFlag1Response);
                RoleWise.ROLE_NAME = objJSONFlag1Response1[0]["ROLE_NAME"].ToString();


                List<RoleWiseModule> lstModule = new List<RoleWiseModule>();
                List<RoleWiseSubModule> lstSubModule = new List<RoleWiseSubModule>();
                List<RoleWiseAccess> lstRoleWiseAccess = new List<RoleWiseAccess>();

                strFlag2Response = objRoles.GetAccessPermissionEdit(2, 0, 0, RoleWise.ROLE_ID);
                JArray objJSONFlag2Response = JArray.Parse(strFlag2Response);
                int intModuleCount = objJSONFlag2Response.Count;

                for (int i = 0; i < intModuleCount; i++)
                {
                    RoleWiseModule Module = new RoleWiseModule();
                    Module.MODULE_ID = Convert.ToInt32(objJSONFlag2Response[i]["MODULE_ID"]);              //i.MODULE_ID;
                    Module.MODULE_NAME = objJSONFlag2Response[i]["MODULE_DESC"].ToString();                //i.TBL_MODULES_MASTER.MODULE_NAME;
                    strFlag3Response = objRoles.GetAccessPermissionEdit(3, Module.MODULE_ID, 0, RoleWise.ROLE_ID);

                    JArray objJSONFlag3Response = JArray.Parse(strFlag3Response);
                    int intSubMdouleCount = objJSONFlag3Response.Count;

                    for (int j = 0; j < intSubMdouleCount; j++)
                    {
                        RoleWiseSubModule userInfo = new RoleWiseSubModule();
                        userInfo.MODULE_ID = Convert.ToInt32(objJSONFlag3Response[j]["MODULE_ID"]);                        //Convert.ToInt16(i.MODULE_ID.ToString());
                        userInfo.SUBMODULE_ID = Convert.ToInt32(objJSONFlag3Response[j]["SUBMODULE_ID"]);//
                        userInfo.SUBMODULE_NAME = objJSONFlag3Response[j]["SUBMODULE_DESC"].ToString();

                        strFlag4Response = objRoles.GetAccessPermissionEdit(4, Module.MODULE_ID, userInfo.SUBMODULE_ID, RoleWise.ROLE_ID);

                        JArray objJSONFlag4Response = JArray.Parse(strFlag4Response);
                        int intAccessCount = objJSONFlag4Response.Count;


                        for (int k = 0; k < intAccessCount; k++)
                        {
                            RoleWiseAccess Ra = new RoleWiseAccess();
                            Ra.ROLE_ACCESS_ID = Convert.ToInt32(objJSONFlag4Response[k]["ROLE_ACCESS_ID"]);          //k.ROLE_ACCESS_ID;
                            Ra.ROLE_ID = id;
                            Ra.MODULE_ID = Convert.ToInt32(objJSONFlag4Response[k]["MODULE_ID"]);                      //i.MODULE_ID;
                            Ra.SUBMODULE_ID = Convert.ToInt32(objJSONFlag4Response[k]["SUBMODULE_ID"]);
                            Ra.SUBMODULE_NAME = objJSONFlag4Response[k]["SUBMODULE_NAME"].ToString();    //j.SUBMODULE_ID;
                            Ra.READ_ACCESS = Convert.ToBoolean(objJSONFlag4Response[k]["READ_ACCESS"]);                                    //k.READ_ACCESS;
                            Ra.WRITE_ACCESS = Convert.ToBoolean(objJSONFlag4Response[k]["WRITE_ACCESS"]);               // k.WRITE_ACCESS;
                            Ra.DELETE_ACCESS = Convert.ToBoolean(objJSONFlag4Response[k]["DELETE_ACCESS"]);// k.DELETE_ACCESS;
                            Ra.UPDATE_ACCESS = Convert.ToBoolean(objJSONFlag4Response[k]["UPDATE_ACCESS"]); //k.UPDATE_ACCESS;
                            Ra.EXPORT_ACCESS = Convert.ToBoolean(objJSONFlag4Response[k]["EXPORT_ACCESS"]); //k.EXPORT_ACCESS;
                            Ra.IMPORT_ACCESS = Convert.ToBoolean(objJSONFlag4Response[k]["IMPORT_ACCESS"]);// k.IMPORT_ACCESS;
                            lstRoleWiseAccess.Add(Ra);
                        }
                        lstSubModule.Add(userInfo);
                    }
                    lstModule.Add(Module);
                }

                RoleWise.RlCModule = lstModule;
                RoleWise.RlCSModule = lstSubModule;
                RoleWise.lRoleAccess = lstRoleWiseAccess;
                LstRoleWise.Add(RoleWise);

                // return Json(LstRoleWise, JsonRequestBehavior.AllowGet);

                return Request.CreateResponse(HttpStatusCode.OK, LstRoleWise);




                //return Json(lstrole, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //return Json("Invalid Request", JsonRequestBehavior.AllowGet);

                return Request.CreateResponse(HttpStatusCode.OK, "Invalid Request");
            }
        }


      
        [Route("AssignPermissionSave")]
        [HttpPost]
        public HttpResponseMessage AssignPermissionSave(List<RoleWiseAccess> moduleid)
        {
            try
            {

                int x;
                foreach (var RolePermi in moduleid)
                {

                    x = objRoles.AssignAccessPermissionEdit(RolePermi.ROLE_ACCESS_ID, Convert.ToInt32(RolePermi.READ_ACCESS), Convert.ToInt32(RolePermi.WRITE_ACCESS), Convert.ToInt32(RolePermi.DELETE_ACCESS), Convert.ToInt32(RolePermi.UPDATE_ACCESS), Convert.ToInt32(RolePermi.EXPORT_ACCESS), Convert.ToInt32(RolePermi.IMPORT_ACCESS), "", RolePermi.MODULE_ID, RolePermi.SUBMODULE_ID, 1,RolePermi.OUTLET_ID);
                    //int Hotlinks = objRoles.ManageHotlinks(3, 0, RolePermi.ROLE_ID, RolePermi.MODULE_ID, RolePermi.SUBMODULE_ID, 0, 1, 1, "", "", "", "");
                }

                return Request.CreateResponse(HttpStatusCode.OK, "Done");
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, "Invalid Request");
            }

        }


        [Route("getAccessPermission_TabInfo")]
        [HttpPost]
        public HttpResponseMessage getAccessPermission_TabInfo(int intModuleID, int intSubModuleID, int intRoleId)
        {
            string AccessPermission = objRoles.GetAccessPermissionEdit(8, intModuleID, intSubModuleID, intRoleId);
            string TabInfo = ObjTabConfiguration.GetAllTabConfiguration(22, intModuleID, intSubModuleID, intRoleId, 0, 0, 0, 0, "", "", "", "", "", 0);

            var parentList = new { TabInfo, AccessPermission };
            return Request.CreateResponse(HttpStatusCode.OK, parentList);

        }


        [Route("CheckRolesIsExistAdd")]
        [HttpPost]
        public string CheckRolesIsExistAdd(string rolename)
        {

            string strResponse = objRoles.CheckRoleNameExists(rolename);
            return strResponse;
        }
        [Route("CheckRolesIsExistUpdate")]
        [HttpPost]
        public string CheckRolesIsExistUpdate(string rolename, string roleid)
        {
            try
            {

                string strResponse = objRoles.CheckRolesIsExistUpdate_Testing(1, rolename, Convert.ToInt32(roleid));
                return strResponse;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }




 



        [Route("GetAllBranches")]
        [HttpPost]
        public string GetAllBranches(int RoleId)
        {
            try
            {

                if (RoleId == 2)
                {
                    string strResponse = "";
                    strResponse = objBranchMaster.GetAllBranchMaster(1, 0, "", "", "", "", "", "", "", "", 1, "", "", "", "", "");
                    return strResponse;

                }

                else
                {
                    string strResponse = "";
                    strResponse = objBranchMaster.GetAllBranchMaster(15, 0, "", "", "", "", "", "", "", "", 1, "", "", "", "", "");
                    return strResponse;

                }
            }
            catch (Exception ex)
            {
                return "Error";
            }

        }


        [Route("getNextBranches")]
        [HttpPost]
        public string getNextBranches(int intRowOne, int intRowTwo)
        {
            try
            {

                string strResponse = "";
                strResponse = objBranchMaster.GetAllBranchMaster(23, intRowOne, "", "", "", "", "", "", "", "", intRowTwo, "", "", "", "", "");
                return strResponse;

            }
            catch (Exception ex)
            {
                return "";
            }
        }


        [Route("AddBranchMaster")]
        [HttpPost]
        public string AddBranchMaster(int BranchId, string StrBranchName, string StrBranchAddress, string StrBranchPhoneNo, string StrBranchFaxNo, string StrBranchEmailID, string StrBranchWebSite, string StrBranchDescription)
        {
            try
            {

                UserManager user = new UserManager();

                if (StrBranchFaxNo == null || StrBranchFaxNo == "")
                {
                    StrBranchFaxNo = "";
                }
                if (StrBranchWebSite == null || StrBranchWebSite == "")
                {
                    StrBranchWebSite = "";
                }
                if (StrBranchDescription == null || StrBranchDescription == "")
                {
                    StrBranchDescription = "";
                }

                string strSequenceType = "BRANCH_CODE";
                string getBillSequence = "";
                getBillSequence = objBranchMaster.GetAllNextSequences(1, strSequenceType, 1, "");
                JArray objJSON5 = JArray.Parse(getBillSequence);

                string StrBranchCode = objJSON5[0]["Sequence"].ToString();
                string Prefix = objJSON5[0]["Prefix"].ToString();
                string availablebranch = objBranchMaster.GetAllBranchMaster(21, BranchId, "", "", "", "", "", "", "", "", 1, "", "", "", "", "");

                JArray objJSON3 = JArray.Parse(availablebranch);
                int intbedno1 = Convert.ToInt32(objJSON3[0]["BranchCount"]);
                string branchlimit = objBranchMaster.GetAllBranchMaster(22, BranchId, "", "", "", "", "", "", "", "", 1, "", "", "", "", "");



                string Response = "";
                Response = objBranchMaster.GetAllBranchMaster(13, BranchId, "", "", "", StrBranchPhoneNo, "", "", "", "", 1, "", "", "", "", "");
                if (Response != "[]")
                {
                    return "this phone no already exists";
                }

                string strResponse = "";
                strResponse = objBranchMaster.GetAllBranchMaster(12, BranchId, "", StrBranchName, "", "", "", "", "", "", 1, "", "", "", "", "");

                if (strResponse == "[]")
                {
                    string lastno = StrBranchCode;
                    DateTime today = DateTime.Today;

                    int intRtn = objBranchMaster.ManageBranchMaster(2, 0, StrBranchCode, StrBranchName, StrBranchAddress, StrBranchPhoneNo, StrBranchFaxNo, StrBranchEmailID, StrBranchWebSite, StrBranchDescription, 1, "", "", "", "", "");
                    ClsNumberSequence Cls = new ClsNumberSequence();

                    string dateyear = Convert.ToDateTime(today).ToString("yy/");
                    string[] splits12 = lastno.Split(new string[] { Prefix }, StringSplitOptions.None);

                    Cls.Incrementsequence("BRANCH_CODE", Convert.ToInt32(splits12[1]), "");
                    return "BranchMaster List Added";
                }



                else
                {
                    return "already exist";
                }


            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }


        [Route("GetBranchMasterById")]
        [HttpPost]
        public string GetBranchMasterById(int IntBranchid, int RoleId)
        {
            try
            {

                if (RoleId == 2)
                {

                    string strResponse = "";
                    strResponse = objBranchMaster.GetAllBranchMaster(5, IntBranchid, "", "", "", "", "", "", "", "", 1, "", "", "", "", "");
                    return strResponse;
                }
                else
                {
                    string strResponse = "";
                    strResponse = objBranchMaster.GetAllBranchMaster(5, IntBranchid, "", "", "", "", "", "", "", "", 1, "", "", "", "", "");
                    return strResponse;
                }

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        [Route("UpdateBranchMaster")]
        [HttpPost]
        public string UpdateBranchMaster(int RoleId, int IntBranchId, string StrBranchName, string StrBranchaddress, string StrBranchphoneNo, string StrBranchfaxNo, string StrBranchemailID, string StrBranchWebSite, string StrBranchdescription)
        {
            try
            {
                if (StrBranchfaxNo == null || StrBranchfaxNo == "")
                {
                    StrBranchfaxNo = "";
                }
                if (StrBranchWebSite == null || StrBranchWebSite == "")
                {
                    StrBranchWebSite = "";
                }
                if (StrBranchdescription == null || StrBranchdescription == "")
                {
                    StrBranchdescription = "";
                }



                if (RoleId == 2)
                {

                    int intRtn = objBranchMaster.ManageBranchMaster(3, IntBranchId, "", StrBranchName, StrBranchaddress, StrBranchphoneNo, StrBranchfaxNo, StrBranchemailID, StrBranchWebSite, StrBranchdescription, 1, "", "", "", "", "");

                    return "BranchMaster List Updated";
                }

                else
                {

                    int intRtn = objBranchMaster.ManageBranchMaster(3, IntBranchId, "", StrBranchName, StrBranchaddress, StrBranchphoneNo, StrBranchfaxNo, StrBranchemailID, StrBranchWebSite, StrBranchdescription, 1, "", "", "", "", "");

                    return "BranchMaster List Updated";

                }
            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }

        [Route("DeleteBranchMaster")]
        [HttpPost]
        public string DeleteBranchMaster(string StrBranchId)
        {
            try
            {
                if (!String.IsNullOrEmpty(StrBranchId))
                {
                    try
                    {

                        int intRtn = objBranchMaster.ManageBranchMaster(4, Convert.ToInt16(StrBranchId), "", "", "", "", "", "", "", "", 0, "", "", "", "", "");

                        return "BranchId Deleted";

                    }

                    catch (Exception ex)
                    {
                        return "Branch Not Found";
                    }
                }
                else
                {
                    return "Invalid Request";
                }
            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }


        //Module and SubModule Creations

        //Getall modulename

        [Route("GetAllModuleCration")]
        [HttpGet]
        public string GetAllModuleCration()
        {
            try
            {

                string strResponsefunction = "";


                strResponsefunction = ObjModuleSubmodule.GetAllModuleCreation(1, 0, "", "", 0, "T", "", "", "", "");
                return strResponsefunction;

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        //Check the Module Name Exist 
        [Route("CheckModuleName")]
        [HttpPost]
        public string CheckModuleName(string strModuleName)
        {
            try
            {
                string strResponse = ObjModuleSubmodule.GetAllModuleCreation(5, 0, strModuleName, "", 0, "T", "", "", "", "");
                if (strResponse != "[]")
                {
                    return "This Module is Already Exists";
                }
                {
                    return "Scuess";
                }

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }

        [Route("SaveModuleCreationName")]
        [HttpPost]
        public string SaveModuleCreationName(string strModuleICon,string strModuleName, string strModuleDescription, int intPriority)
        {
            try
            {
                if (strModuleDescription == "" || strModuleDescription == null)
                {
                    strModuleDescription = "";
                }

                int intRtn = ObjModuleSubmodule.ManageModuleCreation(2, 0, strModuleName, strModuleDescription, intPriority, "T", strModuleICon, "", "", "");
                return "Module Details Added Successfully.";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }

        //edit code//
        [Route("EditModuleCreation")]
        [HttpPost]
        public string EditModuleCreation(int MODULEID)
        {
            try
            {
                string strResponse;
                strResponse = ObjModuleSubmodule.GetAllModuleCreation(6, MODULEID, "", "", 0, "T", "", "", "", "");
                return strResponse;

            }
            catch (Exception ex)
            {
                return "";
            }

        }

        //update module
        [Route("UpdateChangeModuleName")]
        [HttpPost]
        public string UpdateChangeModuleName(int Module_id, string strModuleICon, string strModuleName, string strModuleDescription, int intPriority)
        {
            try
            {

                int intRtn = ObjModuleSubmodule.ManageModuleCreation(3, Module_id, strModuleName, strModuleDescription, intPriority, "T", strModuleICon, "", "", "");
                return "updated successfully";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }

        //delete module
        [Route("DeleteModuleName")]
        [HttpPost]
        public string DeleteModuleName(int intMODULEID)
        {
            try
            {

                int intRtn = ObjModuleSubmodule.ManageModuleCreation(4, intMODULEID, "", "", 0, "F", "", "", "", "");
                return "" + intMODULEID + "' Module Deleted";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }

        }

        //detail code
        [Route("GetModuleDetails")]
        [HttpPost]
        public string GetModuleDetails(int intMODULEID)
        {
            try
            {

                string strResponse;
                strResponse = ObjModuleSubmodule.GetAllModuleCreation(6, intMODULEID, "", "", 0, "T", "", "", "", "");
                return strResponse;

            }
            catch (Exception ex)
            {
                return "";
            }

        }



        //Sub module Master


        //sub module tab

        // modulename drop down
        [Route("ModulenameDropDown")]
        [HttpGet]
        public string ModulenameDropDown()
        {
            try
            {
                string findalldata = "";
                findalldata = ObjModuleSubmodule.GetAllModuleCreation(8, 0, "", "", 0, "T", "", "", "", "");
                return findalldata;
            }
            catch (Exception ex)
            {
                return "";
            }

        }






        //Getall submodulename
        [Route("SubModuleMasterss")]
        [HttpGet]
        public string SubModuleMasterss()
        {
            try
            {

                string strResponsefunction1 = "";

                strResponsefunction1 = ObjModuleSubmodule.GetAllSubModuleCreation(1, 0, 0, "", "", "T", "", "", "", "");
                return strResponsefunction1;

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        //save submodule name

        [Route("SaveSubModuleName")]
        [HttpPost]
        public string SaveSubModuleName(int MODULE_ID, string SubModuleName, string SubModuleDescription)
        {

            try
            {

                int intRtn = ObjModuleSubmodule.ManageSubModuleCreation(2, 0, MODULE_ID, SubModuleName, SubModuleDescription, "T", "", "", "", "");
                return "inserted successfully";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }


        ////check module name  exist or not while adding
        [Route("CheckSubModuleName")]
        [HttpPost]
        public string CheckSubModuleName(string Submodule_Name)
        {
            try
            {
                string strResponse = ObjModuleSubmodule.GetAllSubModuleCreation(6, 0, 0, Submodule_Name, "", "T", "", "", "", "");
                if (strResponse != "[]")
                {
                    return "This Submodule Name Is Already Exists";
                }
                {
                    return "Scuess";
                }

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }


        [Route("EditSubModuleCreation")]
        [HttpPost]
        public string EditSubModuleCreation(int intSUBMODULE_ID)
        {
            try
            {
                string strResponse;
                strResponse = ObjModuleSubmodule.GetAllSubModuleCreation(3, intSUBMODULE_ID, 0, "", "", "T", "", "", "", "");
                return strResponse;

            }
            catch (Exception ex)
            {
                return "";
            }

        }



        [Route("updatesubmodule")]
        [HttpPost]
        public string updatesubmodule(int Submodule_id, int MODULE_ID, string SubModuleName, string SubModuleDescription)
        {
            try
            {
                int intRtn = ObjModuleSubmodule.ManageSubModuleCreation(4, Submodule_id, MODULE_ID, SubModuleName, SubModuleDescription, "T", "", "", "", "");
                return "updated successfully";
            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }

        //delete submodulename

        [Route("DeleteSubModule")]
        [HttpPost]
        public string DeleteSubModule(int intSUBMODULE_ID)
        {
            try
            {
                int intRtn = ObjModuleSubmodule.ManageSubModuleCreation(5, intSUBMODULE_ID, 0, "", "", Convert.ToString("T"), "", "", "", "");
                return "deleted successfully";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }

        }



        //detail code
        [Route("GetSubModuleDetails")]
        [HttpPost]
        public string GetSubModuleDetails(int inSUBMODULE_ID)
        {
            try
            {

                string strResponse;
                strResponse = ObjModuleSubmodule.GetAllSubModuleCreation(7, inSUBMODULE_ID, 0, "", "", "T", "", "", "", "");
                return strResponse;

            }
            catch (Exception ex)
            {
                return "";
            }

        }




        //Sequence Number

        [Route("getSequencyAll")]
        [HttpPost]
        //Getall modulename
        public string getSequencyAll(int intBranchID)
        {
            try
            {

                string strResponsefunction = "";


                strResponsefunction = ObjNumberSequence.GetAllSequenceCode(4, "", "", "", 0, 0, 0, 0, "T", "", "", "", "", 0, intBranchID);
                return strResponsefunction;

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        //save

        [Route("SaveSequence")]
        [HttpPost]
        public string SaveSequence(string SequencyType, string SequencyDescription, string Prefix, string NoOfDigits, string StartingNumber, string EndingNumber, string LastNumber, int BranchId)
        {
            try
            {
                int intRtn = ObjNumberSequence.ManageSequenceCode(6, SequencyType, SequencyDescription, Prefix, Convert.ToInt32(NoOfDigits), Convert.ToInt32(StartingNumber), Convert.ToInt32(EndingNumber), Convert.ToInt32(LastNumber), "T", "", "", "", "", 0, BranchId);
                return "inserted successfully";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }

        //edit code//

        [Route("EditSequenceCode")]
        [HttpPost]
        public string EditSequenceCode(int SEQUENCY_ID)
        {
            try
            {
                string strResponse;
                strResponse = ObjNumberSequence.GetAllSequenceCode(8, "", "", "", 0, 0, 0, 0, "T", "", "", "", "", SEQUENCY_ID, 0);
                return strResponse;

            }
            catch (Exception ex)
            {
                return "";
            }

        }


        //update module
        [Route("UpdateSequencyName")]
        [HttpPost]
        public string UpdateSequencyName(int SEQUENCY_ID, string SequencyType, string SequencyDescription, string Prefix, string NoOfDigits, string StartingNumber, string EndingNumber, string LastNumber, int BranchId)
        {
            try
            {
                int intRtn = ObjNumberSequence.ManageSequenceCode(5, SequencyType, SequencyDescription, Prefix, Convert.ToInt32(NoOfDigits), Convert.ToInt32(StartingNumber), Convert.ToInt32(EndingNumber), Convert.ToInt32(LastNumber), "T", "", "", "", "", SEQUENCY_ID, BranchId);
                return "updated successfully";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }

        //Get  Branch name in dropdown
        [Route("GetBranchName")]
        [HttpGet]
        public string GetBranchName()
        {
            try
            {

                string strResponse = "";
                strResponse = objBranchMaster.GetAllBranchMaster(8, 0, "", "", "", "", "", "", "", "", 1, "", "", "", "", "");
                return strResponse;

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }


        [Route("CheckBranchwise")]
        [HttpPost]
        public string CheckBranchwise(int BranchID)
        {
            try
            {
                string strResponse = "";
                strResponse = objBranchMaster.GetAllBranchMaster(20, BranchID, "", "", "", "", "", "", "", "", 1, "", "", "", "", "");
                return strResponse;


            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }
        }



        //Tab Confugration of SuperAdmin

        [Route("GetTabModuleName")]
        [HttpGet]
        public string GetTabModuleName()
        {
            try
            {
                string modulemaster = "";


                modulemaster = ObjModuleSubmodule.GetAllTabModuleMaster(2, 0, "", "", "", "T", "", "", "", "");
                return modulemaster;
            }
            catch (Exception ex)
            {
                return "data errror";
            }
        }

        [Route("GetTabSubModuleName")]
        [HttpPost]
        public string GetTabSubModuleName(int Mod_ID)
        {
            try
            {
                string submodule = "";


                submodule = ObjModuleSubmodule.GetAllTabSubModuleMaster(2, 0, Mod_ID, "", "", "T", "", "", "", "");

                return submodule;
            }
            catch (Exception ex)
            {
                return "data Error";
            }
        }

        [Route("GetTabNameById")]
        [HttpPost]
        public string GetTabNameById(int intTabId)
        {
            try
            {
                string submodule = "";


                submodule = ObjModuleSubmodule.GetAllTabSubModuleMaster(6, 0, intTabId, "", "", "T", "", "", "", "");

                return submodule;
            }
            catch (Exception ex)
            {
                return "data Error";
            }
        }





        [Route("getAllTestData")]
        [HttpGet]
        public string getAllTestData()
        {
            try
            {
                string strResponse = ObjModuleSubmodule.GetAllMainMenu(3, 0);
                return strResponse;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        [Route("getAllData")]
        [HttpGet]
        public string getAllData()
        {
            try
            {
                string strResponse = ObjModuleSubmodule.GetAllMainMenu(4, 0);
                return strResponse;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        [Route("getNextAllData")]
        [HttpPost]
        public string getNextAllData(int intRowOne, int intRowTwo)
        {
            try
            {
                string strResponse = objRoles.GetAllRoles(8, intRowOne, "", intRowTwo, "");
                return strResponse;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
        [Route("GetAllLogo")]
        [HttpGet]
        public string GetAllLogo()
        {
            try
            {

                string strRes = "";
                strRes = ObjLicensceInfo.GetAllManageLogo(3, 0, "", "", "", "", "", 1, "", "");

                return strRes;
            }
            catch (Exception ex)
            {
                return "";
            }
        }



        [Route("AddUpdateLogoInfo")]
        [HttpPost]
        public string AddUpdateLogoInfo(LogoTblCls Logoinfo)
        {
            try
            {

                UserManager user = new UserManager();

                int intRtn;
                intRtn = ObjLicensceInfo.ManageLogo(1, 0, Logoinfo.Logo_Text, Logoinfo.PoweredBy_Text, Logoinfo.Home_Text, Logoinfo.Home_Logo, "", 1, "", "");
                string getAllR = "";
                getAllR = ObjLicensceInfo.GetAllManageLogo(3, 0, "", "", "", "", "", 1, "", "");
                JArray obj = JArray.Parse(getAllR);
                return "Logo Added Successfully!";

            }
            catch (Exception ex)
            {
                return "Error";

            }
        }


        [Route("UpdateLogo")]
        [HttpPost]
        public string UpdateLogo(LogoTblCls LogoInfo)
        {
            try
            {
                UserManager user = new UserManager();
                if (LogoInfo.Home_Logo == null)
                {
                    LogoInfo.Home_Logo = "";
                }
                string CompanyImageUrlPath = ConfigurationManager.AppSettings["CompanyImageUrlPath"];
                int intRtn;
                intRtn = ObjLicensceInfo.ManageLogo(2, LogoInfo.Logo_ID, LogoInfo.Logo_Text, LogoInfo.PoweredBy_Text, LogoInfo.Home_Text, LogoInfo.Home_Logo, CompanyImageUrlPath, 1, "", "");
                string getAllR = "";
                getAllR = ObjLicensceInfo.GetAllManageLogo(3, 0, "", "", "", "", "", 1, "", "");
                JArray obj = JArray.Parse(getAllR);
                return "Logo Added Successfully!";
            }
            catch (Exception ex)
            {
                return "Error";

            }
        }

        [Route("getLogoImage")]
        [HttpGet]
        public string getLogoImage()
        {
            try
            {

                string getAllR = "";
                getAllR = ObjLicensceInfo.GetAllManageLogo(3, 0, "", "", "", "", "", 1, "", "");

                return getAllR;

            }
            catch (Exception ex)
            {
                return "Error";
            }

        }

        [Route("UploadCompanyLogo")]
        [HttpPost]
        public string UploadCompanyLogo()
        {

            string Imagename = null;
            var httpRequest = HttpContext.Current.Request;

            var postedFile = httpRequest.Files["Companyimage"];

            Imagename = new String(Path.GetFileName(postedFile.FileName).ToArray()).Replace(" ", "-");
            Imagename = "RestaurantLogo.png";

            string CompanyImagePath = ConfigurationManager.AppSettings["CompanyImagePath"];
            string CompanyImageUrlPath = ConfigurationManager.AppSettings["CompanyImageUrlPath"];

            string path = HttpContext.Current.Server.MapPath(CompanyImagePath);
            string imgPath = Path.Combine(path, Imagename);
            postedFile.SaveAs(imgPath);


            return Imagename;

        }

        [Route("getLogoAndText")]
        [HttpGet]
        public string getLogoAndText()
        {
            try
            {
                string getAllR = "";
                getAllR = ObjLicensceInfo.GetAllManageLogo(3, 0, "", "", "", "", "", 1, "", "");
                return getAllR;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        [Route("expiryMessage")]
        [HttpGet]
        public string expiryMessage()
        {

            UserManager user = new UserManager();

            string CategoryLimit = ObjLicensceInfomation.GetAllWincentShopLicenseInfomation(14, 0, 0, "", "", 1);
            JArray obj2 = JArray.Parse(CategoryLimit);

            string EndDateLimit = obj2[0]["SC_Limit"].ToString();

             EndDateLimit = user.decryptData(EndDateLimit);


            //string END_DATE = obj[0]["END_DATE"].ToString();

            string Expirydate = Convert.ToDateTime(EndDateLimit).ToString("dd/MM/yyyy");
            DateTime Expdate = Convert.ToDateTime(Expirydate, System.Globalization.CultureInfo.GetCultureInfo("hi-IN").DateTimeFormat);

            DateTime today = DateTime.Today;//mm/dd/yyyy
            TimeSpan ts = Expdate.Subtract(today);
            int noofdays = Convert.ToInt32(ts.Days.ToString());

            if (noofdays <= 15 && noofdays >= 0)
            {
                return "going to expire on " + Expirydate;
            }
            else if (noofdays > 15)
            {
                return "Noproblem";
            }
            else
            {
                return "Alreadyexpired";
            }


        }


        [Route("removeSubModule")]
        [HttpPost]
        public string removeSubModule(int intSubModuleId)
        {
            try
            {

                int intRtn = ObjModuleSubmodule.ManageSubModuleCreation(8, intSubModuleId, 0, "", "", "T", "", "", "", "");
                return "Removed successfully";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }


        [Route("removeModule")]
        [HttpPost]
        public string removeModule(int intModuleId)
        {
            try
            {

                string objResponse = ObjModuleSubmodule.GetAllModuleCreation(18, intModuleId, "", "", 0, "T", "", "", "", "");
                JArray obj = JArray.Parse(objResponse);
                for (int i = 0; i < obj.Count; i++)
                {
                    int intSubModuleId = Convert.ToInt32(obj[i]["SUBMODULE_ID"]);
                    int deleteSubModule = ObjModuleSubmodule.ManageModuleCreation(19, intSubModuleId, "", "", 0, "T", "", "", "", "");
                }
                int deleteModule = ObjModuleSubmodule.ManageModuleCreation(20, intModuleId, "", "", 0, "T", "", "", "", "");


                return "Removed successfully";
            }
            catch (Exception ex)
            {
                return "error";
            }
        }


        //Active module
        [Route("activeModuleName")]
        [HttpPost]
        public string activeModuleName(int intModuleId)
        {
            try
            {

                int intRtn = ObjModuleSubmodule.ManageModuleCreation(21, intModuleId, "", "", 0, "F", "", "", "", "");
                return "Module Activated";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }

        }


        //Active module
        [Route("activeSubModuleName")]
        [HttpPost]
        public string activeSubModuleName(int intSubModuleId)
        {
            try
            {

                int intRtn = ObjModuleSubmodule.ManageSubModuleCreation(9, intSubModuleId, 0, "", "", "F", "", "", "", "");
                return "SubModule Activated";

            }
            catch (Exception ex)
            {
                return "Invalid Record";
            }

        }


        [Route("getNextSubModules")]
        [HttpPost]
        public string getNextSubModules(int intRowOne, int intRowTwo)
        {
            try
            {
                string intRtn = ObjModuleSubmodule.GetAllSubModuleCreation(10, intRowOne, intRowTwo, "", "", "F", "", "", "", "");
                return intRtn;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }



        [Route("getNextModules")]
        [HttpPost]
        public string getNextModules(int intRowOne, int intRowTwo)
        {
            try
            {
                string intRtn = ObjModuleSubmodule.GetAllModuleCreation(22, intRowOne, "", "", intRowTwo, "", "", "", "", "");
                return intRtn;
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }



    
        


        [Route("readNotification")]
        [HttpGet]
        public string readNotification()
        {
            try
            {


                string readNotification = ObjNotification.GetAllNotofication(6, 0, 1, 1, 0, "", "", 1, 1, "", 1, "", "", 1);
                if (readNotification == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return readNotification;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("GetNextreadNotification")]
        [HttpPost]
        public string GetNextreadNotification(int intRowOne, int intRowTwo)
        {
            try
            {

                string GetNextreadNotification = ObjNotification.GetAllNotofication(7, intRowOne, intRowTwo, 1, 0, "", "", 1, 1, "", 1, "", "", 1);
                if (GetNextreadNotification == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return GetNextreadNotification;
                }

            }
            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }

        }


        [Route("createNotification")]
        [HttpPost]
        public string createNotification(int intUserFromId, string strSubject, List<ClsNotification> UserToIdlist)
        {
            try
            {
                int createNotification = 0;
                foreach (var i in UserToIdlist)
                {
                    if(i.UserToId!=0)
                    {
                        int insertNotification = ObjNotification.ManageNotofication(1, 0, 1, 1, i.UserToId, strSubject, "", 1, intUserFromId, "", intUserFromId, "", "", 1);
                    }
            
                }

                if (createNotification == 2)
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return "Notification added sucessfully";
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }

        [Route("readMyNotification")]
        [HttpPost]
        public string readMyNotification(int intUserFromId)
        {
            try
            {
                string getNotificationList = ObjNotification.GetAllNotofication(3, 0, 1, 1, intUserFromId, "", "", 1, 1, "", 1, "", "", 1);
                if (getNotificationList == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return getNotificationList;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }



 
        [Route("getUser")]
        [HttpGet]
        public string getUser()
        {
            try
            {
                string getUser = objWalletManagement.ReadWalletManagement(8, 0, 0, "", "", "", "", 1, 1, 0, "", 0, "");
                if (getUser == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return getUser;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        [Route("readNotificationById")]
        [HttpPost]
        public string readNotificationById(int intNotificationId)
        {
            try
            {
             string getNotificationList = ObjNotification.GetAllNotofication(8, intNotificationId, 1, 1, 0, "", "", 1, 1, "", 1, "", "", 1);

                if (getNotificationList == "Error")
                {
                    return "Error occured either component or strore Procedure";
                }
                else
                {
                    return getNotificationList;
                }

            }

            catch (Exception ex)
            {
                return "Error occured either component or strore Procedure";
            }
        }


        


        [Route("verifySMSOTP")]
        [HttpPost]
        public string verifySMSOTP(string strOTPNumber,string strEmailID)
        {
            try
            {
                string verifySMSOTP;
                verifySMSOTP = objUser.ReadUser(19, 0, "", "", "", "", "", "", strEmailID, strOTPNumber, 0, "", 0, "", 0, 1, 1, 0, "", 0, "");
                if (verifySMSOTP == "[]")
                {
                    return "Enter OTP is not valid";
                }
                else if (verifySMSOTP == "Error")
                {
                    return "Error";
                }
                else
                {
                    return "Enter OTP is valid";
                }

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }
        [Route("ReadUserDetails")]
        [HttpPost]
        public string ReadUser(int intUserID)
        {
            try
            {
                string ReadUser;
                ReadUser = objUser.ReadUser(1, intUserID, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");
                if (ReadUser == "Error")
                {
                    return "Error";
                }
                else
                {
                    return ReadUser;
                }

            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        //-----WincentShop -----------------------//


        //LicenceInfo
        [Route("GetAllWincentShopLicenseInfo")]
        [HttpGet]
        public HttpResponseMessage GetAllWincentShopLicenseInfo()
        {
            try
            {
                UserManager user = new UserManager();

                string strRes = "";
                strRes = ObjLicensceInfomation.GetAllWincentShopLicenseInfomation(3, 0, 1, "", "", 1);
                JArray objJSON = JArray.Parse(strRes);
                List<ClsWincentLicense> lstLicense = new List<ClsWincentLicense>();

                for (int i = 0; i < objJSON.Count; i++)
                {
                    ClsWincentLicense clslicense = new ClsWincentLicense();
                    clslicense.SC_LicenseId = Convert.ToInt32(objJSON[i]["SC_LicenseId"]); //LIL.LICENSE_ID;
                    clslicense.SC_CustomerId = Convert.ToInt32(objJSON[i]["SC_CustomerId"]);  //LIL.CUSTOMER_ID;
                    clslicense.SC_License_Name = objJSON[i]["SC_License_Name"].ToString();
                    if (objJSON[i]["SC_License_Name"].ToString() == "End_Date" || objJSON[i]["SC_License_Name"].ToString() == "Start_Date")
                    {
                        string EndDateLimit = user.decryptData(objJSON[i]["SC_Limit"].ToString());
                        clslicense.SC_Limit = Convert.ToDateTime(EndDateLimit).ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        clslicense.SC_Limit = user.decryptData(objJSON[i]["SC_Limit"].ToString());
                    }
                    lstLicense.Add(clslicense);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lstLicense);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Error");
            }
        }


        [Route("UpdateWincentShopLicenseInfo")]
        [HttpPost]
        public HttpResponseMessage UpdateWincentShopLicenseInfo(ClsWincentShopLicencePage LicenseInfo)
        {
            try
            {
                //int limitset=0;
                if (LicenseInfo.NewLimit == null || LicenseInfo.NewLimit == "NAN" || LicenseInfo.NewLimit == "")
                {
                    LicenseInfo.NewLimit = "";
                }

                UserManager user = new UserManager();

                var NoLicenseName = LicenseInfo.SC_License_Name;
                var NoLimit = user.encryptData(LicenseInfo.SC_Limit);
                var NewLimit = user.encryptData(LicenseInfo.NewLimit);
                int intRtn;
                intRtn = ObjLicensceInfomation.ManageWincentShopLicenseInfo(5, LicenseInfo.SC_LicenseId, LicenseInfo.SC_CustomerId, NoLicenseName, NewLimit, 1);
                var NoLimitdec1 = user.decryptData(NoLimit);
                string getAllR = "";
                getAllR = ObjLicensceInfomation.GetAllWincentShopLicenseInfomation(3, 0, 0, "", NoLimitdec1, 1);
                return Request.CreateResponse(HttpStatusCode.OK, "License Updated Successfully!");
            }

            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.OK, "Error");

            }
        }
        [Route("sendSMS")]
        [HttpPost]
        public string sendSMS(string strToMobileNumber, string strmessage)
        {
            try
            {
                string getSMSGetWay;

                getSMSGetWay = objUser.ReadUser(30, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");

                JArray SmsObj = JArray.Parse(getSMSGetWay);
                string strhttpurl = SmsObj[0]["Main_URL"].ToString();

                string Key1 = SmsObj[0]["Key1"].ToString();
                string Key1Value = SmsObj[0]["Key1Value"].ToString();

                if (Key1 != null && Key1 != "" && Key1 != "undefined" && Key1 != "null")
                {
                    strhttpurl = strhttpurl + Key1 + "=" + Key1Value;
                }

                string Key2 = SmsObj[0]["Key2"].ToString();
                string Key2Value = SmsObj[0]["Key2Value"].ToString();
                if (Key2 != null && Key2 != "" && Key2 != "undefined" && Key2 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key2 + "=" + Key2Value;
                }

                string Key3 = SmsObj[0]["Key3"].ToString();
                if (Key3 != null && Key3 != "" && Key3 != "undefined" && Key3 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key3 + "=" + strToMobileNumber;
                }
                string Key4 = SmsObj[0]["Key4"].ToString();
                if (Key4 != null && Key4 != "" && Key4 != "undefined" && Key4 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key4 + "=" + strmessage;
                }

                string Key5 = SmsObj[0]["Key5"].ToString();
                string Key5Value = SmsObj[0]["Key5Value"].ToString();
                if (Key5 != null && Key5 != "" && Key5 != "undefined" && Key5 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key5 + "=" + Key5Value;
                }

                string Key6 = SmsObj[0]["Key6"].ToString();
                string Key6Value = SmsObj[0]["Key6Value"].ToString();
                if (Key6 != null && Key6 != "" && Key6 != "undefined" && Key6 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key6 + "=" + Key6Value;
                }

                string Key7 = SmsObj[0]["Key7"].ToString();
                string Key7Value = SmsObj[0]["Key7Value"].ToString();
                if (Key7 != null && Key7 != "" && Key7 != "undefined" && Key7 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key7 + "=" + Key7Value;
                }


                string Key8 = SmsObj[0]["Key8"].ToString();
                string Key8Value = SmsObj[0]["Key8Value"].ToString();
                if (Key8 != null && Key8 != "" && Key8 != "undefined" && Key8 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key8 + "=" + Key8Value;
                }

                string Key9 = SmsObj[0]["Key9"].ToString();
                string Key9Value = SmsObj[0]["Key1Value"].ToString();
                if (Key9 != null && Key9 != "" && Key9 != "undefined" && Key9 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key9 + "=" + Key9Value;
                }

                string Key10 = SmsObj[0]["Key10"].ToString();
                string Key10Value = SmsObj[0]["Key10Value"].ToString();
                if (Key10 != null && Key10 != "" && Key10 != "undefined" && Key10 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key10 + "=" + Key10Value;
                }

                string Key11 = SmsObj[0]["Key11"].ToString();
                string Key11Value = SmsObj[0]["Key11Value"].ToString();
                if (Key11 != null && Key11 != "" && Key11 != "undefined" && Key11 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key11 + "=" + Key11Value;
                }


                string Key12 = SmsObj[0]["Key12"].ToString();
                string Key12Value = SmsObj[0]["Key12Value"].ToString();
                if (Key12 != null && Key12 != "" && Key12 != "undefined" && Key12 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key12 + "=" + Key12Value;
                }


                string Key13 = SmsObj[0]["Key13"].ToString();
                string Key13Value = SmsObj[0]["Key13Value"].ToString();
                if (Key13 != null && Key13 != "" && Key13 != "undefined" && Key13 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key13 + "=" + Key13Value;
                }

                string Key14 = SmsObj[0]["Key14"].ToString();
                string Key14Value = SmsObj[0]["Key14Value"].ToString();
                if (Key14 != null && Key14 != "" && Key14 != "undefined" && Key14 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key14 + "=" + Key14Value;
                }


                string Key15 = SmsObj[0]["Key15"].ToString();
                string Key15Value = SmsObj[0]["Key15Value"].ToString();
                if (Key15 != null && Key15 != "" && Key15 != "undefined" && Key15 != "null")
                {
                    strhttpurl = strhttpurl + "&" + Key15 + "=" + Key15Value;
                }


                objSMS.SendSMSByNumber(strhttpurl);

                return "Send SMS Sucessfully";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }


        [Route("SendEmail")]
        [HttpPost]
        public string SendEmail(string strToEmailaddress, string strSubject, string strBody)
        {

            try
            {
                string getEmailFromAddressInfo;
                getEmailFromAddressInfo = objUser.ReadUser(30, 0, "", "", "", "", "", "", "", "", 0, "", 0, "", 0, 1, 1, 0, "", 0, "");
                JArray EmailObj = JArray.Parse(getEmailFromAddressInfo);
                string strFromEmailAddress = EmailObj[0]["Key2Value"].ToString();
                string strFromEmailPassword = EmailObj[0]["Key3Value"].ToString();
                int intgmail = Convert.ToInt32(EmailObj[0]["Key4Value"]);
                int intEMail = Convert.ToInt32(EmailObj[0]["Key5Value"]);
                int intGodaddy = Convert.ToInt32(EmailObj[0]["Key6Value"]);
                string SMTPHost = EmailObj[0]["Key7Value"].ToString();
                int SMTPPort = Convert.ToInt32(EmailObj[0]["Key8Value"]);
                objEmailVpsGodaddy.sendEmail(strToEmailaddress, strFromEmailAddress, strFromEmailAddress, strFromEmailPassword, strSubject, strBody, intgmail, intEMail, intGodaddy, SMTPHost, SMTPPort);

                return "Send SMS Sucessfully";
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

      


        
    }
}



