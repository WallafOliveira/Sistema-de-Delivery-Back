using Microsoft.AspNetCore.Mvc;
using Sistema_de_delivery_back.Application.DTOs;
using Sistema_de_delivery_back.Application.UseCases;
using System;
using System.Linq;

namespace Sistema_de_delivery_back.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class ProdutoController : ControllerBase
    {
        // A controller não conhece o Repository, ela só conversa com os Use Cases!
        private readonly CreateProdutoUseCase _createProdutoUseCase;
        private readonly UpdateProdutoUseCase _updateProdutoUseCase;
        private readonly ListarProdutoUseCase _listarProdutosUseCase;
        private readonly ListarProdutosPorRestauranteUseCase _listarProdutosPorRestauranteUseCase;

        // O Construtor recebe todos os Use Cases injetados
        public ProdutoController(
            CreateProdutoUseCase createProdutoUseCase,
            UpdateProdutoUseCase updateProdutoUseCase,
            ListarProdutoUseCase listarProdutosUseCase,
            ListarProdutosPorRestauranteUseCase listarProdutosPorRestauranteUseCase)
        {
            _createProdutoUseCase = createProdutoUseCase;
            _updateProdutoUseCase = updateProdutoUseCase;
            _listarProdutosUseCase = listarProdutosUseCase;
            _listarProdutosPorRestauranteUseCase = listarProdutosPorRestauranteUseCase;
        }

        [HttpPost]
        public IActionResult Criar([FromBody] CreateProdutoDto dto)
        {
            try
            {
                var resultado = _createProdutoUseCase.Executar(dto);

                // Retorna 201 Created e o DTO do produto criado
                return Created("", resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message }); // Erro de validação (ex: valor negativo)
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno no servidor.", detalhe = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] UpdateProdutoDto dto)
        {
            try
            {
                // Garante que o ID da URL é o mesmo do corpo da requisição
                if (id != dto.Id)
                    return BadRequest(new { erro = "O ID da URL não confere com o ID do produto." });

                var resultado = _updateProdutoUseCase.Executar(dto);
                return Ok(resultado); // Retorna 200 OK com o DTO atualizado
            }
            catch (Exception ex) when (ex.Message == "Produto não encontrado.")
            {
                return NotFound(new { erro = ex.Message }); // Retorna 404
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { erro = "Erro interno no servidor." });
            }
        }

        [HttpGet]
        public IActionResult ObterTodos()
        {
            var produtos = _listarProdutosUseCase.Executar();
            return Ok(produtos); // Retorna Status 200 OK com a lista completa
        }

        // A Rota ficará: GET /api/produto/restaurante/{id}
        [HttpGet("restaurante/{restauranteId}")]
        public IActionResult ObterPorRestaurante(Guid restauranteId)
        {
            var produtos = _listarProdutosPorRestauranteUseCase.Executar(restauranteId);

            // Valida se a lista está vazia
            if (!produtos.Any())
                return NotFound(new { mensagem = "Nenhum produto encontrado para este restaurante." });

            return Ok(produtos); // Retorna Status 200 OK com os produtos filtrados
        }
    }
}