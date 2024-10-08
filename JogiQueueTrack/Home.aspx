﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="JogiQueueTrack.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="refresh" content="30"  />
    <title>JOGI Ayurved Multispeciality Hospital</title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:BundleReference runat="server" Path="~/Content/css" />
    <link href="~/Jogi.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="~/Content/bootstrap.css" rel="stylesheet" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <meta http-equiv="refresh" content="30" />
    <style>
        /*.jumbotron {
            background-color: #cfe2f3;
        }*/
        .auto-style1 {
            font-weight: bold;
        }


        * {
            margin: 0;
            padding: 0;
        }

        img {
            width: 15%;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        @media(max-width:360px) {
            img {
                vertical-align: middle;
                text-align: center;
            }
        }

        .auto-style2 {
            left: 51%;
            top: -2147483648%;
        }

        .auto-style3 {
            position: relative;
            min-height: 1px;
            float: left;
            width: 100%;
            left: 0px;
            top: 0px;
            height: 261px;
            padding-left: 15px;
            padding-right: 15px;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <div class="container col-md-12" style="margin-top:20%">
            <div class="row">
                <br />
                <br />
                <br />
                <br />

                <div class="col-sm-6">
                    <%--<asp:Image ID="Image3" runat="server" ImageUrl="~/personwaiting.jpg" Width="30%" HorizontalAlign="Center" />--%>
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/JOGINewRound.png" Width="60%" HorizontalAlign="Center" />
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />

                <%--<div class="col-md-6">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/JOGINewRound.png" Width="10%" />
                </div>--%>
                <br />
                <div class="col-md-12">
                    <div class="jumbotron bg-primary" style="background-color: #3a6f78; font-family: Montserrat;" aria-orientation="horizontal">
                        <h1 id="mainHeading" style="color: #FFFFFF; font-size: 4rem;">JOGI Ayurved Multispeciality Hospital</h1>
                        <br />
                        <p class="lead" style="color: #FFFFFF; font-size: 4rem;">Track Your Queue</p>
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
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <div class="col-sm-6">
                        <%--<asp:Image ID="Image2" runat="server" ImageUrl="~/personwaiting.jpg" Width="80%" HorizontalAlign="Center" />--%>
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/circle.png" Width="90%" HorizontalAlign="Center" />
                    </div>

                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />

                    <div class="form-row" style="font-family: Montserrat;">
                        <div class="form-group col-md-12">
                            <strong><b>
                                <asp:Label ID="lblName_" runat="server" Font-Bold="True" Style="font-size: 5rem;">Name :-  </asp:Label><br />
                            </b></strong>
                            <strong><b>
                                <asp:Label ID="lblQueueNo" runat="server" Font-Bold="True" Style="font-size: 5rem;">Your Token No :-  </asp:Label><br />
                            </b></strong>

                            <strong>
                                <asp:Label ID="lblRemainToken" runat="server" CssClass="auto-style1" Style="font-size: 5rem;">Waiting :-</asp:Label></strong><br />
                        </div>
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
