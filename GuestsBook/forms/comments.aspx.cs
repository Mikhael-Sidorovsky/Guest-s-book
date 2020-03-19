using GuestsBook.models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace GuestsBook.forms
{
    public partial class comments : System.Web.UI.Page
    {
        protected void AddComment_Click(object sender, EventArgs e)
        {
            try
            {
                using (GuestBookContext context = new GuestBookContext())
                {
                    TextBox textBox = (TextBox)LoginView1.FindControl("comment");
                    Comment comm = new Comment();
                    comm.Date = DateTime.Now;
                    comm.CommentBody = textBox.Text;
                    string str = User.Identity.Name.Replace("!", "");
                    User user = context.Users.Where(x => x.Login == str).FirstOrDefault();
                    comm.UserId = user.Id;
                    context.Comments.Add(comm);
                    context.SaveChanges();
                    textBox.Text = "";
                }
            }
            catch(Exception ex)
            {
                string str = string.Format("<h1>{0}</h1>", ex.Message);
                Response.Write(str);
            }
        }
    }
}