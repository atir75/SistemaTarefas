using Microsoft.EntityFrameworkCore;

using TarefasSistema.Data;
using TarefasSistema.Models;
using TarefasSistema.Repository.Interface;

namespace TarefasSistema.Repository
{
    public class UsuarioRepositorio : IUsuarioRepository
    {
        private readonly SistemasTarefaDBContext _dbContext;
        public UsuarioRepositorio(SistemasTarefaDBContext sistemasTarefaDBContext)
        {
            _dbContext = sistemasTarefaDBContext;
        }
        public async Task<UsuarioModel> BuscarById(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return usuario;
        }

        public Task<bool> Apagar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            throw new NotImplementedException();
        }

        
    }
}
