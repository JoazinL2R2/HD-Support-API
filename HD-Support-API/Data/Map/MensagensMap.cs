using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HD_Support_API.Data.Map
{
    public class MensagensMap : IEntityTypeConfiguration<Mensagens>
    {
        public void Configure(EntityTypeBuilder<Mensagens> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Mensagem).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ConversaId).IsRequired();
            builder.HasOne(x => x.Usuario)
               .WithMany()
               .HasForeignKey(x => x.UsuarioId)
               .IsRequired();
            builder.Property(x => x.Data_envio).IsRequired();
        }
    }
}
