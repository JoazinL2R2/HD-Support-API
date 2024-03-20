using System.ComponentModel;

namespace HD_Support_API.Enums
{
    public enum StatusHelpDesk
    {
        [Description("Disponível")]
        Disponivel = 1,
        [Description("Ocupado")]
        Ocupado = 2,
        [Description("Indisponível")]
        Indisponível = 3,
    }
}
