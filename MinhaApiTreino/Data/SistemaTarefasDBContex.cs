using Microsoft.EntityFrameworkCore;
using MinhaApiTreino.Data.Map;
using MinhaApiTreino.Model;

namespace MinhaApiTreino.Data
{
    public class SistemaTarefasDBContex : DbContext 
    {
        public SistemaTarefasDBContex(DbContextOptions<SistemaTarefasDBContex>options) : base(options)
        {       
        }

        //o cod c# cria as tabelas independente do tipo de banco de dados
        //aqui esta sendo criado duas tabelas
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefa { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());


            base.OnModelCreating(modelBuilder);
        }

    }
}
