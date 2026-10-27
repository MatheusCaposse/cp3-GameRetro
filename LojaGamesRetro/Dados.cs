namespace LojaGamesRetro;

public class Jogo
{
    public string Nome { get; set; } = "";
    public string Console { get; set; } = "";
    public decimal Preco { get; set; }
}

public class Venda
{
    public DateTime Data { get; set; }
    public string Cliente { get; set; } = "";
    public string Jogos { get; set; } = "";
    public decimal Total { get; set; }
}

public static class Dados
{
    public static List<Jogo> Jogos = new List<Jogo>
    {
        new Jogo { Nome = "Super Mario World", Console = "Super Nintendo", Preco = 120.00m },
        new Jogo { Nome = "Sonic the Hedgehog", Console = "Mega Drive", Preco = 90.00m },
        new Jogo { Nome = "Donkey Kong Country", Console = "Super Nintendo", Preco = 110.00m },
        new Jogo { Nome = "Street Fighter II", Console = "Super Nintendo", Preco = 100.00m },
        new Jogo { Nome = "Golden Axe", Console = "Mega Drive", Preco = 80.00m },
        new Jogo { Nome = "Crash Bandicoot", Console = "PlayStation 1", Preco = 130.00m }
    };

    public static List<Venda> Vendas = new List<Venda>();
}
