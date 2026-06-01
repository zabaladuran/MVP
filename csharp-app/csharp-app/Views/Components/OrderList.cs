using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class OrderList : UserControl
    {
        // ═══════════════════════════════════════════════════════════════════
        //  OrderCard  —  clase anidada, hereda Panel (no UserControl).
        //  Al no ser UserControl el diseñador de VS no intenta abrirla
        //  como formulario independiente y no rompe el designer de OrderList.
        // ═══════════════════════════════════════════════════════════════════
        public class OrderCard : Panel
        {
            // ── Campos ────────────────────────────────────────────────────
            private string _orderId = "#00000";
            private string _customer = "Cliente";
            private string _total = "$0";
            private string _status = "Pendiente";
            private int _cornerRadius = 8;
            private int _badgeRadius = 10;
            private Color _cardBackColor = Color.White;
            private Color _borderColor = Color.FromArgb(220, 220, 232);
            private int _idWidth = 90;
            private int _customerWidth = 200;
            private int _totalWidth = 90;
            private int _statusWidth = 80;

            private Label lblId;
            private Label lblCustomer;
            private Label lblTotal;
            private Panel pnlStatus;
            private Label lblStatus;

            // ── Colores de estado ─────────────────────────────────────────
            private static readonly Color PendingBg = Color.FromArgb(254, 243, 199);
            private static readonly Color PendingFg = Color.FromArgb(146, 64, 14);
            private static readonly Color ShippedBg = Color.FromArgb(219, 234, 254);
            private static readonly Color ShippedFg = Color.FromArgb(30, 64, 175);
            private static readonly Color DeliveredBg = Color.FromArgb(220, 252, 231);
            private static readonly Color DeliveredFg = Color.FromArgb(22, 101, 52);
            private static readonly Color DefaultBg = Color.FromArgb(241, 245, 249);
            private static readonly Color DefaultFg = Color.FromArgb(30, 41, 59);

            // ── Constructor ───────────────────────────────────────────────
            public OrderCard()
            {
                SetStyle(
                    ControlStyles.UserPaint |
                    ControlStyles.ResizeRedraw |
                    ControlStyles.OptimizedDoubleBuffer |
                    ControlStyles.AllPaintingInWmPaint,
                    true);

                BackColor = Color.White;
                Size = new Size(600, 48);

                BuildControls();
                UpdateStatusAppearance();
                LayoutControls();

                Resize += (s, e) => LayoutControls();
            }

            // ── Controles internos ────────────────────────────────────────
            private void BuildControls()
            {
                lblId = new Label
                {
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(99, 102, 241),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent,
                    Text = _orderId
                };

                lblCustomer = new Label
                {
                    Font = new Font("Segoe UI", 9F),
                    ForeColor = Color.FromArgb(50, 50, 70),
                    TextAlign = ContentAlignment.MiddleLeft,
                    BackColor = Color.Transparent,
                    Text = _customer
                };

                lblTotal = new Label
                {
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(30, 30, 40),
                    TextAlign = ContentAlignment.MiddleRight,
                    BackColor = Color.Transparent,
                    Text = _total
                };

                lblStatus = new Label
                {
                    Dock = DockStyle.Fill,
                    Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Text = _status
                };

                pnlStatus = new Panel { BackColor = DefaultBg };
                pnlStatus.Controls.Add(lblStatus);

                Controls.AddRange(new Control[] { lblId, lblCustomer, lblTotal, pnlStatus });
            }

            // ── Layout ────────────────────────────────────────────────────
            private void LayoutControls()
            {
                const int ml = 16, mt = 12, lh = 24;

                lblId.Location = new Point(ml, mt);
                lblId.Size = new Size(_idWidth, lh);

                lblCustomer.Location = new Point(ml + _idWidth + 8, mt);
                lblCustomer.Size = new Size(_customerWidth, lh);

                int safeWidth = Math.Max(Width, _statusWidth + _totalWidth + 32);

                lblTotal.Location = new Point(safeWidth - (_statusWidth + _totalWidth + 16), mt);
                lblTotal.Size = new Size(_totalWidth, lh);

                pnlStatus.Location = new Point(safeWidth - _statusWidth - 16, mt);
                pnlStatus.Size = new Size(_statusWidth, lh);

                ApplyBadgeRegion();
            }

            private void ApplyBadgeRegion()
            {
                if (pnlStatus == null || pnlStatus.Width <= 0 || pnlStatus.Height <= 0) return;
                using (var path = RoundedRect(new Rectangle(0, 0, pnlStatus.Width, pnlStatus.Height), _badgeRadius))
                {
                    pnlStatus.Region?.Dispose();
                    pnlStatus.Region = new Region(path);
                }
            }

            // ── Estado ────────────────────────────────────────────────────
            private void UpdateStatusAppearance()
            {
                if (pnlStatus == null) return;
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

            // ── Propiedades ───────────────────────────────────────────────
            [Category("Order Data"), DefaultValue("#00000")]
            public string OrderId
            {
                get => _orderId;
                set { _orderId = value; if (lblId != null) lblId.Text = value; }
            }

            [Category("Order Data"), DefaultValue("Cliente")]
            public string Customer
            {
                get => _customer;
                set { _customer = value; if (lblCustomer != null) lblCustomer.Text = value; }
            }

            [Category("Order Data"), DefaultValue("$0")]
            public string Total
            {
                get => _total;
                set { _total = value; if (lblTotal != null) lblTotal.Text = value; }
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

            // ── Paint ─────────────────────────────────────────────────────
            protected override void OnPaint(PaintEventArgs e)
            {
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

            // ── Helper ────────────────────────────────────────────────────
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


        // ═══════════════════════════════════════════════════════════════════
        //  OrderList  —  lógica del contenedor principal
        // ═══════════════════════════════════════════════════════════════════
        private Color _headerBackColor = Color.FromArgb(248, 249, 252);
        private Color _borderColor = Color.FromArgb(220, 220, 232);
        private int _cornerRadius = 8;
        private int _idWidth = 90;
        private int _customerWidth = 200;
        private int _totalWidth = 90;
        private int _statusWidth = 80;

        public OrderList()
        {
            InitializeComponent();
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);

            Resize += (s, e) => AdjustHeaderWidths();
            AdjustHeaderWidths();

            // LicenseManager es fiable en constructores; DesignMode no lo es
            // porque el Site todavía no está asignado en este punto.
            if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                CargarDatosEjemplo();
        }

        // ── Datos de ejemplo ──────────────────────────────────────────────
        private void CargarDatosEjemplo()
        {
            var pedidos = new[]
            {
                new { Id = "#00123", Cliente = "Carlos M.", Total = "$85.000",  Estado = "Entregado" },
                new { Id = "#00124", Cliente = "Ana R.",    Total = "$132.000", Estado = "En camino" },
                new { Id = "#00125", Cliente = "Luis G.",   Total = "$47.500",  Estado = "Pendiente" }
            };

            ClearOrders();
            foreach (var p in pedidos)
                AddOrder(new OrderCard
                {
                    OrderId = p.Id,
                    Customer = p.Cliente,
                    Total = p.Total,
                    Status = p.Estado
                });
        }

        // ── API pública ───────────────────────────────────────────────────
        public void AddOrder(OrderCard order)
        {
            if (order == null) return;
            int w = flowPanel.Width - 25;
            order.Width = w > 0 ? w : 500;
            order.Margin = new Padding(0, 0, 0, 8);
            flowPanel.Controls.Add(order);
        }

        public void ClearOrders() => flowPanel.Controls.Clear();

        public FlowLayoutPanel OrdersContainer => flowPanel;

        // ── Header ────────────────────────────────────────────────────────
        private void AdjustHeaderWidths()
        {
            const int ml = 16, mt = 8, hh = 32;

            lblHeaderId.Size = new Size(_idWidth, hh);
            lblHeaderId.Location = new Point(ml, mt);

            lblHeaderCustomer.Size = new Size(_customerWidth, hh);
            lblHeaderCustomer.Location = new Point(ml + _idWidth + 8, mt);

            int safeWidth = Math.Max(Width, _statusWidth + _totalWidth + 32);

            lblHeaderTotal.Size = new Size(_totalWidth, hh);
            lblHeaderTotal.Location = new Point(safeWidth - (_statusWidth + _totalWidth + 16), mt);
            lblHeaderTotal.TextAlign = ContentAlignment.MiddleRight;

            lblHeaderStatus.Size = new Size(_statusWidth, hh);
            lblHeaderStatus.Location = new Point(safeWidth - _statusWidth - 16, mt);
        }

        // ── Propiedades ───────────────────────────────────────────────────
        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color HeaderBackColor
        {
            get => _headerBackColor;
            set { _headerBackColor = value; panelHeader.BackColor = value; }
        }
        private bool ShouldSerializeHeaderBackColor() => _headerBackColor != Color.FromArgb(248, 249, 252);
        private void ResetHeaderBackColor() => HeaderBackColor = Color.FromArgb(248, 249, 252);

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

        [Category("Layout"), DefaultValue(90)]
        public int IdColumnWidth
        {
            get => _idWidth;
            set { _idWidth = value; AdjustHeaderWidths(); }
        }

        [Category("Layout"), DefaultValue(200)]
        public int CustomerColumnWidth
        {
            get => _customerWidth;
            set { _customerWidth = value; AdjustHeaderWidths(); }
        }

        [Category("Layout"), DefaultValue(90)]
        public int TotalColumnWidth
        {
            get => _totalWidth;
            set { _totalWidth = value; AdjustHeaderWidths(); }
        }

        [Category("Layout"), DefaultValue(80)]
        public int StatusColumnWidth
        {
            get => _statusWidth;
            set { _statusWidth = value; AdjustHeaderWidths(); }
        }

        // ── Paint ─────────────────────────────────────────────────────────
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