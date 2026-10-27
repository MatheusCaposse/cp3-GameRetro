namespace LojaGamesRetro;

public class CardsForm : Form
{
    private FlowLayoutPanel painelCards;
    private ListBox lstCarrinho;
    private Label lblTotal;
    private TextBox txtCliente;
    private List<Jogo> carrinho = new List<Jogo>();

    public CardsForm()
    {
        Text = "Cards de Jogos - Lançamento de Pedidos";
        Size = new Size(800, 450);
        StartPosition = FormStartPosition.CenterScreen;

        // Painel dos cards (esquerda)
        painelCards = new FlowLayoutPanel();
        painelCards.Dock = DockStyle.Fill;
        painelCards.AutoScroll = true;

        // Painel do pedido (direita)
        var painelPedido = new Panel();
        painelPedido.Dock = DockStyle.Right;
        painelPedido.Width = 280;

        var lblCliente = new Label();
        lblCliente.Text = "Cliente:";
        lblCliente.SetBounds(10, 10, 100, 20);

        txtCliente = new TextBox();
        txtCliente.SetBounds(10, 32, 250, 25);

        var lblPedido = new Label();
        lblPedido.Text = "Pedido:";
        lblPedido.SetBounds(10, 65, 100, 20);

        lstCarrinho = new ListBox();
        lstCarrinho.SetBounds(10, 88, 250, 200);

        lblTotal = new Label();
        lblTotal.Text = "Total: R$ 0,00";
        lblTotal.SetBounds(10, 295, 250, 20);

        var btnRemover = new Button();
        btnRemover.Text = "Remover selecionado";
        btnRemover.SetBounds(10, 320, 250, 28);
        btnRemover.Click += BtnRemover_Click;

        var btnFinalizar = new Button();
        btnFinalizar.Text = "Finalizar pedido";
        btnFinalizar.SetBounds(10, 355, 250, 28);
        btnFinalizar.Click += BtnFinalizar_Click;

        painelPedido.Controls.Add(lblCliente);
        painelPedido.Controls.Add(txtCliente);
        painelPedido.Controls.Add(lblPedido);
        painelPedido.Controls.Add(lstCarrinho);
        painelPedido.Controls.Add(lblTotal);
        painelPedido.Controls.Add(btnRemover);
        painelPedido.Controls.Add(btnFinalizar);

        Controls.Add(painelCards);
        Controls.Add(painelPedido);

        CriarCards();
    }

    private void CriarCards()
    {
        foreach (var jogo in Dados.Jogos)
        {
            var card = new Panel();
            card.Size = new Size(150, 110);
            card.BorderStyle = BorderStyle.FixedSingle;

            var lblNome = new Label();
            lblNome.Text = jogo.Nome;
            lblNome.SetBounds(5, 5, 140, 20);

            var lblConsole = new Label();
            lblConsole.Text = jogo.Console;
            lblConsole.SetBounds(5, 28, 140, 20);

            var lblPreco = new Label();
            lblPreco.Text = jogo.Preco.ToString("C2");
            lblPreco.SetBounds(5, 50, 140, 20);

            var btnAdd = new Button();
            btnAdd.Text = "Adicionar";
            btnAdd.SetBounds(5, 75, 140, 25);
            btnAdd.Click += (s, e) =>
            {
                carrinho.Add(jogo);
                AtualizarCarrinho();
            };

            card.Controls.Add(lblNome);
            card.Controls.Add(lblConsole);
            card.Controls.Add(lblPreco);
            card.Controls.Add(btnAdd);
            painelCards.Controls.Add(card);
        }
    }

    private void AtualizarCarrinho()
    {
        lstCarrinho.Items.Clear();
        foreach (var j in carrinho)
        {
            lstCarrinho.Items.Add(j.Nome + " - " + j.Preco.ToString("C2"));
        }
        lblTotal.Text = "Total: " + carrinho.Sum(j => j.Preco).ToString("C2");
    }

    private void BtnRemover_Click(object? sender, EventArgs e)
    {
        if (lstCarrinho.SelectedIndex >= 0)
        {
            carrinho.RemoveAt(lstCarrinho.SelectedIndex);
            AtualizarCarrinho();
        }
    }

    private void BtnFinalizar_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCliente.Text))
        {
            MessageBox.Show("Informe o nome do cliente.");
            return;
        }
        if (carrinho.Count == 0)
        {
            MessageBox.Show("Adicione pelo menos um jogo.");
            return;
        }

        var venda = new Venda();
        venda.Data = DateTime.Now;
        venda.Cliente = txtCliente.Text;
        venda.Jogos = string.Join(", ", carrinho.Select(j => j.Nome));
        venda.Total = carrinho.Sum(j => j.Preco);
        Dados.Vendas.Add(venda);

        MessageBox.Show("Pedido finalizado!");
        carrinho.Clear();
        txtCliente.Clear();
        AtualizarCarrinho();
    }
}
