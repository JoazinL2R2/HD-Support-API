namespace HD_Support_API.Models
{
    public class Emprestimos
    {
        public int Id { get; set; }

        // Relacionamento com Funcionarios
        public Funcionarios Funcionario { get; set; }
        public int FuncionariosId { get; set; }

        // Relacionamento com Equipamentos
        public Equipamentos Equipamento { get; set; }
        public int EquipamentosId { get; set; }

        public string? profissional_HD { get; set; }
    }
}
