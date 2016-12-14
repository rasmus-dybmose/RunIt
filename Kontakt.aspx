<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Kontakt.aspx.cs" Inherits="Kontakt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="pnlKontakt" DefaultButton="btnSend" runat="server">

        <div class="callout small-12 large-9 columns">
            <div class="row">

                <div class="small-12 large-4 columns">

                    <h2>Kontakt</h2>
                    <p>
                        Vi bestræber os for at give svar tilbage inden for 48 timer
                    </p>
                    <ul class="menu vertical">
                        <li>
                            <asp:Label Text="Dit Navn" AssociatedControlID="txtNavn" runat="server" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator1"
                                ValidationGroup="rfv"
                                ControlToValidate="txtNavn"
                                Display="Dynamic"
                                runat="server"
                                CssClass="form-error"
                                ErrorMessage="Du skal intaste dit navn!">
                            </asp:RequiredFieldValidator></li>
                        <li>
                            <asp:TextBox ID="txtNavn" ValidationGroup="rfv" placeholder="Navn" runat="server" />

                        </li>
                        <li>
                            <asp:Label Text="Din Email" AssociatedControlID="txtEmail" runat="server" />
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
                            </asp:RegularExpressionValidator></li>
                        <li>
                            <asp:TextBox ID="txtEmail" placeholder="Email" ValidationGroup="rfv" runat="server" /></li>
                        <li>
                            <asp:Label Text="Emne (fx. løbs navn eller lign)" AssociatedControlID="txtEmne" runat="server" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator3"
                                ValidationGroup="rfv"
                                ControlToValidate="txtEmne"
                                Display="Dynamic"
                                CssClass="form-error"
                                runat="server"
                                ErrorMessage="Du skal intaste dit emne!">
                            </asp:RequiredFieldValidator></li>
                        <li>
                            <asp:TextBox ID="txtEmne" placeholder="Emne" ValidationGroup="rfv" runat="server" /></li>
                        <li>
                            <asp:Label Text="Besked" AssociatedControlID="txtMsg" runat="server" /><asp:RequiredFieldValidator
                                ID="RequiredFieldValidator4"
                                ValidationGroup="rfv"
                                ControlToValidate="txtMsg"
                                Display="Dynamic"
                                CssClass="form-error"
                                runat="server"
                                ErrorMessage="Du skal intaste din besked!">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator
                                ID="RegularExpressionValidator2"
                                ValidationGroup="rfv"
                                ControlToValidate="txtMsg"
                                Display="Dynamic"
                                CssClass="form-error"
                                runat="server"
                                ValidationExpression="^[\s\S]{8,}$"
                                ErrorMessage="Din besked skal ha et min. på 8 charakter!">
                            </asp:RegularExpressionValidator></li>
                        <li>
                            <asp:TextBox ID="txtMsg" placeholder="Besked" ValidationGroup="rfv" TextMode="MultiLine" runat="server" />

                        </li>
                        <li>
                            <asp:Button ID="btnSend" Text="Send" OnClick="btnSend_Click" CssClass="button kontaktbtn" ValidationGroup="rfv" runat="server" />
                            <asp:ValidationSummary ID="ValidationSummary1" ValidationGroup="rfv" ShowSummary="false" ShowMessageBox="true" runat="server" />
                            <asp:Literal ID="litSendt" runat="server" />
                        </li>
                    </ul>
                </div>
                <div class="small-12 large-8 columns">
                    <h5>Her finder du information om vores bestyrelse</h5>
                    <asp:DropDownList ID="ddl" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_SelectedIndexChanged">
                        <asp:ListItem Text="- Vælg noget -" disabled="disabled" />
                    </asp:DropDownList>
                    <div>
                        <asp:Literal ID="litOutput" runat="server" />
                    </div>
                </div>
            </div>

        </div>
    </asp:Panel>
</asp:Content>

