using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace HD_Support_API.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimos>
    {
        public void Configure(EntityTypeBuilder<Emprestimos> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Funcionario).IsRequired();
            builder.Property(x => x.FuncionarioId).IsRequired();
            builder.Property(x => x.Equipamento).IsRequired();
            builder.Property(x => x.EquipamentoId).IsRequired();
            builder.Property(x => x.profissional_HD).IsRequired();
        }
    }
}
