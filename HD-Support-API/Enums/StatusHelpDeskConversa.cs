using System.ComponentModel;

namespace HD_Support_API.Enums
{
    public enum StatusHelpDeskConversa
    {
        [Description("Online")]
        Online = 1,
        [Description("Offline")]
        offline = 2,
        [Description("Não Perturbar")]
        NaoPerturbar = 3,
        [Description("Digitando")]
        Digitando = 4,
    }
}
