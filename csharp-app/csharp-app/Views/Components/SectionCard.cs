using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class SectionCard : UserControl
    {
        private string _title = "Pedidos recientes";
        private string _subtitle = "Los datos aquí mostrados corresponden únicamente a la tienda seleccionada en el selector superior.";
        private string _storeName = "Tienda Norte";
        private bool _showStoreInTitle = true;
        private string _separator = " — ";
        private int _cornerRadius = 12;
        private Color _cardBackColor = Color.White;
        private Color _borderColor = Color.FromArgb(220, 220, 232);
        private bool _autoHeight = true; // Nueva propiedad

        // Valores por defecto para fuentes y colores de texto
        private static readonly Font DefaultTitleFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        private static readonly Color DefaultTitleColor = Color.FromArgb(30, 30, 40);
        private static readonly Font DefaultSubtitleFont = new Font("Segoe UI", 9F);
        private static readonly Color DefaultSubtitleColor = Color.FromArgb(110, 110, 130);

        public SectionCard()
        {
            InitializeComponent();
            DoubleBuffered = true;
            // Aplicar valores por defecto solo si el diseñador no los ha establecido
            if (lblTitle.Font == null || lblTitle.Font.Equals(SystemFonts.DefaultFont))
                lblTitle.Font = DefaultTitleFont;
            if (lblTitle.ForeColor == Color.Empty)
                lblTitle.ForeColor = DefaultTitleColor;
            if (lblSubtitle.Font == null || lblSubtitle.Font.Equals(SystemFonts.DefaultFont))
                lblSubtitle.Font = DefaultSubtitleFont;
            if (lblSubtitle.ForeColor == Color.Empty)
                lblSubtitle.ForeColor = DefaultSubtitleColor;

            UpdateTitleText();
            if (_autoHeight) AjustarAltura();
        }

        [Category("Appearance")]
        [DefaultValue("Pedidos recientes")]
        public string Title
        {
            get => _title;
            set { _title = value; UpdateTitleText(); }
        }

        [Category("Appearance")]
        [DefaultValue("Los datos aquí mostrados corresponden únicamente a la tienda seleccionada en el selector superior.")]
        public string Subtitle
        {
            get => _subtitle;
            set { _subtitle = value; lblSubtitle.Text = value; if (_autoHeight) AjustarAltura(); }
        }

        [Category("Data")]
        [DefaultValue("Tienda Norte")]
        public string StoreName
        {
            get => _storeName;
            set { _storeName = value; UpdateTitleText(); }
        }

        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowStoreInTitle
        {
            get => _showStoreInTitle;
            set { _showStoreInTitle = value; UpdateTitleText(); }
        }

        [Category("Appearance")]
        [DefaultValue(" — ")]
        public string TitleSeparator
        {
            get => _separator;
            set { _separator = value; UpdateTitleText(); }
        }

        [Category("Appearance")]
        [DefaultValue(12)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
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

        // Propiedad CardBackColor con serialización
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Color), "White")]
        public Color CardBackColor
        {
            get => _cardBackColor;
            set { _cardBackColor = value; Invalidate(); }
        }
        private bool ShouldSerializeCardBackColor() => _cardBackColor != Color.White;

        // Propiedad BorderColor con serialización
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Color), "220,220,232")]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }
        private bool ShouldSerializeBorderColor() => _borderColor != Color.FromArgb(220, 220, 232);

        // Propiedades de fuente y color del título
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont
        {
            get => lblTitle.Font;
            set { lblTitle.Font = value; if (_autoHeight) AjustarAltura(); }
        }
        private bool ShouldSerializeTitleFont() => !lblTitle.Font.Equals(DefaultTitleFont);

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleColor
        {
            get => lblTitle.ForeColor;
            set => lblTitle.ForeColor = value;
        }
        private bool ShouldSerializeTitleColor() => lblTitle.ForeColor != DefaultTitleColor;

        // Propiedades de fuente y color del subtítulo
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font SubtitleFont
        {
            get => lblSubtitle.Font;
            set { lblSubtitle.Font = value; if (_autoHeight) AjustarAltura(); }
        }
        private bool ShouldSerializeSubtitleFont() => !lblSubtitle.Font.Equals(DefaultSubtitleFont);

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color SubtitleColor
        {
            get => lblSubtitle.ForeColor;
            set => lblSubtitle.ForeColor = value;
        }
        private bool ShouldSerializeSubtitleColor() => lblSubtitle.ForeColor != DefaultSubtitleColor;

        // Actualiza el texto del título
        private void UpdateTitleText()
        {
            if (_showStoreInTitle && !string.IsNullOrEmpty(_storeName))
                lblTitle.Text = $"{_title}{_separator}{_storeName}";
            else
                lblTitle.Text = _title;
            if (_autoHeight) AjustarAltura();
        }

        // Ajusta la altura según el contenido del subtítulo (solo si AutoHeight = true)
        private void AjustarAltura()
        {
            if (lblSubtitle == null) return;
            Size textSize = TextRenderer.MeasureText(lblSubtitle.Text, lblSubtitle.Font,
                new Size(lblSubtitle.MaximumSize.Width, 0), TextFormatFlags.WordBreak);
            int requiredHeight = lblTitle.Height + textSize.Height + 40;
            if (requiredHeight != Height)
                Height = requiredHeight;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            // Si no es autoheight, solo redibujamos los bordes redondeados,
            // pero no cambiamos la altura automáticamente.
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = GetRoundedRectangle(rect, _cornerRadius))
            using (Pen pen = new Pen(_borderColor, 1))
            using (SolidBrush brush = new SolidBrush(_cardBackColor))
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

        public void SetStore(string storeName)
        {
            StoreName = storeName;
        }

        private void lblSubtitle_Click(object sender, EventArgs e)
        {

        }
    }
}