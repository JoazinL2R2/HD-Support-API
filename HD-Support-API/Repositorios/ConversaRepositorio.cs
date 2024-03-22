using EncryptionDecryptionUsingSymmetricKey;
using HD_Support_API.Components;
using HD_Support_API.Enums;
using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace HD_Support_API.Repositorios
{
    public class ConversaRepositorio : IConversaRepositorio
    {
        private readonly BancoContext _contexto;
        private readonly string cripto = "criptografiahdsuportcriptografia";
        public ConversaRepositorio(BancoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Conversa> IniciarConversa(Conversa conversa)
        {
            
            conversa.Criptografia = AesOperation.gerarChave(32);
            conversa.Criptografia = AesOperation.Encriptar(cripto, conversa.Criptografia);
            HelpDesk cliente = await _contexto.HelpDesk.FindAsync(conversa.ClienteId);
            conversa.Cliente = cliente;
            /*HelpDesk funcionario = await _contexto.HelpDesk.FindAsync(conversa.FuncionariosId);
            //atualizando status do funcionário
            if (conversa.TipoConversa != TipoConversa.Conversa) {
                funcionario.Status = StatusHelpDesk.Ocupado;
                _contexto.HelpDesk.Update(funcionario);
            }
            conversa.Funcionario = funcionario;*/
            conversa.TipoConversa = (TipoConversa)conversa.TipoConversa;
            if (conversa.Status != null)
            {
                conversa.Status = (StatusConversa)conversa.Status;
            }
            else
            {
                conversa.Status = StatusConversa.NaoAceito;
            }
            if (conversa.FuncionariosId == null || conversa.FuncionariosId == conversa.ClienteId)
            {
                conversa.FuncionariosId = 37;
                HelpDesk funcionario = await _contexto.HelpDesk.FindAsync(37);
                conversa.Funcionario = funcionario;
            }
            else
            {
                HelpDesk funcionario = await _contexto.HelpDesk.FindAsync(conversa.FuncionariosId);
                conversa.Funcionario = funcionario;
            }
            conversa.Data_inicio = DateTime.Now;
            await _contexto.Conversa.AddAsync(conversa);
            await _contexto.SaveChangesAsync();
            return conversa;
        }
        public async Task<Conversa> EnviarMensagem(int idConversa, Mensagens mensagem)
        {
            Conversa conversa = await BuscarConversaPorId(idConversa);
            string criptografia = AesOperation.Descriptar(cripto, conversa.Criptografia);
            mensagem.Mensagem = AesOperation.Encriptar(criptografia, mensagem.Mensagem);
            mensagem.ConversaId = idConversa;
            mensagem.Usuario = await _contexto.HelpDesk.FindAsync(mensagem.UsuarioId);
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
            conversaPorId.Status = StatusConversa.Encerrado;
            if(conversaPorId.TipoConversa != TipoConversa.Conversa)
            {
                HelpDesk funcionario = conversaPorId.Funcionario;
                funcionario.Status = StatusHelpDesk.Disponivel;
                _contexto.HelpDesk.Update(funcionario);
            }

            _contexto.Conversa.Update(conversaPorId);
            await _contexto.SaveChangesAsync();

            return true;
        }
        public async Task<bool> ExcluirMensagem(int id)
        {
            Mensagens mensagem = await _contexto.Mensagens.FindAsync(id);

            if (mensagem == null)
            {
                throw new Exception($"Mensagem de Id:{id} não encontrado na base de dados.");
            }
            _contexto.Mensagens.Remove(mensagem);
            await _contexto.SaveChangesAsync();

            return true;
        }

        public async Task<List<Mensagens>> ListarMensagens(int id)
        {
            Conversa conversaPorId = await BuscarConversaPorId(id);
            List<Mensagens> MensagensLista = await _contexto.Mensagens.Where(x => x.ConversaId == id).ToListAsync();
            string criptografia = AesOperation.Descriptar(cripto, conversaPorId.Criptografia);
            for (int i = 0; i < MensagensLista.Count;i++)
            {
                MensagensLista[i].Mensagem = AesOperation.Descriptar(criptografia, MensagensLista[i].Mensagem);
            }
            return MensagensLista;
        }

        public async Task<bool> VerificarMensagemNova(int idConversa, int qtdMensagensAtual)
        {
            int qtdMensagens = _contexto.Mensagens.Where(x => x.ConversaId == idConversa).Count();
            if(qtdMensagens > qtdMensagensAtual)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> AceitarChamado(int idConversa, int idFuncionario)
        {
            HelpDesk funcionario = await _contexto.HelpDesk.FindAsync(idFuncionario);
            if (funcionario == null)
            {
                throw new Exception($"Funcionário de Id:{idFuncionario} não encontrado na base de dados.");
            }
            
            Conversa conversa = await BuscarConversaPorId(idConversa);
            if (conversa == null)
            {
                throw new Exception($"Conversa de Id:{idConversa} não encontrado na base de dados.");
            }

            conversa.Funcionario = funcionario;
            conversa.FuncionariosId = idFuncionario;
            if(conversa.TipoConversa == TipoConversa.HelpDesk)
            {
                funcionario.Status = StatusHelpDesk.Ocupado;
            }

            _contexto.HelpDesk.Update(funcionario);
            _contexto.Conversa.Update(conversa);
            await _contexto.SaveChangesAsync();
            return true;
        }

        public async Task<List<Conversa>> ListarChamados(int tipo, bool aceito = false)
        {
            TipoConversa tipoConversa = (TipoConversa)tipo;
            List<Conversa> ConversaLista;
            if (!aceito)
            {
                ConversaLista = await _contexto.Conversa.Where(x => x.TipoConversa == tipoConversa && x.Status==StatusConversa.NaoAceito).ToListAsync();
            }
            else
            {
                ConversaLista = await _contexto.Conversa.Where(x => x.TipoConversa == tipoConversa && x.Status!=StatusConversa.NaoAceito).ToListAsync();
            }
            
            return ConversaLista;
        }

        public async Task<List<Conversa>> ListarConversas(int idUsuario)
        {
            List<Conversa> ConversaLista = await _contexto.Conversa.Where(x => x.FuncionariosId == idUsuario || x.ClienteId == idUsuario).ToListAsync();

            return ConversaLista;
        }

        public async Task<bool> AtualizarStatusConversa(int idConversa, int status)
        {
            Conversa conversa = await BuscarConversaPorId(idConversa);
            if (conversa == null)
            {
                throw new Exception($"Conversa de Id:{idConversa} não encontrado na base de dados.");
            }
            StatusConversa StatusCorrigido = (StatusConversa)status;
            conversa.Status = StatusCorrigido;
            if (StatusCorrigido == StatusConversa.EmEspera && conversa.FuncionariosId!=null)
            {
                HelpDesk funcionario = await _contexto.HelpDesk.FindAsync(conversa.FuncionariosId);
                funcionario.Status = StatusHelpDesk.Disponivel;
                _contexto.HelpDesk.Update(funcionario);
            }
            _contexto.Conversa.Update(conversa);
            await _contexto.SaveChangesAsync();

            return true;
        }
    }
}
