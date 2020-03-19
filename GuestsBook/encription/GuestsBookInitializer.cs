using GuestsBook.models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuestsBook.encription
{
    public class GuestsBookInitializer : CreateDatabaseIfNotExists<GuestBookContext>
    {
        protected override void Seed(GuestBookContext db)
        {
            User user = new User { FirstName = "Admin", LastName = "Adminov", Email = "admin@admin.ad", Login = "admin", Password = EncryptionUtility.EncryptData("querty") };
            db.Users.Add(user);
            db.SaveChanges();
        }
    }
}