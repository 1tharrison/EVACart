using EVACart.Models;
using System.Web.Mvc;
using System.Net.Mail;
using System.Web;
using System.Linq;
using System.Collections.Generic;
using System;
namespace IdentitySample.Controllers
{
   public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        public ActionResult About()
        {

            return View();
        }
        public ActionResult ThankYou()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactViewModel cvw)
        {
            //This checks to see if the data sent in is valid and if it is NOT
            //it will return them to the form with the data they submitted
            //so that the form will be repopulated for them.

            if (!ModelState.IsValid)
            {
                return View(cvw);
            }
            //if we get to this point, the form data WAS valid and now we can create
            //our mailMesage and send it. 

            //This is us writing our letter
            string body = string.Format("{0} has sent you an message with a subject of {1}."
            + "The message is: <br /><br />{2}.<br /><br /> You can contact them at {3}", cvw.Name, cvw.Subject, cvw.Message, cvw.Email);

            //This is us putting that letter into an envelope and addressing it.
         MailMessage msg = new MailMessage(
                "tony@itnachos.com", //from
                "99tharrison@google.com", //to
                "New message from the website",//subject
                body);//body is the message constructed above
            msg.Priority = MailPriority.High;
            msg.IsBodyHtml = true;//because we have inserted html in  our 

            //the using statement here states that once we exit the scope of 
            //the using statement, we are finished with 
            //the object we instanciated inside so it is OK for the 
            //.net garbage collector to remove that object from Memory
            //using (SmtpClient client = new SmtpClient("relay-hosting.secureserver.net"))
            //{
            //    //settings to use Centriq GMail relay
            //    //client.EnableSsl = true;
            //    //client.UseDefaultCredentials = false;
            //    //client.Credentials = new System.Net.NetworkCredential("centriqRelay@gmail.com", "c3ntriQc3ntriQ");
            //    //client.Host = "smtp.gmail.com";
            //    //client.Port = 587;
            //    //client.DeliveryMethod = SmtpDeliveryMethod.Network;


            //    client.Send(msg);
            //}


            //setting for GoDaddy Server
            //**********Note********
            //On the goDaddy server, the FROM address in the mailmessage object above MUST be an email address
            //on your godaddy account ****(Matt@GreenwoodOutdoors.com)****

            /*Step two
             Comment out all of the client.code above and umcomment all of the following code.*/



                using (SmtpClient client = new SmtpClient("relay-hosting.secureserver.net")) { client.Send(msg); }


            //this is us taking that envelope to the post office and mailing it.
                return RedirectToAction("ThankYou", cvw);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }
       public ActionResult Products()
        {
            return View();
        }


    }
}


