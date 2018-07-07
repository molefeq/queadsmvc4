using QueAds.Common.Utilities;

using QueAdsMvc4.Presentation.ServiceHandlers.Interfaces;
using QueAdsMvc4.Presentation.ViewModels;

using System;
using System.Configuration;
using System.Text;

namespace QueAdsMvc4.Presentation.ServiceHandlers.Classes
{
    public class ContactUsServiceHandler : IContactUsHandler
    {
        public void ContactUs(ContactUsViewModel model)
        {
            string smtpServerAddress = ConfigurationManager.AppSettings["SMTPAddress"];
            int smtpPortNumber = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPortNumber"]);
            string fromAddress = ConfigurationManager.AppSettings["FromAddress"];
            string toEmailAddress = model.EmailAddress;

            string subject = string.Format("Contact From : {0}", model.UserDetails);

            StringBuilder sb = new StringBuilder();
            
            sb.Append(string.Format("{0} has contacted you with the following message:", model.UserDetails));
            sb.Append("<br />");
            sb.Append(model.Message);
            sb.Append("<br />");
            sb.Append("<br />");
            sb.Append("Thank you,");
            sb.Append("<br />");
            sb.Append("Online Classifieds");

            EmailHandler.SendEmail(smtpServerAddress, smtpPortNumber, fromAddress, toEmailAddress, null, subject, sb.ToString());
        }
    }
}
