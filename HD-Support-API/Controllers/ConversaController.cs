using HD_Support_API.Models;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HD_Support_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversaController : ControllerBase
    {
        private readonly IConversaRepositorio _repositorio;

        public ConversaController(IConversaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [HttpGet]
        [Route("Lista-Mensagens")]
        public async Task<IActionResult> ListarMensagens(int idConversa)
        {
            var listaMensagens = await _repositorio.ListarMensagens(idConversa);
            return Ok(listaMensagens);
        }

        [HttpPost]
        [Route("Registro-Conversa")]
        public async Task<IActionResult> IniciarConversa([FromBody] Conversa conversa)
        {
            if (conversa == null)
            {
                return BadRequest("Dados da conversa não fornecidos");
            }

            var conversaAdicionada = await _repositorio.IniciarConversa(conversa);

            return Ok(conversaAdicionada);
        }

        [HttpPost]
        [Route("Registro-Mensagem")]
        public async Task<IActionResult> EnviarMensagem(int idConversa, [FromBody] Mensagens mensagem)
        {
            if (mensagem == null)
            {
                return BadRequest("Dados da mensagem não fornecidos");
            }

            var mensagemAdicionada = await _repositorio.EnviarMensagem(idConversa, mensagem);

            return Ok(mensagemAdicionada);
        }

        [HttpGet]
        [Route("Buscar-Conversa-Por-Id/{id}")]
        public async Task<IActionResult> BuscarConversaPorId(int id)
        {
            var busca = await _repositorio.BuscarConversaPorId(id);

            if (busca == null)
            {
                return NotFound($"Conversa com ID:{id} não encontrado");
            }

            return Ok(busca);
        }

        [HttpPut]
        [Route("Terminar-Conversa/{id}")]
        public async Task<IActionResult> TerminarConversa(int id)
        {
            var Terminar = await _repositorio.BuscarConversaPorId(id);
            if (Terminar == null)
            {
                return BadRequest($"Cadastro com ID:{id} não encontrado");
            }

            var atualizarConversa = await _repositorio.TerminarConversa(id);
            return Ok(atualizarConversa);
        }

        [HttpPost]
        [Route("Excluir-Mensagem/{id}")]
        public async Task<IActionResult> ExcluirMensagem(int id)
        {
            var Excluir = await _repositorio.ExcluirMensagem(id);

            if (Excluir == false)
            {
                return NotFound($"Mensagem com ID:{id} não encontrado");
            }

            return Ok(Excluir);
        }

        [HttpGet]
        [Route("Verificar-Mensagem-Nova")]
        public async Task<IActionResult> VerificarMensagemNova(int idConversa, int qtdMensagensAtual)
        {
            var TemMensagemNova = await _repositorio.VerificarMensagemNova(idConversa, qtdMensagensAtual);
            return Ok(TemMensagemNova);
        }
    }
}

