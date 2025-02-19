using api_SistemaVendas.Data;
using api_SistemaVendas.Models.Funcionario;
using api_SistemaVendas.Repositories;

namespace api_SistemaVendas.Services
{
    public class FuncionarioService
    {
        private readonly FuncionarioRepository _repository;

        public FuncionarioService(FuncionarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FuncionarioModel>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<FuncionarioModel> GetById(int id)
        {
            return await _repository.GetById(id);
        }

        public async Task<FuncionarioModel> Create(FuncionarioRequest funcionario)
        {
            FuncionarioModel funcionarioModel = new FuncionarioModel(funcionario.Nome, funcionario.Cargo, funcionario.IdSupervisor);
            return await _repository.Create(funcionarioModel);
        }

        public async Task<FuncionarioModel> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<FuncionarioModel> Update(int id, FuncionarioModel funcionarioAtualizado)
        {
            return await _repository.Update(id, funcionarioAtualizado);
        }
    }
}
