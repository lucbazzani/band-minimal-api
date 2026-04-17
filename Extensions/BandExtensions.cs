using Band.Models;
using Microsoft.EntityFrameworkCore;

namespace Band.Extensions
{
    public static class BandExtensions
    {
        public static async Task<BandModel?> GetActiveBandAsync(this DbSet<BandModel> bands, Guid id)
        {
            var band = await bands.FirstOrDefaultAsync(x => x.Id == id);

            if (band == null || !band.IsActive)
            {
                return null;
            }

            return band;
        }
    }
}