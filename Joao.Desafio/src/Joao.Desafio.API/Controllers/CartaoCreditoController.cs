using Joao.Desafio.API.DTO;
using Joao.Desafio.Dominio.Entidades;
using Joao.Desafio.Dominio.IRepositorios;
using Microsoft.AspNetCore.Mvc;

namespace Joao.Desafio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoCreditoController : ControllerBase
    {
        private readonly ICartaoCreditoRepositorio _cartaoCreditoRepositorio;

        public CartaoCreditoController(ICartaoCreditoRepositorio cartaoCreditoRepositorio)
        {
            _cartaoCreditoRepositorio = cartaoCreditoRepositorio;
        }


        // GET obter-todos
        /// <summary>
        /// Obtem todos os Cartões de Créditos cadastrados 
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter-todos
        /// 
        /// </remarks> 
        /// <returns>Listagem de Cartões de Créditos cadastrados .</returns>
        /// <response code="200">Retorna listagem dos Cartões de Créditos</response>
        [HttpGet("obter-todos")]
        public IActionResult ObterTodos()
        {
            return Ok(_cartaoCreditoRepositorio.ObteTodos());
        }

        // GET obter
        /// <summary>
        /// Obtem o Cartões de Créditos cadastrado a partir do Guid do registro do mesmo 
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        /// 
        /// </remarks> 
        /// <returns>Cartões de Créditos com o Guid informado em caso de encontrado.</returns>
        /// <response code="200">Retorna o Cartões de Créditos buscado</response>
        [HttpGet("obter")]
        public IActionResult Obter(Guid id)
        {
            return Ok(_cartaoCreditoRepositorio.Obter(id));
        }

        // POST novo
        /// <summary>
        /// Registra um novo Cartões de Créditos
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /novo
        ///     {        
        ///         "estudanteId": "216d5ef4-c339-4bfa-8f47-38e7b3dc563d",
        ///         "numero": "1111222233334444",
        ///         "nomeTitular": "JOAO C FRANCA",
        ///         "validade": "01/29",
        ///         "codigo": "987"        
        ///      }
        /// 
        /// </remarks>
        /// <param name="estudanteId">Guid do estudante dono do cartão de crédito</param>
        /// <param name="numero">Numero do cartão</param>
        /// <param name="nomeTitular">Nome do Titular escrito no cartão</param>
        /// <param name="validade">validade mês/ano do cartão</param>
        /// <param name="codigo">código do cartão</param>
        /// <returns>Retorna informações do estudante cadastrado</returns>
        /// <response code="200">Estudante cadastrado</response>
        [HttpPost("novo")]
        public IActionResult Novo(CartaoCreditoDTO cartaoNovo)
        {            
            var cartao = new CartaoCredito(
                    cartaoNovo.EstudanteId,
                    cartaoNovo.Numero,
                    cartaoNovo.NomeTitular,
                    cartaoNovo.Validade,
                    cartaoNovo.Codigo
                );

            _cartaoCreditoRepositorio.Adicionar(cartao);

            return Ok(cartao);
        }

        // PUT editar
        /// <summary>
        /// Edita informações sobre o cartão de crédito - não edita o estudante
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Editar?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        ///     {          
        ///          "numero": "1111222233334444",
        ///          "nomeTitular": "JOAO C FRANCA",
        ///          "validade": "01/29",
        ///          "codigo": "987"
        ///      }
        /// 
        /// </remarks>        
        /// <param name="numero">Numero do cartão</param>
        /// <param name="nomeTitular">Nome do Titular escrito no cartão</param>
        /// <param name="validade">validade mês/ano do cartão</param>
        /// <param name="codigo">código do cartão</param>
        /// <returns>Retorna informações do cartão de crédito editado </returns>
        /// <response code="200">Cartão de Crédito Editado</response>
        [HttpPut("editar")]
        public IActionResult Editar(Guid id, CartaoCreditoEditarDTO cartaoEditado)
        {
            var cartao = _cartaoCreditoRepositorio.Obter(id);

            if (cartao != null)
            {
                cartao.Editar(cartaoEditado.Numero, cartaoEditado.NomeTitular, cartaoEditado.Validade, cartaoEditado.Codigo);

                _cartaoCreditoRepositorio.Atualizar(cartao);

                return Ok(cartao);
            }

            return BadRequest();
        }

        // DELETE remover
        /// <summary>
        /// Apaga um registro de cartão de crédito a partir do Guid.
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /remover?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        /// 
        /// </remarks> 
        /// <returns>Mensagem de sucesso</returns>
        /// <response code="200">Retorna mensagem de sucesso</response>
        [HttpDelete("remover")]
        public IActionResult Remover(Guid id)
        {
            var estudante = _cartaoCreditoRepositorio.Obter(id);
            if (estudante != null)
            {
                _cartaoCreditoRepositorio.Apagar(estudante);

                return Ok("Sucesso!");
            }

            return BadRequest();
        }
    }
}
