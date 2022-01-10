using Joao.Desafio.API.DTO;
using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Microsoft.AspNetCore.Mvc;

namespace Joao.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoRepositorio _pagamentoRepositorio;

        public PagamentoController(IPagamentoRepositorio pagamentoRepositorio)
        {
            _pagamentoRepositorio = pagamentoRepositorio;
        }

        // POST novo
        /// <summary>
        /// Registra um novo Pagamento
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /novo
        ///     {
        ///          "estudanteId": "216d5ef4-c339-4bfa-8f47-38e7b3dc563d",
        ///          "valor": 200.00,
        ///          "cartaoCreditoId": "216d5ef4-c339-4bfa-8f47-38e7b3dc563d"
        ///     }
        /// 
        /// </remarks>
        /// <param name="estudanteId">Guid do Estudante que realiza o pagamento</param>
        /// <param name="cartaoCreditoId">Guid do Cartao de Credito que é usado para o pagamento</param>
        /// <param name="valor">Valor do pagamento</param>
        /// <returns>Retorna informações do pagamento cadastrado</returns>
        /// <response code="200">Pagamento cadastrado</response>
        [HttpPost("novo")]
        public IActionResult Novo(PagamentoDTO pagamentoNovo)
        {
            var pagamento = new Pagamento(pagamentoNovo.EstudanteId, pagamentoNovo.Valor, pagamentoNovo.CartaoCreditoId);

            _pagamentoRepositorio.Adicionar(pagamento);

            return Ok(pagamento);
        }

        // GET obter-por-estudante
        /// <summary>
        /// Obtem a partir do guid do estudante, informacoes sobre pagamentos
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter-pagamentos-por-estudante?estudanteId=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        /// 
        /// </remarks>
        /// <returns>Retorna lista de pagamentos do estudante com informações do cadastrado</returns>
        /// <response code="200">Pagamentos do estudante</response>
        [HttpGet("obter-por-estudante")]
        public IActionResult ObterPagamentosPorEstudante(Guid estudanteId)
        {
            return Ok(_pagamentoRepositorio.ObterPorEstudanteId(estudanteId));
        }
    }
}
