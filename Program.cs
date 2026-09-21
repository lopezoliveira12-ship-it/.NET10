var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

List<Jogo> jogos = new List<Jogo>
{
    new Jogo(1, "Minecraft", "Sandbox", 2011),
    new Jogo(2, "FIFA 25", "Esportes", 2024)
};

app.MapGet("/", () =>
{
    return "API de Jogos está funcionando!";
});

app.MapGet("/api/jogos", () =>
{
    return Results.Ok(jogos);
});

app.MapGet("/api/jogos/{id}", (int id) =>
{
    var jogo = jogos.FirstOrDefault(j => j.Id == id);

    if (jogo == null)
    {
        return Results.NotFound();
    }

    return Results.Ok(jogo);
});

app.MapPost("/api/jogos", (JogoEntrada entrada) =>
{
    int novoId = jogos.Count > 0 ? jogos.Max(j => j.Id) + 1 : 1;

    var jogo = new Jogo(
        novoId,
        entrada.Nome,
        entrada.Genero,
        entrada.Ano
    );

    jogos.Add(jogo);

    return Results.Created($"/api/jogos/{jogo.Id}", jogo);
});

app.MapPut("/api/jogos/{id}", (int id, JogoEntrada entrada) =>
{
    var indice = jogos.FindIndex(j => j.Id == id);

    if (indice == -1)
    {
        return Results.NotFound();
    }

    var jogoAtualizado = new Jogo(
        id,
        entrada.Nome,
        entrada.Genero,
        entrada.Ano
    );

    jogos[indice] = jogoAtualizado;

    return Results.Ok(jogoAtualizado);
});

app.MapDelete("/api/jogos/{id}", (int id) =>
{
    var jogo = jogos.FirstOrDefault(j => j.Id == id);

    if (jogo == null)
    {
        return Results.NotFound();
    }

    jogos.Remove(jogo);

    return Results.NoContent();
});

app.Run("http://localhost:5050");

public record Jogo(
    int Id,
    string Nome,
    string Genero,
    int Ano
);

public record JogoEntrada(
    string Nome,
    string Genero,
    int Ano
);