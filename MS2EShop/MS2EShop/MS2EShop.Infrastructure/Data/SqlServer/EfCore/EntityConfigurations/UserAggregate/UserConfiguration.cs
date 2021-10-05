using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MS2EShop.Domain.Entities.UserAggregate;
using System;

namespace MS2EShop.Infrastructure.Data.SqlServer.EfCore.EntityConfigurations.UserAggregate
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        //public const string DEFAULT_SCHEMA = "User";

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder.OwnsOne(p => p.Address);
            builder.OwnsOne(x => x.Address).Property(x => x.CityId).HasColumnName("CityId");
            builder.OwnsOne(x => x.Address).Property(x => x.Description).HasColumnName("Description");
            builder.OwnsOne(x => x.Address).Property(x => x.Lat).HasColumnName("Lat");
            builder.OwnsOne(x => x.Address).Property(x => x.Long).HasColumnName("City");
            builder.OwnsOne(x => x.Address).Property(x => x.Location).HasColumnName("Location").HasColumnType("geometry");

            //builder.Property(o => o.Id)
            //   .UseHiLo("userseq", DEFAULT_SCHEMA);

            //builder.OwnsOne(c => c.Address , l =>
            //{
            //    l.Property<Guid>("UserId").UseHiLo("userseq", DEFAULT_SCHEMA);

            //    l.Property(a => a.CityId).HasColumnName("CityId");
            //    l.Property(a => a.Description).HasColumnName("Description");
            //    l.Property(a => a.Lat).HasColumnName("Lat");
            //    l.Property(a => a.Long).HasColumnName("Long");
            //    l.Property(a => a.Location).HasColumnName("Location");
            //    l.WithOwner();
            //});
        }
    }
}
