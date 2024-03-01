using System.ComponentModel;

namespace HD_Support_API.Enums
{
    public enum StatusEquipamento
    {
        [Description("Equipamento Disponivel")]
        Disponivel = 1,
        [Description("Equipamento em emprestimo")]
        Emprestado = 2,
        [Description("Equipamento danificado")]
        Danificado = 3,
        [Description("Equipamento em concerto")]
        EmConcerto = 4,
    }
}
