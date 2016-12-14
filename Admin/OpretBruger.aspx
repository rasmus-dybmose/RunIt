<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="OpretBruger.aspx.cs" Inherits="Admin_OpretBruger" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="columns">
        <div class="row">
            <div class="columns small-3">
                <h1>Opret bruger</h1>
                <br />
                <asp:Literal ID="litContent" runat="server" />
                <asp:Panel ID="pnl1" DefaultButton="btnGem" CssClass="formular" runat="server">

                    <asp:Label Text="Brugernavn" AssociatedControlID="txtlogin" runat="server" />
                    <asp:TextBox ID="txtLogin" runat="server" />
                    <asp:Label Text="Email" AssociatedControlID="txtEmail" runat="server" />
                    <asp:TextBox ID="txtEmail" TextMode="Email" runat="server" />
                    <asp:Label Text="Password" AssociatedControlID="txtPassword" runat="server" />
                    <asp:TextBox ID="txtPassword" runat="server" />
                    <asp:Button ID="btnGem" Text="Gem" CssClass="button" OnClick="btnGem_Click" runat="server" />

                </asp:Panel>
            </div>
        </div>
    </div>

</asp:Content>

