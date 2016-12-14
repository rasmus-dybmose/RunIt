<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="OpretSponsorer.aspx.cs" Inherits="Admin_OpretSponsorer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="columns">
        <div class="row">
            <div class="columns">
                <asp:Literal ID="litOutput" runat="server" />
            </div>
            <div class="columns">
                <asp:Panel ID="pnl1" CssClass="large-6" runat="server">
                    <asp:FileUpload ID="fu1" CssClass="button" runat="server" />
                    <asp:TextBox ID="txtSpn" runat="server" />
                    <asp:DropDownList ID="ddl1" AutoPostBack="true" OnSelectedIndexChanged="ddl1_SelectedIndexChanged" runat="server">
                        <asp:ListItem Text="VÆLG" disabled="disabled" />
                    </asp:DropDownList>
                </asp:Panel>
            </div>
        </div>
    </div>
    
</asp:Content>

