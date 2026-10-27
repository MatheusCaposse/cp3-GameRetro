namespace LojaGamesRetro;

public class MenuForm : Form
{
    public MenuForm()
    {
        Text = "Menu - Loja de Games Retro";
        Size = new Size(300, 250);
        StartPosition = FormStartPosition.CenterScreen;

        var btnCards = new Button();
        btnCards.Text = "Cards de Jogos";
        btnCards.SetBounds(50, 30, 180, 35);
        btnCards.Click += (s, e) => new CardsForm().ShowDialog();

        var btnRelatorio = new Button();
        btnRelatorio.Text = "Relatório de Vendas";
        btnRelatorio.SetBounds(50, 80, 180, 35);
        btnRelatorio.Click += (s, e) => new RelatorioForm().ShowDialog();

        var btnSair = new Button();
        btnSair.Text = "Sair";
        btnSair.SetBounds(50, 130, 180, 35);
        btnSair.Click += (s, e) => Close();

        Controls.Add(btnCards);
        Controls.Add(btnRelatorio);
        Controls.Add(btnSair);
    }
}
