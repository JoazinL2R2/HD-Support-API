using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HD_Support_API.Data.Map
{
    public class ConversaMap : IEntityTypeConfiguration<Conversa>
    {
        public void Configure(EntityTypeBuilder<Conversa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Funcionario)
                   .WithMany()
                   .HasForeignKey(x => x.FuncionariosId)
                   .IsRequired();

            builder.HasOne(x => x.Cliente)
                   .WithMany()
                   .HasForeignKey(x => x.ClienteId)
                   .IsRequired();
            builder.Property(x => x.Criptografia).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Data_inicio).IsRequired();
            builder.Property(x => x.Data_conclusao);
        }
    }
}
