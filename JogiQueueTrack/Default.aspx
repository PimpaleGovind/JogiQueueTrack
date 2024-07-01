<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JogiQueueTrack._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container col-md-12">
        <div class="row">
            <div class="col-md-12">
                <div class="jumbotron bg-primary">
                    <h1>
                        JOGI Multispeciality Hospital</h1>
                    <p class="lead">Track Your Queue</p>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="table-responsive">

                    <%--   <asp:GridView ID="gvQueueList" runat="server" BorderColor="Black" BorderStyle="Solid" OnSelectedIndexChanged="gvQueueList_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover" Width="100%">
                </asp:GridView>--%>

                    <asp:GridView ID="gvQueueList" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered table-condensed">
                        <%--    <Columns>
                                <asp:TemplateField HeaderText="Files">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>--%>
                        <Columns>
                            <asp:BoundField HeaderText="Queue No." DataField="QueueNo"/>
                            <asp:BoundField HeaderText="Appo.Date" DataField="AppointmentDate"/>
                            <asp:BoundField Visible="false" DataField="AFrom" />
                            <asp:BoundField Visible="false" DataField="ATo"/>
                            <asp:BoundField Visible="false" DataField="LedgerName"/>
                            <asp:BoundField HeaderText="Doctor Name" DataField="DocName"/>
                            <asp:BoundField Visible="false" DataField="Status"/>
                            <asp:BoundField HeaderText="ApproxTime" DataField="ApproxTime"/>
                        </Columns>

                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
