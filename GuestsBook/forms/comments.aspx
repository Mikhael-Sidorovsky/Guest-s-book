<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="comments.aspx.cs" Inherits="GuestsBook.forms.comments" MasterPageFile="~/forms/Site.Master" %>

<%@ Import Namespace="GuestsBook.models" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <div class="form-group">
                <ul class="list-group list-group-flush" runat="server">
                    <% 
                        string htmlString = "";
                        using (GuestBookContext context = new GuestBookContext())
                        {
                            List<Comment> comments = context.Comments.ToList<Comment>();
                            if (comments.Count == 0)
                                htmlString += String.Format("<li class='list-group-item bg-transparent'>" +
                                    "<h3 class='text-center'>No comments yet</h3></li>");
                            else
                            {
                                foreach (var comment in comments)
                                {
                                    User user = context.Users.Where(x => x.Id == comment.UserId).FirstOrDefault();
                                    htmlString += String.Format("<li class='list-group-item bg-transparent'><div class='media'>" +
                                    "<img class='d-flex mr-3' src='../images/ava.png' alt='Generic placeholder image'>" +
                                    "<div class='media-body'>" +
                                    "<h5 class='mt - 0'>{0}</h5>" +
                                    "<p class='text-muted'> {1}</p>" +
                                    "{2}</div></div></li>", user.FirstName + " " + user.LastName, comment.Date.ToString(), comment.CommentBody);
                                }
                            }
                            Response.Write(htmlString);
                        }
                    %>
                    <li class='list-group-item bg-transparent text-warning'>
                        <h2 class="text-center">You cannot add a comment because not logged in!</h2>
                    </li>
                </ul>
            </div>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <div class="form-group" runat="server">
                <ul class="list-group list-group-flush" runat="server">
                    <% 
                        string htmlString = "";
                        using (GuestBookContext context = new GuestBookContext())
                        {
                            List<Comment> comments = context.Comments.ToList<Comment>();
                            if (comments.Count == 0)
                                htmlString += String.Format("<li class='list-group-item bg-transparent'>" +
                                    "<h3 class='text-center'>No comments yet</h3></li>");
                            else
                            {
                                foreach (var comment in comments)
                                {
                                    User user = context.Users.Where(x => x.Id == comment.UserId).FirstOrDefault();
                                    htmlString += String.Format("<li class='list-group-item bg-transparent'><div class='media'>" +
                                    "<img class='d-flex mr-3' src='../images/ava.png' alt='Generic placeholder image'>" +
                                    "<div class='media-body'>" +
                                    "<h5 class='mt - 0'>{0}</h5>" +
                                    "<p class='text-muted'> {1}</p>" +
                                    "{2}</div></div></li>", user.FirstName + " " + user.LastName, comment.Date.ToString(), comment.CommentBody);
                                }
                            }
                            Response.Write(htmlString);
                        }
                    %>
                </ul>
            </div>
            <div id="commentBlock" class="form-group" runat="server">
                <label for="comment">Comment:</label>
                <asp:TextBox ID="comment" CssClass="form-control" TextMode="MultiLine" Rows="5" Style="resize: none" runat="server"></asp:TextBox>
                <asp:Button ID="addComment" CssClass="btn btn-primary mb-4 mt-4" OnClick="AddComment_Click" Text="Add comment" runat="server" />
            </div>
        </LoggedInTemplate>
    </asp:LoginView>
</asp:Content>
