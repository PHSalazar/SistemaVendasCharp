using api_SistemaVendas.Data;
using api_SistemaVendas.Exceptions;
using api_SistemaVendas.Models.Funcionario;

namespace api_SistemaVendas.Repositories
{
    public class FuncionarioRepository
    {
        private readonly SistemaVendasDbContext _context;

        public FuncionarioRepository(SistemaVendasDbContext context)
        {
            _context = context;
        }

        public async Task<List<FuncionarioModel>> GetAll()
        {
            return _context.Funcionario.ToList();
        }

        public async Task<FuncionarioModel> GetById(int id)
        {
            var funcionarioBD = _context.Funcionario.FirstOrDefault(f => f.Id == id);

            if (funcionarioBD == null)
                throw new NotFoundException($"Funcionário com o ID {id} não encontrado.");

            return funcionarioBD;
        }

        public async Task<FuncionarioModel> Create(FuncionarioModel funcionario)
        {
            _context.Funcionario.Add(funcionario);
            await _context.SaveChangesAsync();

            return funcionario;
        }

        public async Task<FuncionarioModel> Delete(int id)
        {
            var funcionarioBD = _context.Funcionario.FirstOrDefault(f => f.Id == id);

            if (funcionarioBD == null)
                throw new NotFoundException($"Funcionário com o ID {id} não encontrado e não pode ser removido.");

            _context.Funcionario.Remove(funcionarioBD);
            await _context.SaveChangesAsync();
            return funcionarioBD;
        }

        public async Task<FuncionarioModel> Update(int id, FuncionarioModel funcionarioAtualizado)
        {
            var funcionarioBD = _context.Funcionario.FirstOrDefault(f => f.Id == id);

            if (funcionarioBD == null)
                throw new Exception($"Funcionário com o ID {id} não encontrado e não pode ser removido.");

            funcionarioBD = funcionarioAtualizado;
            await _context.SaveChangesAsync();
            return funcionarioBD;
        }
    }
}
