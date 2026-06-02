using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class DashboardHeaderControl : UserControl
    {
        private string _title = "Dashboard";
        private string _storeName = "Tienda Norte";
        private string _separator = " · ";
        private Color _titleColor = Color.FromArgb(30, 30, 40);
        private Font _titleFont = new Font("Segoe UI", 14F, FontStyle.Bold);

        public DashboardHeaderControl()
        {
            InitializeComponent();
            UpdateTitleText();
        }

        private void UpdateTitleText()
        {
            lblTitle.Text = $"{_title}{_separator}{_storeName}";
        }

        [Category("Appearance")]
        [DefaultValue("Dashboard")]
        public string Title
        {
            get => _title;
            set { _title = value; UpdateTitleText(); }
        }

        [Category("Appearance")]
        [DefaultValue("Tienda Norte")]
        public string StoreName
        {
            get => _storeName;
            set { _storeName = value; UpdateTitleText(); }
        }

        [Category("Appearance")]
        [DefaultValue(" · ")]
        public string Separator
        {
            get => _separator;
            set { _separator = value; UpdateTitleText(); }
        }


        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color TitleColor
        {
            get => _titleColor;
            set { _titleColor = value; lblTitle.ForeColor = value; }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font TitleFont
        {
            get => _titleFont;
            set { _titleFont = value; lblTitle.Font = value; }
        }

        // Método público para cambiar tienda desde fuera
        public void SetStore(string store)
        {
            StoreName = store;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}