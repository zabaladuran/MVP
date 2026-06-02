using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class OrderList : UserControl
    {
        private Color _borderColor = Color.FromArgb(220, 220, 232);
        private int _cornerRadius = 8;

        public OrderList()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
        }

        // ── API pública ───────────────────────────────────────────────────────

        public void AddOrder(OrderCard order)
        {
            if (order == null) return;
            order.Margin = new Padding(0, 0, 0, 8);
            flowPanel.Controls.Add(order);
        }

        public void ClearOrders() => flowPanel.Controls.Clear();

        public FlowLayoutPanel OrdersContainer => flowPanel;

        // ── Propiedades ───────────────────────────────────────────────────────

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get => _borderColor;
            set { _borderColor = value; Invalidate(); }
        }
        private bool ShouldSerializeBorderColor() => _borderColor != Color.FromArgb(220, 220, 232);
        private void ResetBorderColor() => BorderColor = Color.FromArgb(220, 220, 232);

        [Category("Appearance"), DefaultValue(8)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; Invalidate(); }
        }

        // ── Paint ─────────────────────────────────────────────────────────────

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            var rect = new Rectangle(0, 0, Width - 1, Height - 1);
            using (var path = RoundedRect(rect, _cornerRadius))
            using (var pen = new Pen(_borderColor, 1))
                e.Graphics.DrawPath(pen, path);
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
    }
}