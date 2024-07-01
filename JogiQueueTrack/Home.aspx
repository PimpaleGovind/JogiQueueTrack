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

    <style>
        .jumbotron {
            background-color: #cfe2f3;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server">
        <div class="container col-md-12">
            <div class="row">
                <div class="col-md-12">
                    <div class="jumbotron bg-primary" style="background-color: #cfe2f3">
                        <h1>JOGI Multispeciality Hospital</h1>
                        <p class="lead">Track Your Queue</p>
                    </div>

                    <%--Link Expiry Msg--%>
                    <div class="" id="Expired" runat="server" visible="false" style="background-color: red;" width="50%">
                        <h2 style="text-align: center; color: white; align-content: center;">Link Expired !
                        </h2>
                    </div>


                </div>
            </div>

            <div class="row">
                <div class="col-md-12 centerBlock">
                    <div class="table-responsive">
                        <asp:GridView ID="gvQueue" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-condensed">
                            <Columns>
                                <asp:BoundField HeaderText="Queue No." DataField="QueueNo" />
                                <asp:BoundField HeaderText="Appo. Time" DataField="ADtmFrom" />
                                <asp:BoundField HeaderText="Patient Name" DataField="LedgerName" />
                                <asp:BoundField Visible="false" DataField="UserName" />
                                <asp:BoundField HeaderText="Aprrox Time" DataField="AproxTime" />
                                <asp:BoundField Visible="false" DataField="Remark" />
                            </Columns>
                        </asp:GridView>



                        <form enablecenteralign="true">

                            <marquee direction="Left" style="font-family=cambria; font-size: 4rem; color: #191970"><strong>Please be on Your Time</strong></marquee>

                            <div class="form-row">
                                <img src="calendar.png" alt="Alternate Text" id="imgSchedule"   />
                            </div>

                            <%--<div class="form-row" style="font-family=cambria; font-size: 3rem; color: #191970">--%>
                                <div class="form-group col-md-12" style="font-family=cambria; font-size: 3rem; color: #191970;">
                                    <b>
                                            <asp:Label ID="lblRemainToken" runat="server">Remain Token No. :-</asp:Label></b><br>
                                </div>

                            <div class="form-row" style="font-family=cambria; font-size: 3rem; color: #191970">
                                <div class="form-group col-md-12">
                                    <strong>
                                    <asp:Label ID="lblQueueNo" runat="server"> Token No :-  </asp:Label><br>
                                    </strong>
                                </div>
                            </div>

                            <div class="form-row" style="font-family=cambria; font-size: 3rem; color: #191970">
                                <div class="form-group col-md-12">
                                    <strong>
                                    <asp:Label ID="lblAppoTime" runat="server"> Your Appo. Time :-  </asp:Label></strong><br>
                                </div>
                            </div>

                            <div class="form-row" style="font-family=cambria; font-size: 3rem; color: #191970">
                                <div class="form-group col-md-12">
                                    <strong>
                                    <asp:Label ID="lblAprroxTime" runat="server"> Your Approx Time :-  </asp:Label></strong><br>
                                </div>
                            </div>
                        </form>

                        <%--                        <asp:Label class="control-label" ID="lblPatientName" runat="server"> Name :-  </asp:Label><br>
                        <asp:Label class="control-label" ID="lblQueueNo" runat="server"> Token No. :-  </asp:Label><br>
                        <asp:Label class="control-label" ID="lblCurrentQueue" runat="server"> Current Token No. :-  </asp:Label><br>
                        <asp:Label class="control-label" ID="lblAppoTime" runat="server"> Your Appo. Time :-  </asp:Label><br>
                        <asp:Label class="control-label" ID="lblAprroxTime" runat="server"> Your Approx Time :-  </asp:Label><br>--%>

                        <asp:TextBox ID="txtCurrentQueue" runat="server" BorderStyle="None" Enabled="False" ReadOnly="True" Visible="False"></asp:TextBox>

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                    </div>
                </div>
            </div>
        </div>

        <asp:Timer ID="Timer1" runat="server" Interval="30000" OnTick="Timer1_Tick">
        </asp:Timer>
    </form>
</body>
</html>
