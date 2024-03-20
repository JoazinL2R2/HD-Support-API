using HD_Support_API.Data.Map;
using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HD_Support_API.Components

{
    public class BancoContext:DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){ }
        public DbSet<Funcionarios> Funcionario { get; set; }
        public DbSet<Equipamentos> Equipamento { get; set; }
        public DbSet<Emprestimos> Emprestimo { get; set; }
        public DbSet<HelpDesk> HelpDesk { get; set; }
        public DbSet<Conversa> Conversa { get; set; }
        public DbSet<Mensagens> Mensagens { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmprestimoMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new EquipamentoMap());
            modelBuilder.ApplyConfiguration(new HelpDeskMap());
            modelBuilder.ApplyConfiguration(new ConversaMap());
            modelBuilder.ApplyConfiguration(new MensagensMap());
            base.OnModelCreating(modelBuilder);
        }

    }
}
