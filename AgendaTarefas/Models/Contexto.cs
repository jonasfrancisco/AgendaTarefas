using Microsoft.EntityFrameworkCore;

namespace AgendaTarefas.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Tarefa>Tarefas{ get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
            
        }
    }
}
