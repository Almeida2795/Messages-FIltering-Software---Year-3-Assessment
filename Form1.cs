using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.VisualBasic;

namespace CourseworkReal
{
    public partial class Form1 : Form
    {
        public string Message;
        public string Id;

        //File names for the json files
        string smsFileName = @"C:\Users\guifm\Desktop\Uni\Year 3\Software Engineering\smsfiltered.json";
        string emailFileName = @"C:\Users\guifm\Desktop\Uni\Year 3\Software Engineering\emailfiltered.json";
        string emailSIRFileName = @"C:\Users\guifm\Desktop\Uni\Year 3\Software Engineering\sirfiltered.json"; 
        string tweetFileName = @"C:\Users\guifm\Desktop\Uni\Year 3\Software Engineering\tweetfiltered.json";

        //Lists
        List<string> reportsList = new List<string>();
        List<string> Trends = new List<string>();
        List<string> Mentions = new List<string> ();
        List<Sms> smsList = new List<Sms>();
        List<Tweet> tweetList = new List<Tweet>();
        List<SIR>SIRList = new List<SIR>();
        List<Email> EmailList = new List<Email>();

        int searchCount = 0;
        public string[] smsWords;
        public string[] tweetWords;
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            searchCount = 0;
            Id = txtId.Text;
            Message = txtMessage.Text;
            Filter filter = new Filter(Id);
            Validation val = new Validation();
            Textspeak txtSpeak = new Textspeak();

