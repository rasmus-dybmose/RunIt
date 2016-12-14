<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Soeg.aspx.cs" Inherits="Soeg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>
        <div class="small-12 large-10 callout">
            <div class="row">
                <div class="small-12 large-3 columns">
                    <h2>Advanceret søg</h2>
                    <ul class="menu vertical">
                        <li>
                            <asp:Label Text="Løbs Navn" runat="server" /></li>
                        <li>
                            <asp:TextBox ID="txtNavn" runat="server" /></li>
                        <li>
                            <h4>Til og fra pris</h4>
                        </li>
                        <li>
                            <asp:Label Text="Pris fra" runat="server" /></li>
                        <li>
                            <asp:TextBox ID="txtPrisDown" runat="server" /></li>
                        <li>
                            <asp:Label Text="Pris til" runat="server" /></li>
                        <li>
                            <asp:TextBox ID="txtPrisUP" runat="server" /></li>
                        <li>
                            <h4>Distance</h4>
                        </li>
                        <li>
                            <asp:RadioButtonList ID="rbl" OnSelectedIndexChanged="rbl_SelectedIndexChanged" runat="server">
                                <asp:ListItem Text="Over 10KM" Value="10" />
                                <asp:ListItem Text="Under 10KM" Value="9" />
                            </asp:RadioButtonList></li>
                        <li>
                            <h4>Hvor i landet</h4>
                        </li>
                        <li>
                            <asp:DropDownList ID="ddl" OnSelectedIndexChanged="ddl_SelectedIndexChanged" runat="server">
                                <asp:ListItem Text="- Vælg noget -" Value="" disabled="disabled" />
                            </asp:DropDownList>
                        <li>
                            <asp:Button ID="btnSog" Text="SØG" CssClass="button kontaktbtn" OnClick="btnSog_Click" runat="server" /></li>
                    </ul>
                </div>
                <div class="small-12 large-9 columns">

                    <asp:Literal ID="litSog" runat="server" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>

