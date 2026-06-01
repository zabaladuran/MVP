using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class KpiCardControl : UserControl
    {
        private string _title = "Título";
        private string _value = "0";
        private string _subText = "";
        private Color _subColor = Color.FromArgb(110, 110, 130);
        private int _cornerRadius = 12; // Radio de borde redondeado

        public KpiCardControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.BackColor = Color.White;
            // Asignar eventos de redibujado al cambiar tamaño
            this.Resize += (s, e) => Invalidate();
        }

        [Category("KPI Card")]
        [DefaultValue("Título")]
        public string Title
        {
            get => _title;
            set { _title = value; if (lblTitle != null) lblTitle.Text = value; }
        }

        [Category("KPI Card")]
        [DefaultValue("0")]
        public string Value
        {
            get => _value;
            set { _value = value; if (lblValue != null) lblValue.Text = value; }
        }

        [Category("KPI Card")]
        [DefaultValue("")]
        public string SubText
        {
            get => _subText;
            set { _subText = value; if (lblSub != null) lblSub.Text = value; }
        }

        [Category("KPI Card")]
        [DefaultValue(typeof(Color), "110,110,130")]
        public Color SubColor
        {
            get => _subColor;
            set { _subColor = value; if (lblSub != null) lblSub.ForeColor = value; }
        }

        [Category("KPI Card")]
        [DefaultValue(12)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = Math.Max(1, value); // evitar 0 o negativo
                Invalidate();
                // Actualizar la región del control para recortar los hijos
                UpdateRegion();
            }
        }

        // Aplica la región redondeada al control para que los labels también se recorten
        private void UpdateRegion()
        {
            if (Width > 0 && Height > 0 && _cornerRadius > 0)
            {
                using (var path = GetRoundedRectangle(new Rectangle(0, 0, Width, Height), _cornerRadius))
                {
                    this.Region = new Region(path);
                }
            }
            else
            {
                this.Region = null;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_cornerRadius <= 0) return;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            // Dibujar el borde redondeado y relleno
            using (var path = GetRoundedRectangle(new Rectangle(0, 0, Width - 1, Height - 1), _cornerRadius))
            using (var brush = new SolidBrush(BackColor))
            using (var pen = new Pen(Color.FromArgb(220, 220, 232), 1.2f))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateRegion(); // actualizar región al cambiar tamaño
            // Ajustar posiciones de labels proporcionalmente si se desea
            // (opcional, pero no necesario si los tamaños son fijos)
        }

        private static GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
    }
}