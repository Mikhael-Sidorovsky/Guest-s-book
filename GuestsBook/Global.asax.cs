using GuestsBook.encription;
using GuestsBook.models;
using System;
using System.Data.Entity;
using System.IO;

namespace GuestsBook
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                // Присваиваем имя алгоритму шифрования 
                EncryptionUtility.AlgorithmName = "DES";
                var location = AppDomain.CurrentDomain.BaseDirectory;
                //Для выделения пути к каталогу воспользуемся `System.IO.Path`:
                EncryptionUtility.KeyFile = Path.GetDirectoryName(location) + "/key.config";
                if (!File.Exists(EncryptionUtility.KeyFile))
                    EncryptionUtility.GenerateKey();
                Database.SetInitializer<GuestBookContext>(new GuestsBookInitializer());
            }
            catch(Exception)
            {
                Response.Write("Error generating encryption key!");
            }
        }
    }
}