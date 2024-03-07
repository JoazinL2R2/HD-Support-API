using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HD_Support_API.Data.Map
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionarios>
    {
        public void Configure(EntityTypeBuilder<Funcionarios> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Telegram).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(255);
            builder.Property(x => x.StatusFuncionario).IsRequired();
            builder.Property(x => x.Categoria).IsRequired();
            builder.Property(x => x.profissional_HD).IsRequired();
        }
    }
}
