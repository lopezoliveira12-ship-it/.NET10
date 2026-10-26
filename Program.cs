using ApiJogos.Data;
using ApiJogos.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JogosDbContext>(options =>
    options.UseSqlite("Data Source=jogos.db"));

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/", () =>
{
    return Results.Text("API de Jogos está funcionando!");
});

app.MapGet("/api/jogos", (JogosDbContext db) =>
{
    var jogos = db.Jogos.AsNoTracking().ToList();

    return Results.Ok(jogos);
});

app.MapGet("/api/jogos/{id:int}", IResult (int id, JogosDbContext db) =>
{
    var jogo = db.Jogos.Find(id);

    if (jogo == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(jogo);
});

app.MapPost("/api/jogos", (JogoEntrada entrada, JogosDbContext db) =>
{
    var jogo = new Jogo
    {
        Nome = entrada.Nome,
        Genero = entrada.Genero,
        Ano = entrada.Ano
    };

    db.Jogos.Add(jogo);
    db.SaveChanges();

    return Results.Created($"/api/jogos/{jogo.Id}", jogo);
});

app.MapPut("/api/jogos/{id:int}", IResult (int id, JogoEntrada entrada, JogosDbContext db) =>
{
    var jogo = db.Jogos.Find(id);

    if (jogo == null)
    {
        return Results.NotFound();
    }

    jogo.Nome = entrada.Nome;
    jogo.Genero = entrada.Genero;
    jogo.Ano = entrada.Ano;

    db.SaveChanges();

    return Results.Ok(jogo);
});

app.MapDelete("/api/jogos/{id:int}", IResult (int id, JogosDbContext db) =>
{
    var jogo = db.Jogos.Find(id);

    if (jogo == null)
    {
        return Results.NotFound();
    }

    db.Jogos.Remove(jogo);
    db.SaveChanges();

    return Results.NoContent();
});

app.Run("http://localhost:5050");