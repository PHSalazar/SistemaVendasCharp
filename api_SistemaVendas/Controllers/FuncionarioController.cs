using api_SistemaVendas.Models.Funcionario;
using api_SistemaVendas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace api_SistemaVendas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionarioController(FuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _funcionarioService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _funcionarioService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> GetById([FromBody] FuncionarioRequest funcionario)
        {
            var result = await _funcionarioService.Create(funcionario);
            return Ok(new {message="Funcionario criado com sucesso.", result});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _funcionarioService.Delete(id);
            return Ok(new { message = "Funcionario removido com sucesso.", result });
        }


    }
}
