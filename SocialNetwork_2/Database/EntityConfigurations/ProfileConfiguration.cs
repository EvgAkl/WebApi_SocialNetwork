using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork_2.Database.DbEntities;

namespace SocialNetwork_2.Database.EntityConfigurations
{
    public sealed class ProfileConfiguration : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.FirstName).HasColumnName("First name").HasMaxLength(20).IsUnicode().IsRequired();
            builder.Property(P => P.LastName).HasColumnName("Last name").HasMaxLength(20).IsUnicode().IsRequired();
            builder.Property(p => p.City).HasMaxLength(20).IsUnicode().IsRequired();
        }
    }
}
