<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/MasterPage.master" AutoEventWireup="true" CodeFile="OpretEvent.aspx.cs" Inherits="Admin_OpretEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="large-3 columns">
        <h2>Opret Event</h2>

        <ul class="menu vertical">
            <li>
                <asp:Label ID="lblEvent" AssociatedControlID="txtEvent" Text="Event navn" runat="server" />

            </li>
            <li>
                <asp:TextBox ID="txtEvent" ValidationGroup="Validator" runat="server" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator1"
                    ValidationGroup="Validator"
                    ControlToValidate="txtEvent"
                    Display="Dynamic"
                    runat="server"
                    CssClass="form-error"
                    ErrorMessage="Indtast Event navn!">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="lblBeskrivelse" AssociatedControlID="txtBeskrivelse" Text="Beskrivelse" runat="server" />

            </li>
            <li>
                <asp:TextBox ID="txtBeskrivelse" ValidationGroup="Validator" TextMode="MultiLine" runat="server" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator6"
                    ValidationGroup="Validator"
                    ControlToValidate="txtEvent"
                    Display="Dynamic"
                    runat="server"
                    CssClass="form-error"
                    ErrorMessage="Indtast Beskrivelse!">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="lblTeaser" AssociatedControlID="txtTeaser" Text="Teaser" runat="server" />

            </li>
            <li>
                <asp:TextBox ID="txtTeaser" ValidationGroup="Validator" TextMode="MultiLine" runat="server" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator9"
                    ValidationGroup="Validator"
                    ControlToValidate="txtTeaser"
                    Display="Dynamic"
                    runat="server"
                    CssClass="form-error"
                    ErrorMessage="Indtast Teaser!">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="lblSted" AssociatedControlID="ddlRegion" Text="Region" runat="server" />

            </li>
            <li>
                <asp:DropDownList ID="ddlRegion" ValidationGroup="Validator" runat="server">
                    <asp:ListItem Text="" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator2"
                    ValidationGroup="Validator"
                    ControlToValidate="ddlRegion"
                    Display="Dynamic"
                    runat="server"
                    CssClass="form-error"
                    ErrorMessage="Vælg Region!">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="lblDistance" AssociatedControlID="txtDistance" Text="Distance" runat="server" />

            </li>
            <li>
                <asp:TextBox ID="txtDistance" ValidationGroup="Validator" runat="server" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator7"
                    ValidationGroup="Validator"
                    ControlToValidate="txtDistance"
                    Display="Dynamic"
                    runat="server"
                    CssClass="form-error"
                    ErrorMessage="Indtast Distance!">
                </asp:RequiredFieldValidator>
            </li>
            <li>
                <asp:Label ID="lblPladser" AssociatedControlID="txtPladser" Text="Pladser" runat="server" />

            </li>
            <li>
                <asp:TextBox ID="txtPladser" ValidationGroup="Validator" placeholder="Pladser" Width="100px" runat="server" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator8"
                    ValidationGroup="Validator"
                    ControlToValidate="txtPladser"
                    Display="Dynamic"
                    runat="server"
                    CssClass="form-error"
                    ErrorMessage="Indtast en pladser!">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator1"
                    ErrorMessage="Kun tal"
                    ControlToValidate="txtPladser"
                    runat="server"
                    CssClass="form-error"
                    ValidationGroup="Validator"
                    ValidationExpression="^[0-9]+$" />

            </li>
            <li>
                <asp:Label ID="lblPris" AssociatedControlID="txtPris" Text="Pris" runat="server" />

            </li>
            <li>
                <asp:TextBox ID="txtPris" ValidationGroup="Validator" placeholder="Kr" Width="100px" runat="server" />
                <asp:RequiredFieldValidator
                    ID="RequiredFieldValidator5"
                    ValidationGroup="Validator"
                    ControlToValidate="txtPris"
                    Display="Dynamic"
                    runat="server"
                    CssClass="form-error"
                    ErrorMessage="Indtast en pris!">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    ID="RegularExpressionValidator4"
                    ErrorMessage="Kun tal"
                    ControlToValidate="txtPris"
                    runat="server"
                    CssClass="form-error"
                    ValidationGroup="Validator"
                    ValidationExpression="^[0-9]+$" />

            </li>
            <li>
                <asp:Label ID="lblDato" Text="Event dato" AssociatedControlID="cal1" runat="server" />

            </li>
            <li>
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:Calendar 
                            ID="cal1" 
                            OnDayRender="cal1_DayRender" 
                            OnSelectionChanged="cal1_SelectionChanged" 
                            runat="server" BackColor="White" 
                            BorderColor="Black" 
                            DayNameFormat="Shortest" 
                            Font-Names="Verdana" 
                            Font-Size="10pt" 
                            ForeColor="Black" 
                            Height="220px" 
                            Width="100%" 
                            NextPrevFormat="FullMonth" 
                            TitleFormat="Month">
                            <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                            <DayStyle Width="14%" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="black" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="tomato" ForeColor="White" />
                            <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                            <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="black" Height="14pt" />
                            <TodayDayStyle BackColor="Lightblue" />
                            <WeekendDayStyle BackColor="#FFFFCC" />
                        </asp:Calendar>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </li>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlTid" Visible="true" runat="server">
                        <li>
                            <ul class="menu">
                                <li>
                                    <asp:Label ID="lblTid" Text="Kl." AssociatedControlID="ddlTid" runat="server" />
                                </li>
                                <li>
                                    <asp:DropDownList ID="ddlTid" AutoPostBack="true" CssClass="align" OnSelectedIndexChanged="ddlTid_SelectedIndexChanged" ValidationGroup="Validator" runat="server">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator4"
                                        ValidationGroup="Validator"
                                        ControlToValidate="ddlTid"
                                        Display="Dynamic"
                                        runat="server"
                                        CssClass="form-error"
                                        ErrorMessage="Vælg en klokkeslæt!">
                                    </asp:RequiredFieldValidator>
                                </li>
                                <li>
                                    <asp:Label Text="Dato Resultat:" runat="server" /></li>
                                <li>
                                    <asp:TextBox ID="txtDato" ValidationGroup="Validator" disabled="true" Width="150px" runat="server" />
                                    <asp:RequiredFieldValidator
                                        ID="RequiredFieldValidator3"
                                        ValidationGroup="Validator"
                                        ControlToValidate="txtDato"
                                        Display="Dynamic"
                                        runat="server"
                                        CssClass="form-error"
                                        ErrorMessage="Vælg en dato!">
                                    </asp:RequiredFieldValidator>

                                </li>
                            </ul>
                        </li>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <li>
                <br />
                <asp:FileUpload ID="fu1" CssClass="button" runat="server" />

            </li>
            <li>
                <br />
                <asp:Button ID="btnOpret" Text="Opret" CssClass="button" Font-Bold="true" ValidationGroup="Validator" Width="100%" OnClick="btnOpret_Click" runat="server" />
                <asp:ValidationSummary
                    ID="ValidationSummary1"
                    ValidationGroup="Validator"
                    ShowSummary="false"
                    ShowMessageBox="true"
                    runat="server" />
            </li>
        </ul>

    </div>

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

            <div class="small-12 large-12">
                <h4>Alle nuværende events</h4>
                <table>
                    <tr>
                        <th>Title</th>
                        <th>Beskrivelse</th>
                        <th>Region</th>
                        <th>Distance</th>
                        <th>Pris</th>
                        <th>Billede</th>
                        <th>Pladser</th>
                        <th>Dato</th>
                        <th>Teaser</th>
                    </tr>
                    <tr>
                        <asp:Literal ID="litNyEvent" runat="server" />
                    </tr>
                    <asp:Literal ID="litEvents" runat="server" />
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

