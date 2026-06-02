using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class OrdercardControl : UserControl
    {
        private string _status = "Pendiente";
        private int _cornerRadius = 8;
        private int _badgeRadius = 10;
        private Color _cardBackColor = Color.White;
        private Color _borderColor = Color.FromArgb(220, 220, 232);

        private static readonly Color PendingBg = Color.FromArgb(254, 243, 199);
        private static readonly Color PendingFg = Color.FromArgb(146, 64, 14);
        private static readonly Color ShippedBg = Color.FromArgb(219, 234, 254);
        private static readonly Color ShippedFg = Color.FromArgb(30, 64, 175);
        private static readonly Color DeliveredBg = Color.FromArgb(220, 252, 231);
        private static readonly Color DeliveredFg = Color.FromArgb(22, 101, 52);
        private static readonly Color DefaultBg = Color.FromArgb(241, 245, 249);
        private static readonly Color DefaultFg = Color.FromArgb(30, 41, 59);

        public OrdercardControl()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            UpdateStatusAppearance();
            ApplyBadgeRegion();
        }

        // ── Propiedades ───────────────────────────────────────────────────────

        [Category("Order Data"), DefaultValue("#00000")]
        public string OrderId
        {
            get => lblId.Text;
            set => lblId.Text = value;
        }

        [Category("Order Data"), DefaultValue("Cliente")]
        public string Customer
        {
            get => lblCustomer.Text;
            set => lblCustomer.Text = value;
        }

        [Category("Order Data"), DefaultValue("$0")]
        public string Total
        {
            get => lblTotal.Text;
            set => lblTotal.Text = value;
        }

        [Category("Order Data"), DefaultValue("Pendiente")]
        public string Status
        {
            get => _status;
            set { _status = value; UpdateStatusAppearance(); }
        }

        [Category("Appearance"), DefaultValue(8)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
        }

        [Category("Appearance"), DefaultValue(10)]
        public int BadgeRadius
        {
            get => _badgeRadius;
            set { _badgeRadius = value; ApplyBadgeRegion(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color CardBackColor
        {
            get => _cardBackColor;
            set { _cardBackColor = value; Invalidate(); }
        }
        private bool ShouldSerializeCardBackColor() => _cardBackColor != Color.White;
        private void ResetCardBackColor() => CardBackColor = Color.White;

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }
        private bool ShouldSerializeBorderColor() => _borderColor != Color.FromArgb(220, 220, 232);
        private void ResetBorderColor() => BorderColor = Color.FromArgb(220, 220, 232);

        // ── Lógica ────────────────────────────────────────────────────────────

        private void UpdateStatusAppearance()
        {
            switch (_status.ToLower())
            {
                case "pendiente":
                    pnlStatus.BackColor = PendingBg;
                    lblStatus.ForeColor = PendingFg; break;
                case "en camino":
                case "shipped":
                    pnlStatus.BackColor = ShippedBg;
                    lblStatus.ForeColor = ShippedFg; break;
                case "entregado":
                case "delivered":
                    pnlStatus.BackColor = DeliveredBg;
                    lblStatus.ForeColor = DeliveredFg; break;
                default:
                    pnlStatus.BackColor = DefaultBg;
                    lblStatus.ForeColor = DefaultFg; break;
            }
            lblStatus.Text = _status;
            ApplyBadgeRegion();
        }

        private void ApplyBadgeRegion()
        {
            if (pnlStatus.Width <= 0 || pnlStatus.Height <= 0) return;
            using (var path = RoundedRect(new Rectangle(0, 0, pnlStatus.Width, pnlStatus.Height), _badgeRadius))
            {
                pnlStatus.Region?.Dispose();
                pnlStatus.Region = new Region(path);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = RoundedRect(rect, _cornerRadius))
            using (var brush = new SolidBrush(_cardBackColor))
            using (var pen = new Pen(_borderColor, 1))
            {
                e.Graphics.FillPath(brush, path);
                e.Graphics.DrawPath(pen, path);
            }
        }

        private static GraphicsPath RoundedRect(Rectangle r, int radius)
        {
            int d = radius * 2;
            var path = new GraphicsPath();
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
}