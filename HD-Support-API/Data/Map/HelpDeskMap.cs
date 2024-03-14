using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HD_Support_API.Data.Map
{
    public class HelpDeskMap : IEntityTypeConfiguration<HelpDesk>
    {
        public void Configure(EntityTypeBuilder<HelpDesk> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Senha).IsRequired().HasMaxLength(255);
        }
    }
}
