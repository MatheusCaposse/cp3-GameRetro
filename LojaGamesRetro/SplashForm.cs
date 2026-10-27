namespace LojaGamesRetro;

public class SplashForm : Form
{
    private Label lblTitulo;
    private Label lblCarregando;
    private System.Windows.Forms.Timer timer;

    public SplashForm()
    {
        Text = "Loja de Games Retro";
        Size = new Size(400, 200);
        StartPosition = FormStartPosition.CenterScreen;
        FormBorderStyle = FormBorderStyle.None;

        lblTitulo = new Label();
        lblTitulo.Text = "LOJA DE GAMES RETRO - 2026";
        lblTitulo.Font = new Font("Arial", 18, FontStyle.Bold);
        lblTitulo.AutoSize = false;
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        lblTitulo.Dock = DockStyle.Fill;

        lblCarregando = new Label();
        lblCarregando.Text = "Carregando...";
        lblCarregando.TextAlign = ContentAlignment.MiddleCenter;
        lblCarregando.Dock = DockStyle.Bottom;

        Controls.Add(lblTitulo);
        Controls.Add(lblCarregando);

        timer = new System.Windows.Forms.Timer();
        timer.Interval = 2500;
        timer.Tick += (s, e) =>
        {
            timer.Stop();
            Close();
        };
        timer.Start();
    }
}
