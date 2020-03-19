using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GuestsBook.models
{
    public class GuestBookContext : DbContext
    {
        public GuestBookContext() : base("GuestBookDBConnection") {}
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}