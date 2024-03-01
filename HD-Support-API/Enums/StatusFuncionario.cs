using System.ComponentModel;

namespace HD_Support_API.Enums
{
    public enum StatusFuncionario
    {
        [Description("Presencial")]
        Disponivel = 1,
        [Description("Home-Office")]
        Emprestado = 2,
        [Description("Hibrido")]
        Danificado = 3,
    }
}
