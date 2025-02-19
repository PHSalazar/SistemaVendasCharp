using api_SistemaVendas.Enums;

namespace api_SistemaVendas.Models.Funcionario
{
    public class FuncionarioRequest
    {
        public string Nome { get; set; }
        public CargoEnum Cargo { get; set; }
        public int IdSupervisor { get; set; }
    }
}
