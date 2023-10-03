using Microsoft.EntityFrameworkCore;
using TarefasSistema.Controllers;
using TarefasSistema.Models;

namespace TarefasSistema.Data
{
    public class SistemasTarefaDBContext : DbContext
    {
        public SistemasTarefaDBContext(DbContextOptions<SistemasTarefaDBContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
