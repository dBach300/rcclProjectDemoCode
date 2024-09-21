using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RCCLDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /****************************************************************************
        * *********functionality of API Post request & parsing*********************
        * *************************************************************************/
        private void BtnAPIClick(object sender, EventArgs e)
        {
            //variables
            string system;
            string folidID;
            string isPhotoRequired;
            string isCouponRequired;
            //set values for variables
            system = txtSystem.Text;
            folidID = txtFID.Text;
            isPhotoRequired = txtIsPhotoRequired.Text;
            isCouponRequired = txtIsCouponRequired.Text;
            //security req
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //orignally used 1, 1.1, and 1.2 security protocols, only needed 1.2 during testing 11/14
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls |
            //                           SecurityProtocolType.Tls11 |
            //                           SecurityProtocolType.Tls12;
            //create web request
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://xxx.xxx.xxxx.xxx/x/x/x");
            //content type
            httpWebRequest.ContentType = "application/json";
            //http verb
            httpWebRequest.Method = "POST";
            //get request stream
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //use these variables
                string json = "{\"System\":" + system + "," +
                              "\"FolioID\":" + folidID + "," +
                              "\"isPhotoRequired\":" + isPhotoRequired + "," +
                              "\"isCouponRequired\":" + isCouponRequired + "}";
                streamWriter.Write(json);
            }
            //get response
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            //read response to the end of stream
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Guest guestInfo = JsonConvert.DeserializeObject<Guest>(result);
                Dictionary<string, string> dictObj = new Dictionary<string, string>();
                try
                {
                    foreach (var item in guestInfo.FolioDetails)
                    {
                        //adds VoyageID(key,value) to dictionary then uses the VoyageID key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("VoyageID", item.VoyageID);
                        txtVoyageID.Text = dictObj["VoyageID"];
                        //adds PassengerID(key,value) to dictionary then uses the PassengerID key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("PassengerID", item.PassengerID);
                        txtPassengerID.Text = dictObj["PassengerID"];
                        //adds FolioID(key,value) to dictionary then uses the FolioID key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("FolioID", item.FolioID);
                        txtFolioID.Text = dictObj["FolioID"];
                        //adds LongFolioID(key,value) to dictionary then uses the LongFolioID key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("LongFolioID", item.LongFolioID);
                        txtLongFolioID.Text = dictObj["LongFolioID"];
                        //adds EmbarkationStatus(key,value) to dictionary then uses the EmbarkationStatus key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("EmbarkationStatus", item.EmbarkationStatus);
                        txtEmbarkationStatus.Text = dictObj["EmbarkationStatus"];
                        //adds FolioStatus(key,value) to dictionary then uses the FolioStatus key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("FolioStatus", item.FolioStatus);
                        txtFolioStatus.Text = dictObj["FolioStatus"];
                        //adds AllowCharge(key,value) to dictionary then uses the AllowCharge key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("AllowCharge", item.AllowCharge);
                        txtAllowCharge.Text = dictObj["AllowCharge"];
                        //adds LastName(key,value) to dictionary then uses the LastName key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("LastName", item.LastName);
                        txtLastName.Text = dictObj["LastName"];
                        //adds FirstName(key,value) to dictionary then uses the FirstName key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("FirstName", item.FirstName);
                        txtFirstName.Text = dictObj["FirstName"];
                        //adds FolioType(key,value) to dictionary then uses the FolioType key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("FolioType", item.FolioType);
                        txtFolioType.Text = dictObj["FolioType"];
                        //adds CabinID(key,value) to dictionary then uses the CabinID key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("CabinID", item.CabinID);
                        txtCabinID.Text = dictObj["CabinID"];
                        //adds Deck(key,value) to dictionary then uses the Deck key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("Deck", item.Deck);
                        txtDeck.Text = dictObj["Deck"];
                        //adds Gender(key,value) to dictionary then uses the Gender key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("Gender", item.Gender);
                        txtGender.Text = dictObj["Gender"];
                        //adds Nationality(key,value) to dictionary then uses the Nationality key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("Nationality", item.Nationality);
                        txtNationality.Text = dictObj["Nationality"];
                        //adds ShipCode(key,value) to dictionary then uses the ShipCode key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("ShipCode", item.ShipCode);
                        txtShipCode.Text = dictObj["ShipCode"];
                        //adds AccountID(key,value) to dictionary then uses the AccountID key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("AccountID", item.AccountID);
                        txtAccountID.Text = dictObj["AccountID"];
                        //adds Age(key,value) to dictionary then uses the Age key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("Age", item.Age);
                        txtAge.Text = dictObj["Age"];
                        //adds CrewID(key,value) to dictionary then uses the CrewID key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("CrewID", item.CrewID);
                        txtCrewID.Text = dictObj["CrewID"];
                        //adds PositionCode(key,value) to dictionary then uses the PositionCode key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("PositionCode", item.PositionCode);
                        txtPositionCode.Text = dictObj["PositionCode"];
                        //adds SignOnDate(key,value) to dictionary then uses the SignOnDate key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("SignOnDate", item.SignOnDate);
                        txtSignOnDate.Text = dictObj["SignOnDate"];
                        //adds SignOffDate(key,value) to dictionary then uses the SignOffDate key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("SignOffDate", item.SignOffDate);
                        txtSignOffDate.Text = dictObj["SignOffDate"];
                        //adds AlcoholRestriction(key,value) to dictionary then uses the AlcoholRestriction key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("AlcoholRestriction", item.AlcoholRestriction);
                        txtAlcoholRestriction.Text = dictObj["AlcoholRestriction"];
                        //adds GuestAuth(key,value) to dictionary then uses the GuestAuth key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("GuestAuth", item.GuestAuth);
                        txtGuestAuth.Text = dictObj["GuestAuth"];
                        //adds FolioBalance(key,value) to dictionary then uses the FolioBalance key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("FolioBalance", item.FolioBalance);
                        txtFolioBalance.Text = dictObj["FolioBalance"];
                        //adds BookingID(key,value) to dictionary then uses the BookingID key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("BookingID", item.BookingID);
                        txtBookingID.Text = dictObj["BookingID"];
                        //adds SequenceNumber(key,value) to dictionary then uses the SequenceNumber key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("SequenceNumber", item.SequenceNumber);
                        txtSequenceNumber.Text = dictObj["SequenceNumber"];
                        //adds BillingType(key,value) to dictionary then uses the BillingType key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("BillingType", item.BillingType);
                        txtBillingType.Text = dictObj["BillingType"];
                        //adds Language(key,value) to dictionary then uses the Language key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("Language", item.Language);
                        txtLanguage.Text = dictObj["Language"];
                        //adds PassengerStatus(key,value) to dictionary then uses the PassengerStatus key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("PassengerStatus", item.PassengerStatus);
                        txtPassengerStatus.Text = dictObj["PassengerStatus"];
                        //adds EmbarkationDate(key,value) to dictionary then uses the EmbarkationDate key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("EmbarkationDate", item.EmbarkationDate);
                        txtEmbarkationDate.Text = dictObj["EmbarkationDate"];
                        //adds DebarkationDate(key,value) to dictionary then uses the DebarkationDate key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("DebarkationDate", item.DebarkationDate);
                        txtDebarkationDate.Text = dictObj["DebarkationDate"];
                        //adds ChildAdultFlag(key,value) to dictionary then uses the ChildAdultFlag key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("ChildAdultFlag", item.ChildAdultFlag);
                        txtChildAdultFlag.Text = dictObj["ChildAdultFlag"];
                        //adds SailDate(key,value) to dictionary then uses the SailDate key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("SailDate", item.SailDate);
                        txtSailDate.Text = dictObj["SailDate"];
                        //adds PrintedInvoiceOptOut(key,value) to dictionary then uses the PrintedInvoiceOptOut key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("PrintedInvoiceOptOut", item.PrintedInvoiceOptOut);
                        txtPrintedInvoiceOptOut.Text = dictObj["PrintedInvoiceOptOut"];
                        //adds OffBoard(key,value) to dictionary then uses the OffBoard key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("OffBoard", item.OffBoard);
                        txtOffBoard.Text = dictObj["OffBoard"];
                        //adds MusterStation(key,value) to dictionary then uses the MusterStation key to pull out the value
                        //and send it to the textbox
                        dictObj.Add("MusterStation", item.MusterStation);
                        txtMusterStation.Text = dictObj["MusterStation"];
                    }
                }
                catch
                {

                }
                //print response to txtResults textbox control
                txtResults.Text = result;
                ChargePost(dictObj["AllowCharge"]);
            }
        }
        //guest class
        public class Guest
        {
            //create list
            public List<GuestInfo> FolioDetails { get; set; }
        }
        //list class
        public class GuestInfo
        {
            //gets and sets for both passenger and crew member FolioDetails
            public string VoyageID { get; set; }
            public string PassengerID { get; set; }
            public string FolioID { get; set; }
            public string LongFolioID { get; set; }
            public string EmbarkationStatus { get; set; }
            public string FolioStatus { get; set; }
            public string AllowCharge { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string FolioType { get; set; }
            public string CabinID { get; set; }
            public string Deck { get; set; }
            public string Gender { get; set; }
            public string Nationality { get; set; }
            public string ShipCode { get; set; }
            public string AccountID { get; set; }
            public string Age { get; set; }
            public string CrewID { get; set; }
            public string PositionCode { get; set; }
            public string SignOnDate { get; set; }
            public string SignOffDate { get; set; }
            public string AlcoholRestriction { get; set; }
            public string GuestAuth { get; set; }
            public string FolioBalance { get; set; }
            public string BookingID { get; set; }
            public string SequenceNumber { get; set; }
            public string BillingType { get; set; }
            public string Language { get; set; }
            public string PassengerStatus { get; set; }
            public string EmbarkationDate { get; set; }
            public string DebarkationDate { get; set; }
            public string ChildAdultFlag { get; set; }
            public string SailDate { get; set; }
            public string PrintedInvoiceOptOut { get; set; }
            public string OffBoard { get; set; }
            public string MusterStation { get; set; }
        }
        /****************************************************************************
         * *********functionality of application charge posting*********************
         * *************************************************************************/
        public static void ChargePost(string canCharge)
        {
            if (canCharge == "1")
            {
                // Create a request using a URL that can receive a post.   
                WebRequest request = WebRequest.Create("https://xxxxxxxx.xxxx/xxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxxxx");
                // Set the Method property of the request to POST.  
                request.Method = "POST";
                // Create POST data and convert it to a byte array.  
                string postData = "Charge Applied";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                // Set the ContentType property of the WebRequest.  
                request.ContentType = "application/JSON";
                // Set the ContentLength property of the WebRequest.  
                request.ContentLength = byteArray.Length;

                // Get the request stream.  
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.  
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.  
                dataStream.Close();

                // Get the response.  
                WebResponse response = request.GetResponse();
                // Display the status.   

                Console.WriteLine(((HttpWebResponse)response).StatusDescription);


                // Get the stream containing content returned by the server.  
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.  
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.  
                    string responseFromServer = reader.ReadToEnd();
                    // Display the content.  
                    Console.WriteLine(responseFromServer);
                }
                // Close the response.  
                response.Close();
            }
            else
            {
                MessageBox.Show("Cannot charge");
            }
        }
    }
}
