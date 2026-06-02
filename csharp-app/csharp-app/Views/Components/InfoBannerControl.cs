using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class InfoBannerControl : UserControl
    {
        private Color _bannerColor = Color.FromArgb(239, 246, 255);
        private Color _borderColor = Color.FromArgb(191, 219, 254);
        private int _cornerRadius = 8;
        private bool _autoHeight = true;

        public InfoBannerControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            BackColor = _bannerColor;
            if (picIcon.Image == null)
                picIcon.Image = GetDefaultInfoIcon();
            picIcon.SizeMode = PictureBoxSizeMode.Zoom;
            // Ajustar altura inicial según el texto
            if (_autoHeight) AjustarAltura();
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue("Mensaje de información")]
        public string Message
        {
            get => lblMessage.Text;
            set
            {
                lblMessage.Text = value;
                if (_autoHeight) AjustarAltura();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BannerColor
        {
            get => _bannerColor;
            set
            {
                _bannerColor = value;
                BackColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                _borderColor = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(8)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set
            {
                _cornerRadius = value;
                Invalidate();
            }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Icon
        {
            get => picIcon.Image;
            set
            {
                picIcon.Image = value;
                if (value != null)
                    picIcon.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool AutoHeight
        {
            get => _autoHeight;
            set
            {
                _autoHeight = value;
                if (_autoHeight) AjustarAltura();
            }
        }

        private void AjustarAltura()
        {
            if (lblMessage == null) return;
            // Forzar recalcular el tamaño del texto
            Size textSize = TextRenderer.MeasureText(lblMessage.Text, lblMessage.Font);
            // Alto requerido = altura del texto + márgenes (30 píxeles)
            int requiredHeight = Math.Max(50, textSize.Height + 30);
            // Solo cambiamos la altura si la nueva altura es mayor que la actual o si la actual es muy pequeña
            if (requiredHeight > Height || Height < 50)
                Height = requiredHeight;
            // Centrar verticalmente los controles
            CentrarControles();
        }

        private void CentrarControles()
        {
            if (lblMessage == null || picIcon == null) return;
            lblMessage.Location = new Point(44, (Height - lblMessage.Height) / 2);
            picIcon.Location = new Point(12, (Height - picIcon.Height) / 2);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Si NO es autoheight, solo centramos los controles sin cambiar la altura
            if (!_autoHeight)
                CentrarControles();
            else
                AjustarAltura(); // si es autoheight, ajustamos al contenido
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = GetRoundedRectangle(rect, _cornerRadius))
            using (Pen pen = new Pen(_borderColor, 1))
            using (SolidBrush brush = new SolidBrush(_bannerColor))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Image GetDefaultInfoIcon()
        {
            Bitmap bmp = new Bitmap(24, 24);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.Transparent);
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using (Pen pen = new Pen(Color.FromArgb(59, 130, 246), 2))
                {
                    g.DrawEllipse(pen, 2, 2, 20, 20);
                }
                using (Font font = new Font("Segoe UI", 12, FontStyle.Bold))
                using (Brush brush = new SolidBrush(Color.FromArgb(59, 130, 246)))
                {
                    g.DrawString("i", font, brush, 7, 2);
                }
            }
            return bmp;
        }
    }
}