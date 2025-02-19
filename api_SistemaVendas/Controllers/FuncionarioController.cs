using api_SistemaVendas.Models.Funcionario;
using api_SistemaVendas.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(await _funcionarioService.Create(funcionario));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            return Ok(await _funcionarioService.Delete(id));
        }


    }
}
