<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Events.aspx.cs" Inherits="Events" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>

        <div class="small-10 callout columns">
            <div class="row">
                <div class="large-2 columns">
                    <h4>Indkreds</h4>

                    <b>Distance</b>
                    <asp:RadioButtonList ID="rbl" OnSelectedIndexChanged="rbl_SelectedIndexChanged" runat="server">
                        <asp:ListItem Text="Over 10KM" Value="10" />
                        <asp:ListItem Text="Under 10KM" Value="9" />
                    </asp:RadioButtonList>
                    <b>Hvor i landet</b>
                    <asp:DropDownList ID="ddl" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged" runat="server">
                        <asp:ListItem Text="- Vælg noget -" disabled="disabled" />
                    </asp:DropDownList>
                </div>
                <div class="small-12 large-10 columns">
                    <h3>Alle Events</h3>
                    <div class="row">
                        <asp:PlaceHolder ID="plh1" runat="server" />
                        <asp:Literal ID="litOutput" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

