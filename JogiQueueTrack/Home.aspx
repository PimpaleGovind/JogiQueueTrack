<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="JogiQueueTrack.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JOGI Ayurved Multispeciality Hospital</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/Jogi.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="~/Content/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="refresh" content="30">
    <style>
        /*.jumbotron {
            background-color: #cfe2f3;
        }*/
        .auto-style1 {
            font-weight: bold;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <div class="container col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <div class="jumbotron bg-primary" style="background-color: #3a6f78" aria-orientation="vertical">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Round.jpg" width="05%" />
                        <h1 id="mainHeading" style="color: #FFFFFF; font-size:4rem;">JOGI Ayurved Multispeciality Hospital</h1>
                        <p class="lead" style="color: #FFFFFF; font-size:4rem;">Track Your Queue</p>
                    </div>

                    <%--Link Expiry Msg--%>
                    <div class="" id="Expired" runat="server" visible="false" style="background-color: red;" width="50%">
                        <h2 style="text-align: center; color: white; align-content: center;">Link Expired !
                        </h2>
                    </div>
                </div>
            </div>
            <div>
            

                        <form enablecenteralign="true">

                            <%--<marquee direction  Left" style="font-family:cambria; font-size: 4rem; color: #191970; "><strong>Please be on Your Time</strong></marquee>

                            <div class="form-row">
                                <img src="calendar.png" alt="Alternate Text" id="imgSchedule"   />
                            </div>--%>

                            <div class="form-row" style="font-family:cambria: #ffffff; ">
                                <div class="form-group col-md-12">
                                        <strong><b><asp:Label ID="lblQueueNo" runat="server" Font-Bold="True" style=" font-size: 5rem;">Your Token No :-  </asp:Label><br></b></strong>
                                </div>
                            </div>

                                <div class="form-group col-md-12" style="font-family:cambria: #fff; ">
                                    <strong>
                                            <asp:Label ID="lblRemainToken" runat="server" CssClass="auto-style1" style="font-size: 5rem;">Remain Token No. :-</asp:Label></strong><br>
                                </div>
                        </form>

                        <asp:TextBox ID="txtCurrentQueue" runat="server" BorderStyle="None" Enabled="False" ReadOnly="True" Visible="False"></asp:TextBox>

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </div>

                </div>

        <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick">
        </asp:Timer>
    </form>
</body>
</html>
