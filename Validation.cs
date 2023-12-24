using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseworkReal
{
    internal class Validation
    {
        public Validation()
        {

        }

        //Checks if the ID is 10 characters long
        public bool IsId(string id)
        {
            if(id.Length != 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Checks if the SMS Body is less than 140 characters long
        public bool IsSMSBody(string body)
        {
            if(body.Length > 140)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Checks if the email body is less than 1028 characters long
        public bool IsEmailBody(string body)
        {
            if(body.Length > 1028)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Checks if the twitter handle is less than 16 characters long
        public bool IsTwitterHandle(string handle)
        {
            if(handle.Length > 16)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //checks if the twitter body is less than 140 characters long
        public bool IsTwitterBody(string body)
        {
            if(body.Length > 140)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Checks if the message has Abbreviations
        public bool FindTextspeak(string body)
        {
            string regexString = "^[A-Z ]+$";
            Regex upperCaseRegex = new Regex(regexString);
            if (upperCaseRegex.IsMatch(body))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
