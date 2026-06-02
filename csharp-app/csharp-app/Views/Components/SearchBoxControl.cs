using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class SearchBoxControl : UserControl
    {
        private string _placeholder = "Buscar productos...";
        private int _cornerRadius = 8;

        public event EventHandler SearchTextChanged;

        public SearchBoxControl()
        {
            InitializeComponent();
            ConfigurePlaceholder();
        }

        private void ConfigurePlaceholder()
        {
            if (txtSearch != null && string.IsNullOrEmpty(txtSearch.Text))
            {
                txtSearch.Text = _placeholder;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void TxtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == _placeholder)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void TxtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = _placeholder;
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != _placeholder)
                SearchTextChanged?.Invoke(this, EventArgs.Empty);
        }

        [Category("Appearance")]
        [DefaultValue("Buscar productos...")]
        public string Placeholder
        {
            get => _placeholder;
            set { _placeholder = value; ConfigurePlaceholder(); }
        }

        [Category("Appearance")]
        [DefaultValue(8)]
        public int CornerRadius
        {
            get => _cornerRadius;
            set { _cornerRadius = value; txtSearch.BorderRadius = value; }
        }

        public string SearchText => (txtSearch.Text == _placeholder) ? "" : txtSearch.Text;

        public void ResetSearch()
        {
            txtSearch.Text = _placeholder;
            txtSearch.ForeColor = Color.Gray;
        }
    }
}