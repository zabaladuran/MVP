using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class SubscriptionBadgeControl : UserControl
    {
        private string _prefix = "Resumen general —";
        private string _label = "Suscripción vence:";
        private DateTime _expirationDate = new DateTime(2025, 12, 31);
        private Color _badgeColor = Color.FromArgb(239, 246, 255);
        private Color _borderColor = Color.FromArgb(191, 219, 254);
        private Color _textColor = Color.FromArgb(30, 30, 50);
        private int _cornerRadius = 12;
        private int _iconSize = 18;

        public SubscriptionBadgeControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            UpdateText();
        }

        private void UpdateText()
        {
            lblText.Text = $"{_prefix} {_label} {_expirationDate:dd MMM yyyy}";
        }

        [Category("Data")]
        [DefaultValue("Resumen general —")]
        public string Prefix
        {
            get => _prefix;
            set { _prefix = value; UpdateText(); }
        }

        [Category("Data")]
        [DefaultValue("Suscripción vence:")]
        public string Label
        {
            get => _label;
            set { _label = value; UpdateText(); }
        }

        [Category("Data")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public DateTime ExpirationDate
        {
            get => _expirationDate;
            set { _expirationDate = value; UpdateText(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BadgeColor
        {
            get => _badgeColor;
            set { _badgeColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TextColor
        {
            get => _textColor;
            set { _textColor = value; lblText.ForeColor = value; }
        }

        [Category("Appearance")]
        [DefaultValue(12)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = GetRoundedRectangle(rect, _cornerRadius))
            using (var brush = new SolidBrush(_badgeColor))
            using (var pen = new Pen(_borderColor, 1))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
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

        private void lblText_Click(object sender, EventArgs e)
        {

        }
    }
}