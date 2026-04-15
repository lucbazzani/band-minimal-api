namespace Band.Routes;

public static class BandRoute
{
    // key word "this" as a parameter means it is an extension method
    public static void BandRoutes(this WebApplication app)
    {
        app.MapGet("band", () => "Olá, Banda!");
    }
}

