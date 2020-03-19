<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registration.aspx.cs" Inherits="GuestsBook.forms.registration" MasterPageFile="~/forms/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="errorSummary" data-valmsg-summary="true" class="error">
        <ul>
            <li style="display: none"></li>
        </ul>
        <asp:ValidationSummary runat="server" CssClass="error" />
    </div>
    <div class="form-group">
        <label for="FirstName">First name:</label>
        <asp:RequiredFieldValidator
            ControlToValidate="FirstName"
            ErrorMessage="Name is required field"
            CssClass="error"
            Text="*"
            runat="server" />
        <input type="text"
            id="FirstName"
            class="form-control"
            placeholder="Name"
            runat="server" />
    </div>
    <div class="form-group">
        <label for="LastName">Last name:</label>
        <asp:RequiredFieldValidator
            ControlToValidate="LastName"
            ErrorMessage="Last name is required field"
            CssClass="error"
            Text="*"
            runat="server" />
        <input type="text"
            id="LastName"
            class="form-control"
            placeholder="Last name"
            runat="server" />
    </div>
    <div class="form-group">
        <label for="Email">Email:</label>
        <asp:RequiredFieldValidator
            ControlToValidate="Email"
            ErrorMessage="Email is required field"
            CssClass="error" Text="*"
            runat="server" />
        <asp:RegularExpressionValidator
            ControlToValidate="Email"
            ValidationExpression=".*@.{2,}\..{2,}"
            ErrorMessage="Invalid format E-mail"
            Display="dynamic"
            runat="server">*</asp:RegularExpressionValidator>
        <asp:CustomValidator ID="UniqueValidator"
            ControlToValidate="Email"
            ErrorMessage="A user with this email already exists!"
            OnServerValidate="EmailServerValidation"
            ForeColor="red"
            Font-Name="verdana"
            Font-Size="10pt"
            EnableClientScript="False"
            runat="server" />
        <input type="email"
            id="Email"
            class="form-control"
            placeholder="Email example@example.com"
            runat="server" />
    </div>
    <div class="form-group">
        <label for="Login">Login:</label>
        <asp:RequiredFieldValidator
            ControlToValidate="Login"
            ErrorMessage="Phone is required field"
            CssClass="error" Text="*"
            runat="server" />
        <asp:CustomValidator ID="LoginValidator"
            ControlToValidate="Login"
            ErrorMessage="A user with this login already exists!"
            OnServerValidate="LoginServerValidation"
            ForeColor="red"
            Font-Name="verdana"
            Font-Size="10pt"
            runat="server" />
        <input type="text"
            id="Login"
            class="form-control"
            placeholder="Login"
            runat="server" />
        <asp:RegularExpressionValidator
            ControlToValidate="Login"
            ValidationExpression="\w{6,10}"
            ErrorMessage="Login must contain from 6 to 10 characters."
            EnableClientScript="false"
            runat="server" />
    </div>
    <div class="form-group">
        <label for="Password">Password:</label>
        <asp:RequiredFieldValidator
            ControlToValidate="Password"
            ErrorMessage="Password is required field"
            CssClass="error"
            Text="*"
            runat="server" />
        <input type="password"
            id="Password"
            class="form-control"
            placeholder="Password"
            runat="server" />
        <asp:RegularExpressionValidator
            ControlToValidate="Password"
            ValidationExpression="\w{6,12}"
            ErrorMessage="Password must contain from 6 to 12 characters."
            EnableClientScript="false"
            runat="server" />
    </div>
    <div class="form-group">
        <label for="ConfirmPassword">Confirm password:</label>
        <asp:RequiredFieldValidator
            ControlToValidate="ConfirmPassword"
            ErrorMessage="Confirm password is required field"
            CssClass="error"
            Text="*"
            runat="server" />
        <input type="password"
            id="ConfirmPassword"
            class="form-control"
            placeholder="Confirm password"
            runat="server" />
        <asp:CompareValidator
            ControlToValidate="ConfirmPassword"
            ControlToCompare="Password"
            Type="String"
            ErrorMessage="Passwords do not match."
            Display="dynamic"
            runat="server" />
    </div>
    <div class="form-group">
        <asp:Button ID="reg" type="button" class="btn btn-primary mb-4" OnClick="RegistrationClick" Text="Registration" runat="server" />
    </div>
</asp:Content>
