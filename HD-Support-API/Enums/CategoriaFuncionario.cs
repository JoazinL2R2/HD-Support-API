using System.ComponentModel;

namespace HD_Support_API.Enums
{
    public enum CategoriaFuncionario
    {
        [Description("Aprendiz")]
        Disponivel = 1,
        [Description("Estagiario")]
        Emprestado = 2,
        [Description("CLT")]
        Danificado = 3,
        [Description("CNPJ")]
        EmConcerto = 4,
    }
}
