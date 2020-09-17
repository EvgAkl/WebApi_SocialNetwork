using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SocialNetwork_2.Database.DbEntities;

namespace SocialNetwork_2.Database.EntityConfigurations
{
    public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Text).HasMaxLength(300).IsUnicode().IsRequired();
        }
    }
}
