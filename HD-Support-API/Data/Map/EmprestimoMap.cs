using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HD_Support_API.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimos>
    {
        public void Configure(EntityTypeBuilder<Emprestimos> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Funcionario)
                   .WithMany()
                   .HasForeignKey(x => x.FuncionariosId)
                   .IsRequired();

            builder.HasOne(x => x.Equipamento)
                   .WithMany()
                   .HasForeignKey(x => x.EquipamentosId)
                   .IsRequired();

            builder.Property(x => x.profissional_HD)
                   .IsRequired();
        }
    }
}
