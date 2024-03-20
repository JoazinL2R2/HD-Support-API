using System.ComponentModel;

namespace HD_Support_API.Enums
{
    public enum TipoConversa
    {
        [Description("Conversa")]
        Conversa = 1,
        [Description("HelpDesk")]
        HelpDesk = 2,
        [Description("Atendimento")]
        Atendimento = 3,
    }
}
