using EncryptionDecryptionUsingSymmetricKey;
using HD_Support_API.Components;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HD_Support_API.Repositorios
{
    public class ConversaRepositorio : IConversaRepositorio
    {
        private readonly BancoContext _contexto;
        public ConversaRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Conversa> IniciarConversa(Conversa conversa)
        {
            conversa.Criptografia = AesOperation.gerarChave(20);
            _contexto.Conversa.AddAsync(conversa);
            _contexto.SaveChangesAsync();
            return conversa;
        }
        public async Task<Conversa> EnviarMensagem(int idConversa, Mensagens mensagem)
        {
            Conversa conversa = await BuscarConversaPorId(idConversa);
            mensagem.Mensagem = AesOperation.Encriptar(conversa.Criptografia, mensagem.Mensagem);
            _contexto.Mensagens.AddAsync(mensagem);
            _contexto.SaveChangesAsync();
            return conversa;
        }

        public async Task<Conversa> BuscarConversaPorId(int Id)
        {
            return _contexto.Conversa.FirstOrDefault(x => x.Id == Id);
        }

        public async Task<bool> TerminarConversa(int id)
        {
            Conversa conversaPorId = await BuscarConversaPorId(id);

            if (conversaPorId == null)
            {
                throw new Exception($"Conversa de Id:{id} não encontrado na base de dados.");
            }
            _contexto.Remove(conversaPorId);
            await _contexto.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ExcluirMensagem(int id)
        {
            Conversa conversaPorId = await BuscarConversaPorId(id);

            if (conversaPorId == null)
            {
                throw new Exception($"Conversa de Id:{id} não encontrado na base de dados.");
            }
            _contexto.Remove(conversaPorId);
            await _contexto.SaveChangesAsync();

            return true;
        }

        public async Task<List<Mensagens>> ListarMensagens(int id)
        {
            Conversa conversaPorId = await BuscarConversaPorId(id);
            List<Mensagens> MensagensLista = await _contexto.Mensagens.Where(x => x.ConversaId == id).ToListAsync();
            for (int i = 0; i < MensagensLista.Count;i++)
            {
                MensagensLista[i].Mensagem = AesOperation.Descriptar(conversaPorId.Criptografia, MensagensLista[i].Mensagem);
            }
            return MensagensLista;
        }
    }
}
