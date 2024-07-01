<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="JogiQueueTrack.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <%--<h2><%: Title %>.</h2>--%>
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
                        <br>
                    </span>
                </div>

                <div class="col-md-3 text-center">

                    <span>
                        <img src="clock.png" class="img-fluid">
                        <br>
                        <br>
                        09:00 AM – 09:30 PM 
                        <br>
                    </span>
                    </span>
                </div>

                <div class="col-md-3 text-center">

                    <span>
                        <img src="mail.png" class="img-fluid">
                        <br>
                        <br>
                        jogiayurved@gmail.com
                        <br>
                    </span>
                </div>

                <div class="col-md-3 text-center">

                    <span>
                        <img src="map.png" class="img-fluid">
                        <br>
                        <br>
                        <%--<button class="btn btn-primary">Get Direction</button>--%>
                        <a href="https://www.google.com/maps/place/Jogi+Ayurved+Hospital/@21.1962422,72.7960096,17z/data=!4m6!3m5!1s0x3be04dd47c4601fd:0x43c08a38f5e46ce6!8m2!3d21.1934752!4d72.7988687!16s%2Fg%2F12qflcc3z?entry=ttu" class="btn btn-info" role="button">
                            Get Direction</a>
                        <br>    
                    </span>

                </div>

            </div>
        </p>

<%--    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>--%>
</asp:Content>
