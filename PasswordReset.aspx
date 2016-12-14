<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PasswordReset.aspx.cs" Inherits="PasswordReset" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="columns callout large-8">
        <asp:Panel ID="pnl1" runat="server">

            <h3>intast din email her for at resette dit password</h3>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" Text="Email" AssociatedControlID="txtEmail" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtEmail" ValidationGroup="rfv" TextMode="Email" runat="server" />
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            ValidationGroup="rfv"
                            runat="server"
                            ControlToValidate="txtEmail"
                            CssClass="form-error"
                            Display="Dynamic"
                            ErrorMessage="Den intasted din email!">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1"
                            ValidationGroup="rfv"
                            runat="server"
                            ControlToValidate="txtEmail"
                            CssClass="form-error"
                            Display="Dynamic"
                            ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                            ErrorMessage="Den intasted e-mail er ugyldig!">
                        </asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Button ID="btnSend" CssClass="button" ValidationGroup="rfv" OnClick="btnSend_Click" Text="Send" runat="server" />
                        <asp:ValidationSummary 
                            ID="ValidationSummary1" 
                            ValidationGroup="rfv" 
                            ShowSummary="false" 
                            ShowMessageBox="true" 
                            runat="server" />
                    </td>
                </tr>
            </table>
            <asp:Literal ID="litError" runat="server" />
        </asp:Panel>
    </div>
</asp:Content>

