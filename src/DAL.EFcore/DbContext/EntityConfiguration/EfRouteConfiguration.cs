using DAL.EFcore.Entyties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.EFcore.DbContext.EntityConfiguration
{
    public class EfRouteConfiguration : IEntityTypeConfiguration<EfRoute>
    {
        public void Configure(EntityTypeBuilder<EfRoute> builder)
        {
            //EfRoute < --> EfStations One2Many-----------------------------------------------
            builder
                .HasMany(s => s.Stations)
                .WithOne(s => s.EfRoute)
                .HasForeignKey(s => s.EfRouteId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}