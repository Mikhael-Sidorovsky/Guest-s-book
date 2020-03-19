<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GuestsBook.forms.Default" MasterPageFile="~/forms/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="BodyContent" runat="server">
    <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
        <ol class="carousel-indicators">
            <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
            <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
        </ol>
        <div class="carousel-inner" style="height:400px">
            <div class="carousel-item active">
                <img class="d-block w-100" src="../images/1.jpg" alt="Первый слайд">
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" src="../images/2.jpg" alt="Второй слайд">
            </div>
            <div class="carousel-item">
                <img class="d-block w-100" src="../images/3.jpg" alt="Третий слайд">
            </div>
        </div>
    </div>
    <div class="container-fluid">
        <div class="row jumbotron">
            <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 col-xl-10">
                <h1><b>Guest Book</b> Web Application!</h1>
                <p class="lead">                     
                    On the main page we welcome you! :) <br />Here you can see 
                    a slideshow of several images. In the "Comments" tab, you can see user reviews 
                    about something! You can also leave a comment. To do this, you need to register 
                    and log in. Every visitor to our site is important to us! <br />We wish you a pleasant 
                    stay on our site! <br />If you liked it, tell everyone, if not, tell us!
                </p>
            </div>
        </div>
    </div>
</asp:Content>
