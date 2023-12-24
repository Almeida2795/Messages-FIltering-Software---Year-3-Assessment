using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CourseworkReal
{
    internal class Textspeak
    {
        //Variables
        public string fileName = @"C:\Users\guifm\Desktop\Uni\Year 3\Software Engineering\textwords.csv";
        public string line;
        public string[] row;
        public int counter;
        public List<string> textspeaks = new List<string>();
        public List<string> fullWord = new List<string>();

        

        public Textspeak()
        {
            txtSpeakFilter();
        }

        //Reads the textspeak abbreviations file
        public void txtSpeakFilter()
        {
            StreamReader xl = new StreamReader(fileName);

            while ((line = xl.ReadLine()) != null) {
                row = line.Split(',');
                textspeaks.Add(row[0]);
                fullWord.Add(row[1]);
            }
   
        }

        //finds abbrevations in the message
        public bool FindAbbreviations(string message)
        {
            Regex upperCaseRegex = new Regex(@"^[A-Z]{3,30}$");
            if (upperCaseRegex.IsMatch(message) == true)
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
