using Band.Data;
using Band.Models;

namespace Band.Routes
{
    public static class BandRoute
    {
        // key word "this" as a parameter means it is an extension method
        public static void BandRoutes(this WebApplication app)
        {
            var route = app.MapGroup("band");

            route.MapPost("", 
                async (BandRequest req, BandContext context) =>
                {
                    var band = new BandModel(req.name);
                    await context.AddAsync(band);
                    await context.SaveChangesAsync(); // It commits the changes.
                    return Results.Created($"/band/{band.Id}", band);
                });
            //route.MapGet("", () =>);
            //route.MapDelete("", () =>);
        }
    }

}
