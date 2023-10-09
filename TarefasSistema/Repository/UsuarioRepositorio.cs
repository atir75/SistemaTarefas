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
            await _dbContext.Usuarios.AddAsync(usuario);
            _dbContext.SaveChanges();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorID = await BuscarById(id);
            if(usuarioPorID == null)
            {
                throw new Exception($"Usuário do id {id} não foi encontrado.");
            }

            usuarioPorID.Nome = usuario.Nome;
            usuarioPorID.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorID);
            _dbContext.SaveChanges();

            return usuarioPorID;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorID = await BuscarById(id);
            if (usuarioPorID == null)
            {
                throw new Exception($"Usuário do id {id} não foi encontrado.");
            }
            _dbContext.Usuarios.Remove(usuarioPorID);
            _dbContext.SaveChanges();
            return true;
        }
        
    }
}
