using Microsoft.AspNetCore.Mvc;
using TechStore.Produtos.Application.DTOs;
using TechStore.Produtos.Application.Services;

namespace TechStore.Produtos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoDigitalController : ControllerBase
    {
        private readonly ProdutoDigitalService _produtoDigitalService;

        public ProdutoDigitalController(ProdutoDigitalService produtoService)
        {
            _produtoDigitalService = produtoService;
        }

        [HttpPost("produto/create")]
        public async Task<IActionResult> CreateProduto([FromBody] ProdutoRequest produto)
        {
            try
            {
                await _produtoDigitalService.CreateProdutoAsync(produto);
                return Ok(new { Message = "Produto Criado com sucesso" });
            }
            catch (Exception ex) 
            {
                return StatusCode(500, new { Message = $"Erro interno: {ex.Message}" });
            }

        }

        [HttpGet("produto/{id:Guid}")]
        public async Task<IActionResult> GetProdutos(Guid id)
        {
            try
            {
                var produto = await _produtoDigitalService.GetProdutoAsync(id);
                return Ok(produto);
            }
            catch (Exception ex) 
            {
                return NotFound(new { Message = "Produto não encontrado" });
            }
        }

    }
}
