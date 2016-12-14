<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Reset.aspx.cs" Inherits="Admin_Reset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <%--<meta http-equiv="refresh" content="3;url=/" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="columns large-6 callout">
        <asp:Panel ID="pnl2" runat="server">

            <h3>Reset password</h3>
            <asp:Literal ID="litOutput" runat="server" />
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword" Text="Password" AssociatedControlID="txtPassword" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtPassword" TextMode="Password" ValidationGroup="rfv" runat="server" />
                        <asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator1" 
                            runat="server" 
                            ValidationGroup="rfv" 
                            CssClass="form-error" 
                            Display="Dynamic" 
                            ControlToValidate="txtPassword" 
                            ErrorMessage="Skriv Nyt Password">
                        </asp:RequiredFieldValidator>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPassword2" Text="Gentag Password" AssociatedControlID="txtPassword2" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtPassword2" TextMode="Password" ValidationGroup="rfv" runat="server" />
                        <asp:RequiredFieldValidator 
                            ID="RequiredFieldValidator2" 
                            runat="server" 
                            ValidationGroup="rfv" 
                            CssClass="form-error" 
                            Display="Dynamic" 
                            ControlToValidate="txtPassword2" 
                            ErrorMessage="Gentag Password">
                        </asp:RequiredFieldValidator>
                        <br />
                        <asp:CompareValidator 
                            ID="NewPasswordCompare" 
                            runat="server" 
                            ControlToCompare="txtPassword" 
                            Display="Dynamic"
                            ControlToValidate="txtPassword2" 
                            ErrorMessage="*Confirm Password must match with the Password." 
                            CssClass="form-error"
                            ValidationGroup="rfv">
                        </asp:CompareValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnSend" CssClass="button" OnClick="btnSend_Click" ValidationGroup="rfv" Text="Send" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="rfv" ShowSummary="false" ShowMessageBox="true" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:Literal ID="litError2" runat="server" />


        </asp:Panel>
    </div>

</asp:Content>

