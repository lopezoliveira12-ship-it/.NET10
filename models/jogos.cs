namespace ApiJogos.Models;

public class Jogo
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public int Ano { get; set; }
}