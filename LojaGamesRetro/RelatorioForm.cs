namespace LojaGamesRetro;

public class RelatorioForm : Form
{
    public RelatorioForm()
    {
        Text = "Relatório de Vendas";
        Size = new Size(700, 400);
        StartPosition = FormStartPosition.CenterScreen;

        var grid = new DataGridView();
        grid.Dock = DockStyle.Fill;
        grid.ReadOnly = true;
        grid.AllowUserToAddRows = false;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.DataSource = Dados.Vendas.ToList();

        var lblTotal = new Label();
        lblTotal.Dock = DockStyle.Bottom;
        lblTotal.Height = 25;
        lblTotal.Text = "Total vendido: " + Dados.Vendas.Sum(v => v.Total).ToString("C2")
                        + "  |  Pedidos: " + Dados.Vendas.Count;

        Controls.Add(grid);
        Controls.Add(lblTotal);
    }
}
