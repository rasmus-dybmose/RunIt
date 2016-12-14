<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="small-12 large-6 callout">
        <asp:Panel ID="pnl1" DefaultButton="btnLogin" runat="server">

            <h4>Kun for RUN'IT personale!</h4>
            <table>
                <tr>
                    <td>
                        <asp:Label Text="Brugernavn" AssociatedControlID="txtUser" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtUser" ValidationGroup="Validator2" Placeholder="Brugernavn" runat="server" />
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1"
                            ValidationGroup="Validator2"
                            ControlToValidate="txtUser"
                            Display="Dynamic"
                            runat="server"
                            ForeColor="Red"
                            ErrorMessage="Skriv dit brugernavn!" Font-Size="Small">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Password" AssociatedControlID="txtPassword" runat="server" /></td>
                    <td>
                        <asp:TextBox ID="txtPassword" ValidationGroup="Validator2" Placeholder="Password" TextMode="Password" runat="server" />
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator2"
                            ValidationGroup="Validator2"
                            ControlToValidate="txtPassword"
                            Display="Dynamic"
                            runat="server"
                            ForeColor="Red"
                            ErrorMessage="Skriv dit password!" Font-Size="Small">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnLogin" ValidationGroup="Validator2" CssClass="button" Text="Log ind" OnClick="btnLogin_Click" runat="server" />
                        <asp:ValidationSummary
                            ID="ValidationSummary1"
                            ValidationGroup="Validator2"
                            ShowSummary="false"
                            ShowMessageBox="true"
                            runat="server" />
                    </td>
                    <td>
                        <asp:Literal ID="litError" runat="server" />
                    </td>
                </tr>
            </table>
            <asp:HyperLink NavigateUrl="/PasswordReset" Text="Kan du ikke huske dit password?" runat="server" />
        </asp:Panel>
    </div>

</asp:Content>

