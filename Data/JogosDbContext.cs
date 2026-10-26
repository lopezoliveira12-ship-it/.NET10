using ApiJogos.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiJogos.Data;

public class JogosDbContext : DbContext
{
    public JogosDbContext(DbContextOptions<JogosDbContext> options)
        : base(options)
    {
    }

    public DbSet<Jogo> Jogos => Set<Jogo>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Jogo>().HasData(
            new Jogo
            {
                Id = 1,
                Nome = "Minecraft",
                Genero = "Sandbox",
                Ano = 2011
            },
            new Jogo
            {
                Id = 2,
                Nome = "FIFA 25",
                Genero = "Esportes",
                Ano = 2024
            }
        );
    }
}