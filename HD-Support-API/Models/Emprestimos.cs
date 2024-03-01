namespace HD_Support_API.Models
{
    public class Emprestimos
    {
        public int Id { get; set; }
        public Funcionarios Funcionario { get; set; }
        public int FuncionarioId { get; set; }
        public Equipamentos Equipamento { get; set; }
        public int EquipamentoId { get; set; }
        public string? profissional_HD { get; set; }
    }
}
