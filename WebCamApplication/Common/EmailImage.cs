using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;
using WebCamApplication.Models;

namespace WebCamApplication.Common
{
    public class EmailImage
    {
        private EmailCredModel _ecm;
        public EmailImage(EmailCredModel ecm)
        {
            this._ecm = ecm;
        }
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(EmailImage));
      

       
        public  bool EmailMethod(DrawingModel model)
        {
            try
            {

                _ecm.EmailAdress = System.Configuration.ConfigurationManager.AppSettings["userEmail"];
                _ecm.Password = System.Configuration.ConfigurationManager.AppSettings["userPassword"];
                //create the mail message
                MailMessage mail = new MailMessage();

            //set the addresses
            mail.From = new MailAddress(_ecm.EmailAdress);
            mail.To.Add(model.EmailAddress);

            //set the content
            mail.Subject = string.Format("This is an email from {0}", model.UserName);

            //first we create the Plain Text part
            AlternateView plainView = AlternateView.CreateAlternateViewFromString("This is my plain text content, viewable by those clients that don't support html", null, "text/plain");

            //then we create the Html part
            //to embed images, we need to use the prefix 'cid' in the img src value
            //the cid value will map to the Content-Id of a Linked resource.
            //thus <img src='cid:companylogo'> will map to a LinkedResource with a ContentId of 'companylogo'
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(string.Format("Here is Post Card {0} .<img src=cid:companylogo>",model.UserName), null, "text/html");
            var imageDatar = Convert.FromBase64String(model.imageData);

            var contentId = Guid.NewGuid().ToString();
            var linkedResource = new LinkedResource(new MemoryStream(imageDatar), "image/jpeg");
            linkedResource.ContentId = contentId;
            linkedResource.TransferEncoding = TransferEncoding.Base64;

            var body = string.Format("<img src=\"cid:{0}\" />", contentId);

            htmlView.LinkedResources.Add(linkedResource);
            //add the views
            mail.AlternateViews.Add(plainView);
            mail.AlternateViews.Add(htmlView);


            //send the message
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential(_ecm.EmailAdress, _ecm.Password ),
                EnableSsl = true
            };


            client.Send(mail);
                return true;
            }
            catch (Exception e)
            {

                log.Error(e);
                return false;
            }finally
            {
               
            }
            //////////////////////////////
        }

    }
}