using api_SistemaVendas.Enums;
using System.ComponentModel.DataAnnotations;

namespace api_SistemaVendas.Models.Funcionario
{
    public class FuncionarioModel
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public CargoEnum Cargo { get; set; }
        public int IdSupervisor { get; set; }

        public FuncionarioModel(string nome, CargoEnum cargo, int idSupervisor)
        {
            Nome = nome;
            Cargo = cargo;
            IdSupervisor = idSupervisor;
        }
    }
}
