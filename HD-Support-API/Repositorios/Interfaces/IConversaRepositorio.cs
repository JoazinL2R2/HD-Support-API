using HD_Support_API.Models;

namespace HD_Support_API.Repositorios.Interfaces
{
    public interface IConversaRepositorio
    {
        Task<List<Mensagens>> ListarMensagens(int idConversa);
        Task<Conversa> EnviarMensagem(int idConversa, Mensagens Mensagem);
        Task<Conversa> IniciarConversa(Conversa conversa);
        Task<bool> TerminarConversa(int id);
        Task<bool> ExcluirMensagem(int id);
        Task<Conversa> BuscarConversaPorId(int id);
        Task<int> VerificarMensagemNova(int idConversa);
    }
}
