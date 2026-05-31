using csharp_app.Services;
using csharp_app.Presenters;

namespace csharp_app.Views
{
    public partial class TimerInicio : Form
    {
        private int _progressValue;

        public TimerInicio()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(241, 242, 250);

            _progressValue = 0;
            progressBar.Value = 0;
            lblStatus.Text = "Cargando aplicación...";

            timer1.Interval = 50;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            _progressValue = Math.Min(100, _progressValue + 1);
            progressBar.Value = _progressValue;
            
            lblStatus.Text = $"Cargando recursos... {_progressValue}%";

            if (_progressValue >= 100)
            {
                timer1.Stop();
                var loginForm = new LoginForm();
                var service = new LoginService();
                var presenter = new LoginPresenter(loginForm, service);

                Hide();
                loginForm.ShowDialog();
                Close();
            }

        }
    }
}
