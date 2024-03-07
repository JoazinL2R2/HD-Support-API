using HD_Support_API.Enums;

namespace HD_Support_API.Models
{
    public class Funcionarios
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telegram { get; set; }
        public string Telefone { get; set; }
        public StatusFuncionario StatusFuncionario { get; set; }
        public CategoriaFuncionario Categoria { get; set; }
        public string? profissional_HD { get; set; }
    }
}
