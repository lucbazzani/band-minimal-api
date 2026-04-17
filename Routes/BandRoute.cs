using Band.Data;
using Band.Models;
using Microsoft.EntityFrameworkCore;

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
            
            route.MapGet("", async (BandContext context) =>
                {
                    var bands = await context.Bands.ToListAsync();
                    return Results.Ok(bands);
                });

            route.MapPut("{id:guid}", 
                async (Guid id, BandRequest req, BandContext context) =>
                {
                    // FirstOrDefault returns the first element of a sequence,
                    // or a default value if no element is found without throwing an Exception.
                    var band = await context.Bands.FirstOrDefaultAsync(x => x.Id == id);

                    if (band == null || !band.IsActive)
                    {
                        return Results.NotFound();
                    }

                    band.UpdateName(req.name);
                    await context.SaveChangesAsync();

                    return Results.Ok(band);
                });

            route.MapDelete("{id:guid}",
                async (Guid id, BandContext context) =>
                {
                    var band = await context.Bands.FirstOrDefaultAsync(x => x.Id == id);

                    if (band == null || !band.IsActive)
                    {
                        return Results.NotFound();
                    }
                    
                    band.SetInactive();
                    await context.SaveChangesAsync();

                    return Results.Ok(band);
                                        
                });
        }
    }
}
