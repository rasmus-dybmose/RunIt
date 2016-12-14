<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="unsubscribe-email.aspx.cs" Inherits="unsubscribe_email" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="small-12 large-10 callout">
        <h4>Hvis du ikke har lyst til at modtage flere nyhedsbreve så skal du trykke på knappen her under.</h4>
                <asp:Button ID="btnSend" CssClass="button alert" Text="unsubscribe" OnClick="btnSend_Click" runat="server" />
    </div>

</asp:Content>

