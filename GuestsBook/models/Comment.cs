using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuestsBook.models
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CommentBody { get; set; }
        public int UserId { get; set; }
    }
}