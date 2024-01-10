using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;


namespace CRM_Portal.Models
{
    public class CSOModel
    {
        public static string GetTitleName()
        {
            SecureString securePassword = new SecureString();
            foreach (char c in "YourPassword")
                securePassword.AppendChar(c);
  

            using (ClientContext ctx = new ClientContext("https://firstmillscom.sharepoint.com/sites/FIORI/Data_Restoration_Request"))
            {
                ctx.Credentials = new System.Net.NetworkCredential("sp.dev@firstmills.com", "Zz@786705");
                Web myWeb = ctx.Web;
                ctx.Load(myWeb, t => t.Title);
                ctx.ExecuteQuery();
                return myWeb.Title;
                //ctx.AuthenticationMode = ClientAuthenticationMode.Default;
                //SecureString securePassword = new SecureString();
                //foreach (char c in "YourPassword")
                //    securePassword.AppendChar(c);
                //ctx.Credentials = new SharePointOnlineCredentials("bijay@tsinfo.onmicrosoft.com", securePassword);
            }
        }

    }
}