            //Checks if the ID is valid
            if (val.IsId(Id) == false)
            {
                MessageBox.Show("Please check if the ID is correct and try again");
                return;
            }
            else
            {
                //If the message is an email
                if (filter.isMessageEmail(Id) == true)
                {
                    try
                    {
                        //Finds the email address
                        Regex extractEmailsRegex = new Regex("\\S+@\\S+\\.\\S+");
                        Email email = new Email();
                        Match m = extractEmailsRegex.Match(Message);
                        if (m.Success) //Checks if the email is correct
                        {
                            //Check if the email message is a SIR report
                            if (filter.isMessageSIR(Message))
                            {
                                SIR sir = new SIR();
                                sir.address = m.Groups[0].Value;

                                //Get the email subject
                                var start = Message.IndexOf(sir.address);
                                var spaceIndex = Message.IndexOf(" ", start);
                                sir.subject = Message.Substring(spaceIndex + 1, 12);

                                //Get the email sort code
                                var start2 = Message.IndexOf(sir.subject);
                                var spaceIndex2 = Message.IndexOf("\n", start2);

                                sir.sortCode = Message.Substring(spaceIndex2 + 1, 19);

                                //get the email incident
                                var start3 = Message.IndexOf(sir.sortCode);
                                var spaceIndex3 = Message.IndexOf("\n", start3);
                                var x = Message.IndexOf("\n", spaceIndex3 + 1);
                                sir.incident = Message.Substring(spaceIndex3 + 1, (x - spaceIndex3) - 2);

                                //get the email body
                                var start4 = Message.IndexOf(sir.incident);
                                var spaceIndex4 = Message.IndexOf("\n", start4);
                                sir.body = Message.Substring(spaceIndex4);

                                //checks if email body is not too big.
                                if (val.IsEmailBody(sir.body) == false)
                                {
                                    MessageBox.Show("The email body is too big");
                                }
                                else
                                {
                                    //adds the SIR report to the list
                                    reportsList.Add(sir.sortCode + " " + sir.incident);

                                    //Displays the filtered and organised message in the output text box
                                    txtFiltered.Text = (sir.address + Environment.NewLine + sir.subject + Environment.NewLine + Environment.NewLine + sir.sortCode + Environment.NewLine + sir.incident + Environment.NewLine + sir.body);
                                    
                                    //Adds the message to the SIR list and outputs it to the Json file
                                    SIRList.Add(sir);
                                    string SIRJsonString = JsonConvert.SerializeObject(SIRList);
                                    File.WriteAllText(emailSIRFileName, SIRJsonString);
                                }
                            }
                            else
                            //For email messages that are not a SIR report
                            {
                                email.address = m.Groups[0].Value;

                                //get the email subject
                                var start = Message.IndexOf(email.address);
                                var spaceIndex = Message.IndexOf(" ", start);
                                email.subject = Message.Substring(spaceIndex + 1, 20);

                                //get the email body
                                var start2 = Message.IndexOf(email.subject);
                                var spaceIndex2 = Message.IndexOf(" ", start2);
                                email.body = Message.Substring(start2 + 20);

                                //Quarantines and replaces website links in the message body
                                Regex extractLinksRegex = new Regex(@"\b(?:https?://|www\.)\S+\b", RegexOptions.Compiled | RegexOptions.IgnoreCase);
                                foreach (Match x in extractLinksRegex.Matches(email.body))
                                {
                                    txtQuarantine.Text += x.Value + Environment.NewLine;
                                    email.body = extractLinksRegex.Replace(email.body, "<Link Quarantined>");
                                }

                                //validates the length of the email body before displaying the filtered message
                                if (val.IsEmailBody(email.body) == false)
                                {
                                    MessageBox.Show("The email body is too big");
                                }
                                else
                                {
                                    //Displays the filtered and organised message in the output text box
                                    txtFiltered.Text = (email.address + Environment.NewLine + email.subject + Environment.NewLine + email.body);
                                    
                                    //adds the message to the email list and outputs it to the json file
                                    EmailList.Add(email);
                                    string emailJsonString = JsonConvert.SerializeObject(EmailList);
                                    File.WriteAllText(emailFileName, emailJsonString);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("please ensure the email address is correct");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please check if the message is an email");
                        return;
                    }
                }
                else if (filter.isMessageTweet(Id) == true)
                {
                    Tweet tweet = new Tweet();
                    try
                    {
                        //get the twitter handle
                        var start = Message.IndexOf("@");
                        var spaceIndex = Message.IndexOf(" ", start);
                        var sizeOfHandle = spaceIndex - start;

                        tweet.handle = Message.Substring(start, sizeOfHandle);
                    
                        //checks if twitter handle is valid
                    if (val.IsTwitterHandle(tweet.handle) == false)
                    {
                        MessageBox.Show("Please ensure the handle is not bigger than 15 characters");
                        return;
                    }
                    else
                    {
                            //get the tweet body
                        tweet.body = Message.Substring(spaceIndex);
                            //checks if the body is not too big
                        if (val.IsTwitterBody(tweet.body) == false)
                        {
                            MessageBox.Show("Please ensure the body is not bigger than 140 characters");
                            return;
                        }
                        else
                        {
                                //separates every word from the body into an array "tweetWords"
                            tweetWords = tweet.body.Split(' ');
                            foreach (var search in tweetWords)
                            {
                                searchCount++;
                                while(searchCount < tweetWords.Length)
                                {
                                        //searches through all the words to find abbreviations and replaces them
                                    if (txtSpeak.FindAbbreviations(tweetWords[searchCount].Trim()) == true)
                                    {
                                        string found = tweetWords[searchCount];

                                        for (int counter = 0; counter < txtSpeak.textspeaks.Count; counter++)
                                        {
                                            if (found == txtSpeak.textspeaks[counter])
                                            {
                                                tweetWords[searchCount] += " <" + txtSpeak.fullWord[counter] + ">";
                                                tweet.body = "";
                                                foreach (var tweetWord in tweetWords)
                                                {
                                                        //rebuilds the body with every word and the abbreviation.
                                                    tweet.body += (tweetWord + " ");
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }

                            //searches for hashtags and adds them into the trends list
                            Regex hashtagsFinder = new Regex(@"#\w+");
                            foreach (Match x in hashtagsFinder.Matches(tweet.body))
                            {
                                Trends.Add(x.Value);
                            }

                            //searches for mentions and adds them into the mentions list
                            Regex mentionsFinder = new Regex(@"@\w+");
                            foreach (Match y in mentionsFinder.Matches(tweet.body))
                            {
                                Mentions.Add(y.Value);
                            }
                            
                            //Displays the filtered and organised message in the output text box
                            txtFiltered.Text = (tweet.handle + Environment.NewLine + tweet.body);

                            //adds the message to the tweets list and outputs it to the json file
                            tweetList.Add(tweet);
                            string tweetJsonString = JsonConvert.SerializeObject(tweetList);
                            File.WriteAllText(tweetFileName, tweetJsonString);
                        }
                    }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please check if the message is a tweet.");
                        return;
                    }
                }
                else if (filter.isMessageSms(Id) == true)
                {

                    Sms sms = new Sms();
                    try
                    {
                        //get the phone number
                        var start = Message.IndexOf("+");
                        sms.phoneNo = Message.Substring(start, 12);

                        var spaceIndex = Message.IndexOf(" ", start);

                        //get the sms body
                        sms.body = Message.Substring(spaceIndex);

                        //separates every word from the body into an array "smsWords"
                        smsWords = sms.body.Split(' ');


                        foreach (var search in smsWords)
                        {
                            searchCount++;
                            while (searchCount < smsWords.Length)
                            {//searches through all the words to find abbreviations and replaces them
                                if (txtSpeak.FindAbbreviations(smsWords[searchCount].Trim()) == true)
                                {
                                    string found = smsWords[searchCount];

                                    for (int counter = 0; counter < txtSpeak.textspeaks.Count; counter++)
                                    {
                                        if (found == txtSpeak.textspeaks[counter])
                                        {
                                            smsWords[searchCount] += " <" + txtSpeak.fullWord[counter] + "> ";
                                            sms.body = "";
                                            foreach (var smsWord in smsWords)
                                            {//rebuilds the body with every word and the abbreviation.
                                                sms.body += (smsWord + " ");
                                            }
                                        }
                                    }
                                }
                                else if (txtSpeak.FindAbbreviations(smsWords[searchCount].Trim()) == false)
                                {
                                    break;
                                }
                            }
                        }
                        //checks if sms body is not too big
                        if (val.IsSMSBody(sms.body) == false)
                        {
                            MessageBox.Show("Please make sure the sms body is not bigger than 140 characters");
                            return;
                        }
                        else
                        {
                            //Displays the filtered and organised message in the output text box
                            txtFiltered.Text = (sms.phoneNo + Environment.NewLine + sms.body);

                            //adds the message to the sms list and outputs it to the json file
                            smsList.Add(sms);
                            string smsJsonString = JsonConvert.SerializeObject(smsList);
                            File.WriteAllText(smsFileName, smsJsonString);
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Please check if message is a SMS");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Please confirm if the message is in the right format (ID and body)");
                }

            }
        }


        //creates the trending list and displays the other lists
        private void btnTrends_Click(object sender, EventArgs e)
        {
            var q = Trends.GroupBy(x => x)
            .Select(g => new { Value = g.Key, Count = g.Count() })
            .OrderByDescending(x => x.Count);

            foreach (var x in q)
            {
                txtTrends.Text = txtTrends.Text + (x.Value + " " + x.Count) + Environment.NewLine;
            }

            txtMentions.Text = String.Join(Environment.NewLine, Mentions);
            txtSir.Text = String.Join(Environment.NewLine, reportsList);
        }
    }
}