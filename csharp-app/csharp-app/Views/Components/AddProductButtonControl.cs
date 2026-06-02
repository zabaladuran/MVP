using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class AddProductButtonControl : UserControl
    {
        private string _buttonText = "Nuevo producto";
        private Color _buttonColor = Color.FromArgb(99, 102, 241);
        private Color _buttonHoverColor = Color.FromArgb(79, 82, 221);
        private int _cornerRadius = 8;
        private Size _customButtonSize = Size.Empty;  // Empty = usar Dock.Fill

        public event EventHandler ButtonClick;

        public AddProductButtonControl()
        {
            InitializeComponent();
            btnAdd.Click += BtnAdd_Click;
            ActualizarModoTamano();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            ButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void ActualizarModoTamano()
        {
            if (_customButtonSize != Size.Empty && _customButtonSize.Width > 0 && _customButtonSize.Height > 0)
            {
                btnAdd.Dock = DockStyle.None;
                btnAdd.Size = _customButtonSize;
                CentrarBoton();
            }
            else
            {
                btnAdd.Dock = DockStyle.Fill;
            }
        }

        private void CentrarBoton()
        {
            if (btnAdd.Dock == DockStyle.None)
            {
                int x = (Width - btnAdd.Width) / 2;
                int y = (Height - btnAdd.Height) / 2;
                btnAdd.Location = new Point(Math.Max(0, x), Math.Max(0, y));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (btnAdd.Dock == DockStyle.None)
                CentrarBoton();
        }

        [Category("Appearance")]
        [DefaultValue("Nuevo producto")]
        public string ButtonText
        {
            get => _buttonText;
            set { _buttonText = value; btnAdd.Text = value; }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public Color ButtonColor
        {
            get => _buttonColor;
            set { _buttonColor = value; btnAdd.FillColor = value; }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]

        public Color ButtonHoverColor
        {
            get => _buttonHoverColor;
            set { _buttonHoverColor = value; btnAdd.HoverState.FillColor = value; }
        }

        [Category("Appearance")]
        [DefaultValue(8)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; btnAdd.BorderRadius = value; }
        }

        // Propiedad principal: tamaño personalizado del botón
        [Category("Layout")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Size CustomButtonSize
        {
            get => _customButtonSize;
            set
            {
                _customButtonSize = value;
                ActualizarModoTamano();
                Invalidate();   // Forzar redibujo en diseñador
                if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                    this.Refresh();
            }
        }

        // Para que el diseñador guarde el valor solo si es diferente de vacío
        private bool ShouldSerializeCustomButtonSize()
        {
            return _customButtonSize != Size.Empty;
        }

        // Restablecer al modo "fill"
        private void ResetCustomButtonSize()
        {
            CustomButtonSize = Size.Empty;
        }
    }
}