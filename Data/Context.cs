using ImobiliariaLM.RazorPages.Models;
using Microsoft.EntityFrameworkCore;

namespace ImobiliariaLM.RazorPages.Data;

public class Contexto : DbContext
{
    public DbSet<CadastroModel> Cadastro { get; set; }

    public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CadastroModel>()
            .HasKey(t => t.Id)
            .HasAnnotation("Sqlite:Autoincrement", true);
    }
}
