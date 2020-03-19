using GuestsBook.encription;
using GuestsBook.models;
using System;
using System.Linq;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace GuestsBook.forms
{
    public partial class login : System.Web.UI.Page
    {
        User user = new User();

        public void LoginServerValidation(object source, ServerValidateEventArgs args)
        {
            try
            {
                using (GuestBookContext context = new GuestBookContext())
                {
                    if (context.Users.Where(x => x.Login == Login.Value).Any()
                        || context.Users.Where(x => x.Email == Login.Value).Any())
                    {
                        if(context.Users.Where(x => x.Login == Login.Value).Any())
                        {
                            user = context.Users.Where(x => x.Login == Login.Value).FirstOrDefault();
                            try
                            {
                                // шифруем пароль
                                string pass = EncryptionUtility.DecryptDate(user.Password);
                                if (pass != Password.Value)
                                    args.IsValid = false;
                            }
                            catch (Exception)
                            {
                                Response.Write("<h2>Возникла ошибка при шифровании!</h2>");
                                args.IsValid = false;
                            }                            
                        }
                        else
                        {
                            user = context.Users.Where(x => x.Email == Login.Value).FirstOrDefault();
                            try
                            {
                                // шифруем пароль
                                string pass = EncryptionUtility.DecryptDate(user.Password);
                                if (pass != Password.Value)
                                    args.IsValid = false;
                            }
                            catch (Exception)
                            {
                                Response.Write("<h2>Возникла ошибка при шифровании!</h2>");
                                args.IsValid = false;
                            }
                        }
                    }
                    else
                        args.IsValid = false;
                }
            }
            catch (Exception)
            {
                args.IsValid = false;
            }
        }

        protected void enter_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                FormsAuthentication.RedirectFromLoginPage(user.Login + "!", false);
            }                
        }
    }
}