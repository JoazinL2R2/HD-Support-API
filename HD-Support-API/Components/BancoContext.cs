using HD_Support_API.Models;
using Microsoft.EntityFrameworkCore;

namespace HD_Support_API.Components

{
    public class BancoContext:DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options){ }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
