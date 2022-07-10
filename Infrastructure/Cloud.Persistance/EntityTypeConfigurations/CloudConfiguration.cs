using Cloud.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;



namespace Cloud.Persistance.EntityTypeConfigurations
{
    public class CloudConfiguration : IEntityTypeConfiguration<CloudEntity>
    {
        public void Configure(EntityTypeBuilder<CloudEntity> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Title).HasMaxLength(250);
        }
    }
}
