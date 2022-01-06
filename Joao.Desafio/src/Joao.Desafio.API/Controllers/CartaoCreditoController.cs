using Microsoft.AspNetCore.Mvc;

namespace Joao.Desafio.API.Controllers
{
    public class CartaoCreditoController : Controller
    {
        /*
        // GET obter-todos
        /// <summary>
        /// Obtem todos os Estudantes cadastrados 
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter-todos
        /// 
        /// </remarks> 
        /// <returns>Listagem de Estudantes cadastrados .</returns>
        /// <response code="200">Retorna listagem dos Estudantes</response>
        [HttpGet("obter-todos")]
        public IActionResult ObterTodos()
        {
            return Ok(_estudanteRepositorio.ObteTodos());
        }

        // GET obter
        /// <summary>
        /// Obtem o Estudante cadastrado a partir do Guid do registro do mesmo 
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /obter?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        /// 
        /// </remarks> 
        /// <returns>Estudante com o Guid informado em caso de encontrado.</returns>
        /// <response code="200">Retorna o Estudante buscado</response>
        [HttpGet("obter")]
        public IActionResult Obter(Guid id)
        {
            return Ok(_estudanteRepositorio.Obter(id));
        }

        // POST novo
        /// <summary>
        /// Registra um novo Estudante
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /novo
        ///     {
        ///          "nomeCompleto": "João Carias de França",
        ///          "cartaoCredito": {
        ///                "numero": "1111222233334444",
        ///                "nomeTitular": "JOAO C FRANCA",
        ///                "validade": "01/29",
        ///                "codigo": "987"
        ///           }
        ///      }
        /// 
        /// </remarks>
        /// <param name="nomeCompleto">Descrição ou nome do Estudante</param>
        /// <param name="numero">Numero do cartão</param>
        /// <param name="nomeTitular">Nome do Titular escrito no cartão</param>
        /// <param name="validade">validade mês/ano do cartão</param>
        /// <param name="codigo">código do cartão</param>
        /// <returns>Retorna informações do estudante cadastrado</returns>
        /// <response code="200">Estudante cadastrado</response>
        [HttpPost("novo")]
        public IActionResult Novo(EstudanteDTO estudanteNovo)
        {
            var cartaoCredito = new CartaoCredito(
                    estudanteNovo.CartaoCredito.Numero,
                    estudanteNovo.CartaoCredito.NomeTitular,
                    estudanteNovo.CartaoCredito.Validade,
                    estudanteNovo.CartaoCredito.Codigo
                );

            var estudante = new Estudante(estudanteNovo.NomeCompleto, cartaoCredito);

            _estudanteRepositorio.Adicionar(estudante);

            return Ok(estudante);
        }

        // PUT editar
        /// <summary>
        /// Edita um NomeCompleto existente
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST /Editar?id=216d5ef4-c339-4bfa-8f47-38e7b3dc563d
        ///     {
        ///          "nomeCompleto": "João Carias de França Editado",
        ///          "cartaoCredito": {
        ///                "numero": "1111222233334444",
        ///                "nomeTitular": "JOAO C FRANCA",
        ///                "validade": "01/29",
        ///                "codigo": "987"
        ///           }
        ///      }
        /// 
        /// </remarks>
        /// <param name="nomeCompleto">Descrição ou nome do Estudante</param>
        /// <param name="numero">Numero do cartão</param>
        /// <param name="nomeTitular">Nome do Titular escrito no cartão</param>
        /// <param name="validade">validade mês/ano do cartão</param>
        /// <param name="codigo">código do cartão</param>
        /// <returns>Retorna informações do estudante editado </returns>
        /// <response code="200">Estudante Editado</response>
        [HttpPut("editar")]
        public IActionResult Editar(Guid id, EstudanteDTO estudanteEditado)
        {
            var estudante = _estudanteRepositorio.Obter(id);

            if (estudante != null)
            {
                var cartao = EditcaoCartaoCredito(estudante.CartaoCredito, estudanteEditado.CartaoCredito);

                estudante.Editar(estudanteEditado.NomeCompleto, cartao);

                _estudanteRepositorio.Atualizar(estudante);

                return Ok(estudante);
            }

            return BadRequest();
        }

        // DELETE remover
        /// <summary>
        /// Apaga um registro de estudante a partir do Guid.
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
            var estudante = _estudanteRepositorio.Obter(id);
            if (estudante != null)
            {
                _estudanteRepositorio.Apagar(estudante);

                return Ok("Sucesso!");
            }

            return BadRequest();
        }

        private CartaoCredito EditcaoCartaoCredito(CartaoCredito? cartaoAtual, CartaoCreditoDTO cartaoEdicao)
        {
            if (cartaoAtual != null && !string.IsNullOrEmpty(cartaoAtual.Id.ToString()))
            {
                cartaoAtual.Editar(
                        cartaoEdicao.Numero,
                        cartaoEdicao.NomeTitular,
                        cartaoEdicao.Validade,
                        cartaoEdicao.Codigo
                    );
            }
            else
            {
                cartaoAtual = new CartaoCredito(
                        cartaoEdicao.Numero,
                        cartaoEdicao.NomeTitular,
                        cartaoEdicao.Validade,
                        cartaoEdicao.Codigo
                    );
            }

            return cartaoAtual;
        }
        */
    }
}
