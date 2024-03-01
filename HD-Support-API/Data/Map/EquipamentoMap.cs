using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HD_Support_API.Data.Map
{
    public class EquipamentoMap : IEntityTypeConfiguration<Equipamentos>
    {
        public void Configure(EntityTypeBuilder<Equipamentos> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdPatrimonio).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Modelo).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Processador).IsRequired().HasMaxLength(255);
            builder.Property(x => x.SistemaOperacional).IsRequired().HasMaxLength(255);
            builder.Property(x => x.HeadSet).HasMaxLength(255);
            builder.Property(x => x.DtEmeprestimoInicio).IsRequired();
            builder.Property(x => x.DtEmeprestimoFinal).IsRequired();
            builder.Property(x => x.statusEquipamento).IsRequired();
            builder.Property(x => x.profissional_HD).IsRequired();
        }
    }
}
