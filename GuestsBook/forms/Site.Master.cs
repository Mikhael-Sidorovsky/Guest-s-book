using System;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace GuestsBook
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void LoginStatus_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            
            // очищаем куки аутентификации
            HttpCookie formsСookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            formsСookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(formsСookie);

            // очищаем куки сессии
            SessionStateSection sessionStateSection = (SessionStateSection)WebConfigurationManager.GetSection("system.web/sessionState");
            HttpCookie sessionCookie = new HttpCookie(sessionStateSection.CookieName, "");
            sessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(sessionCookie);

            // переадрисовываем на главную страницу
            Response.Redirect("~/forms/Default.aspx");
        }
    }
}