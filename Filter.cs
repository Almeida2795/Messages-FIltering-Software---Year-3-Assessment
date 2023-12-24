using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseworkReal
{
    internal class Filter
    {
        public string id {get;set;}

        public Filter (string id)
        {
            this.id = id;
        }

        //The following booleans check the ID of the message and filters it accordingly
        public bool isMessageEmail(string Message)
        {
            if (id.Contains("E"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isMessageTweet(string Message)
        {
            if (id.Contains("T"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isMessageSms(string Message)
        {
            if (id.Contains("S"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //This boolean checks if the Message contains SIR which would mean that the subject has SIR and it is a SIR Email.
        public bool isMessageSIR(string message)
        {
            if (message.Contains("SIR"))
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
