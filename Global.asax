<%@ Application Language="C#" %>

<%@ Import Namespace="System.Web.Routing" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);
    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.MapPageRoute("events", "events", "~/Events.aspx");
        routes.MapPageRoute("event", "event", "~/Event.aspx");
        routes.MapPageRoute("Soeg", "Soeg", "~/Soeg.aspx");
        routes.MapPageRoute("sponsore", "sponsore", "~/sponsore.aspx");
        routes.MapPageRoute("omrunit", "omrunit", "~/omrunit.aspx");
        routes.MapPageRoute("kontakt", "kontakt", "~/kontakt.aspx");
        routes.MapPageRoute("unsubscribe-email", "Unsubscribe-email", "~/unsubscribe-email.aspx");
        routes.MapPageRoute("login", "login", "~/Login.aspx");
        routes.MapPageRoute("PasswordReset", "PasswordReset", "~/PasswordReset.aspx");
        routes.MapPageRoute("Reset", "Reset", "~/Reset.aspx");

        //ADMIN SIDERNE
        routes.MapPageRoute("Admin", "Admin", "~/Admin/Default.aspx");
        routes.MapPageRoute("OpretEvent", "OpretEvent", "~/Admin/OpretEvent.aspx");
        routes.MapPageRoute("OpretSponsorer", "OpretSponsorer", "~/Admin/OpretSponsorer.aspx");
        routes.MapPageRoute("OpretOmRunIt", "OpretOmRunIt", "~/Admin/OpretOmRunIt.aspx");
        routes.MapPageRoute("OpretKontakt", "OpretKontakt", "~/Admin/OpretKontakt.aspx");
        routes.MapPageRoute("OpretBruger", "OpretBruger", "~/Admin/OpretBruger.aspx");

    }

</script>
