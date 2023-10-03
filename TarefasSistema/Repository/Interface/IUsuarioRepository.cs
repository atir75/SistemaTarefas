using TarefasSistema.Models;

namespace TarefasSistema.Repository.Interface
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        Task<UsuarioModel> BuscarById(int id);
        Task<UsuarioModel> AdicionarUsuario(UsuarioModel usuario); //p add um usuario vou ter que receber um usuariomodel e jogar na variavel usuario
        Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id);
        Task<bool> Apagar(int id);
    }
}
