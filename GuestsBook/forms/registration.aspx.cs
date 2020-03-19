using GuestsBook.encription;
using GuestsBook.models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace GuestsBook.forms
{
    public partial class registration : System.Web.UI.Page
    {
        protected void RegistrationClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    using (GuestBookContext context = new GuestBookContext())
                    {
                        User newUser = new User();
                        newUser.FirstName = FirstName.Value;
                        newUser.LastName = LastName.Value;
                        newUser.Email = Email.Value;
                        newUser.Login = Login.Value;
                        try
                        {
                            // шифруем пароль
                            newUser.Password = EncryptionUtility.EncryptData(Password.Value);
                        }
                        catch (Exception)
                        {
                            Response.Write("<h2>Возникла ошибка при шифровании!</h2>");
                        }

                        context.Users.Add(newUser);
                        context.SaveChanges();
                        // в случай успешной регистрации пользователь будет переадресован на страничку входа
                        Response.Redirect("login.aspx");
                    }
                }
                catch (Exception)
                {
                    Response.Write("<h2>Возникла ошибка при регистрации!</2>");
                }
            }
        }

        // Проверяем на уникальность email пользователя
        public void EmailServerValidation(object source, ServerValidateEventArgs args)
        {
            try
            {
                using (GuestBookContext context = new GuestBookContext())
                {
                    if (context.Users.Where(x => x.Email == Email.Value).Any())
                    {
                        args.IsValid = false;
                    }
                }
            }
            catch (Exception)
            {
                args.IsValid = false;
            }
        }

        // Проверяем на уникальность login пользователя
        public void LoginServerValidation(object source, ServerValidateEventArgs args)
        {
            try
            {
                using (GuestBookContext context = new GuestBookContext())
                {
                    if (context.Users.Where(x => x.Login == Login.Value).Any())
                    {
                        args.IsValid = false;
                    }
                }
            }
            catch (Exception)
            {
                args.IsValid = false;
            }
        }
    }
}