using HD_Support_API.Enums;

namespace HD_Support_API.Models
{
    public class HelpDesk
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public StatusHelpDesk? Status { get; set; }
        public StatusHelpDeskConversa? StatusConversa { get; set; }
    }
}
