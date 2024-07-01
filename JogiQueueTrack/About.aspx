<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="JogiQueueTrack.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container col-md-12">
        <h2>About Us</h2>
        <h2>JOGI Ayurved Hospital</h2>
        <p>
            <%--<asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="https://www.google.com/maps/place/Jogi+Ayurved+Hospital/@21.1962422,72.7960096,17z/data=!4m7!3m6!1s0x3be04dd47c4601fd:0x43c08a38f5e46ce6!8m2!3d21.1934752!4d72.7988687!15sCgxqb2dpIGF5dXJ2ZWRaDiIMam9naSBheXVydmVkkgEIaG9zcGl0YWyaASNDaFpEU1VoTk1HOW5TMFZKUTBGblNVUmxibkpmZEZKQkVBReABAA!16s%2Fg%2F12qflcc3z?entry=tts">A- 301/302, 3rd Floor, Shreeji Arcade, Behind Bhulka Bhawan School, Anand Mahal Road, Adajan, Surat – 395009</asp:LinkButton>--%><br>
            <img src="location.png" class="img-fluid"><br>
            <br>
            <br>

            <a href="https://www.google.com/maps/place/Jogi+Ayurved+Hospital/@21.1962422,72.7960096,17z/data=!4m7!3m6!1s0x3be04dd47c4601fd:0x43c08a38f5e46ce6!8m2!3d21.1934752!4d72.7988687!15sCgxqb2dpIGF5dXJ2ZWRaDiIMam9naSBheXVydmVkkgEIaG9zcGl0YWyaASNDaFpEU1VoTk1HOW5TMFZKUTBGblNVUmxibkpmZEZKQkVBReABAA!16s%2Fg%2F12qflcc3z?entry=tts">
                <lable>A- 301/302, 3rd Floor, Shreeji Arcade, Behind Bhulka Bhawan School, Anand Mahal Road, Adajan, Surat – 395009</lable></a>
            <br>
            <br>

            <div class="row">
                <div class="col-md-3 text-center">

                    <span>
                        <img src="telephone.png" class="img-fluid">
                        <br>
                        <br>
                        +918140946153<br>
                        02612736499

                    </span>
                </div>

                <div class="col-md-3 text-center">

                    <span>
                        <img src="clock.png" class="img-fluid">
                        <br>
                        09:00 AM – 09:30 PM 
                    </span>
                    </span>
                </div>

                <div class="col-md-3 text-center">

                    <span>
                        <img src="mail.png" class="img-fluid">
                        <br>
                        jogiayurved@gmail.com
                    </span>
                    </span>
                </div>

                <div class="col-md-3 text-center">

                    <span>
                        <img src="map.png" class="img-fluid">
                        <br>
                        <button class="btn btn-primary">Get Direction</button>
                    </span>

                </div>

            </div>
        </p>
    </div>
</asp:Content>
