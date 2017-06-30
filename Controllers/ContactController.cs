using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Twilio.Http;
using Twilio.Clients;

namespace PhoneBook.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult contactList()
        {
            //get the Json filepath  
            string file = Server.MapPath("~/App_Data/Contacts.json");
            //deserialize JSON from file  
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var personlist = ser.Deserialize<List<Contacts>>(Json);
            return View(personlist);
        }


        [HttpGet]
        public ActionResult sendMessage(int id)
        {
            ViewBag.ran = this.generate6digitNumber();
            return View();
        }

        
        public ActionResult sendSMSUsingAPI()
        {
            //Twilio.Types.PhoneNumber Ph = new Twilio.Types.PhoneNumber("9962298977");

            //Twilio.Rest.Api.V2010.Account.CreateMessageOptions CM = new Twilio.Rest.Api.V2010.Account.CreateMessageOptions(Ph);
            //CM.ApplicationSid = "d536ebc5f53c8a57760e00f9b055b522";
            //CM.PathAccountSid = "AuthCode";
            //CM.Body = "Hi Arpit";
            TwilioRestClient rc = new TwilioRestClient("arpityuuvraaj@gmail.com", "", "AC90c71126786d47d8c670f25849362012");
            
            return View();
        }

        [HttpGet]
        public ActionResult smsLogs()
        {
            //get the Json filepath  
            string file = Server.MapPath("~/App_Data/SMSLog.json");
            //deserialize JSON from file  
            string Json = System.IO.File.ReadAllText(file);
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var personlist = ser.Deserialize<List<SMSLog>>(Json);
            return View(personlist);
        }

        private string generate6digitNumber()
        {
            Random generator = new Random();
            String ran = generator.Next(0, 1000000).ToString("D6");
            return "Hi, Your OTP is: " + ran;
        }

    }
}
