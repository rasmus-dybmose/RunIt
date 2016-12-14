<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Event.aspx.cs" Inherits="Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>

        <div class="small-12 large-10 callout">
            <asp:Literal ID="litOutput" runat="server" />
            <div class="row">

                <div class="small-6"></div>
                <div class="small-6 columns">
                    <asp:Panel ID="pnl1" CssClass="rest" DefaultButton="btnSend" runat="server">

                        <asp:Label Text="Tilmeld dig her!" AssociatedControlID="txtEmail2" runat="server" />
                        <ul class="menu">
                            <li>
                                <asp:TextBox ID="txtEmail2" ValidationGroup="rfv2" placeholder="Tilmeldelse Email" runat="server" />

                            </li>
                            <li>
                                <asp:Button ID="btnSend" ValidationGroup="rfv2" OnClick="btnSend_Click" CssClass="button kontaktbtn" Text="Tilmeld" runat="server" />
                                <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="rfv" ShowSummary="false" ShowMessageBox="true" runat="server" />
                            </li>
                        </ul>
                        <asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1"
                            ValidationGroup="rfv2"
                            runat="server"
                            ControlToValidate="txtEmail2"
                            CssClass="form-error"
                            Display="Dynamic"
                            ErrorMessage="Intasted din email!">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator
                            ID="RegularExpressionValidator1"
                            ValidationGroup="rfv2"
                            runat="server"
                            ControlToValidate="txtEmail2"
                            CssClass="form-error"
                            Display="Dynamic"
                            ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                            ErrorMessage="Den intasted e-mail er ugyldig!">
                        </asp:RegularExpressionValidator>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

