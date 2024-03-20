using System.ComponentModel;

namespace HD_Support_API.Enums
{
    public enum StatusConversa
    {
        [Description("Ativo")]
        Ativo = 1,
        [Description("Encerrado")]
        Encerrado = 2,
        [Description("Em espera")]
        EmEspera = 3,
    }
}
