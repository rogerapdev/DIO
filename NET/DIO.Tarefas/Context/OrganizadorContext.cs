using Microsoft.EntityFrameworkCore;
using DIO.Tarefas.Models;

namespace DIO.Tarefas.Context
{
    public class OrganizadorContext : DbContext
    {
        public OrganizadorContext(DbContextOptions<OrganizadorContext> options) : base(options)
        {
            
        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}