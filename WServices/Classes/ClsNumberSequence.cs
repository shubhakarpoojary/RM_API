using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using WinApps.Models;

namespace WServices.Classes
{
    public class ClsNumberSequence
    {
       
        WFramework.clsNumberSequence objSequences = new WFramework.clsNumberSequence();

        public string GetNextSequence(string SequenceType)
        {
            string NextSequence = null;

        
            string sequences = "";
            sequences = objSequences.GetAllNumberSequence(1, SequenceType, "", "", "", "", "", "", 1, "", "", "", "",0,0);
            JArray objJSON = JArray.Parse(sequences);
            string NoOfDigits = objJSON[0]["NO_OF_DIGITS"].ToString();
            string LastNumber = objJSON[0]["LAST_NUMBER"].ToString();
            string PreFix = objJSON[0]["PREFIX"].ToString();

            int lastno;
            if (sequences != null)
            {
                DateTime today = DateTime.Now;
                string dateyear = Convert.ToDateTime(today).ToString("yy/");
                string Format = getFormat(Convert.ToInt32(NoOfDigits.ToString()));
                lastno = Convert.ToInt32(LastNumber.ToString()) + 1;
                NextSequence = PreFix.ToString() + dateyear + lastno.ToString(Format);

            }
            return NextSequence;
        }


        public string GetPatientNextSequence(string SequenceType)
        {
            string NextSequence = null;

     
            string sequences = "";
            sequences = objSequences.GetAllNumberSequence(1, SequenceType, "", "", "", "", "", "", 1, "", "", "", "",0,0);
            
            
            
            JArray objJSON = JArray.Parse(sequences);
            string NoOfDigits = objJSON[0]["NO_OF_DIGITS"].ToString();
            string LastNumber = objJSON[0]["LAST_NUMBER"].ToString();
            string PreFix = objJSON[0]["PREFIX"].ToString();

            int lastno;
            if (sequences != null)
            {
                DateTime today = DateTime.Now;
                string dateyear = Convert.ToDateTime(today).ToString("yy/");
                string Format = getFormat(Convert.ToInt32(NoOfDigits.ToString()));
                lastno = Convert.ToInt32(LastNumber.ToString()) + 1;
                NextSequence = PreFix.ToString()  + lastno.ToString(Format);

            }
            return NextSequence;
        }


        public string getFormat(int NoOfDigit)
        {
            string Format = "";
            for (int Count = 0; Count < NoOfDigit; Count++)
            {
                Format = Format + "0";
            }
            return Format;
        }

        public int Incrementsequence(string SequenceType, int LastNumber, string UserName)
        {

            int intRtn = objSequences.ManageClsNumberSequence(2, SequenceType, "", "", "", "", "", Convert.ToString(LastNumber), 1, "", "", "", "",0,0);
            return intRtn;


        }
        public string GetPrefixBySequenceType(string SeqType)
        {
           
            string data = "";
            data = objSequences.GetAllNumberSequence(3, SeqType, "", "", "", "", "", "", 1, "", "", "", "",0,0);

            return data;

        }
    }
}