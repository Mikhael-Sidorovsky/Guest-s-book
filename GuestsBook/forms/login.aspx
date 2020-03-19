<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="GuestsBook.forms.login" MasterPageFile="~/forms/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <asp:CustomValidator ID="LoginValidator"
        ControlToValidate="login"
        ErrorMessage="Wrong login or password!!!"
        OnServerValidate="LoginServerValidation"
        ForeColor="red"
        Font-Name="verdana"
        Font-Size="10pt"
        runat="server" />
    <div class="form-group">
        <label for="Login">Login or email:</label>
        <input type="text"
            id="Login"
            class="form-control"
            placeholder="Enter login or email"
            required
            runat="server" />
        <small class="form-text text-muted">We'll never share your email with anyone else.</small>
    </div>
    <div class="form-group">
        <label for="Password">Password:</label>
        <input type="password"
            id="Password"
            class="form-control"
            placeholder="Enter your password"
            required
            runat="server" />
    </div>
    <div class="form-group">
        <asp:Button ID="enter" CssClass="btn btn-primary mb-4" Text="Log in" OnClick="enter_Click" runat="server" />
    </div>
</asp:Content>
