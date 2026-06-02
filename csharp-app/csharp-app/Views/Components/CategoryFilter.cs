using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace csharp_app.Views.Components
{
    [ToolboxItem(true)]
    public partial class CategoryFilter : UserControl
    {
        private string _comboText = "Todas las categorías";

        public event EventHandler SelectedCategoryChanged;
        public event EventHandler AllButtonClicked;

        public CategoryFilter()
        {
            InitializeComponent();
            cmbCategories.Text = _comboText;
        }

        private void CmbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCategoryChanged?.Invoke(this, EventArgs.Empty);
        }

        private void BtnAll_Click(object sender, EventArgs e)
        {
            // Al hacer clic en "Todos", resetea el combo al primer elemento (si lo hay)
            if (cmbCategories.Items.Count > 0)
                cmbCategories.SelectedIndex = 0;
            else
                cmbCategories.Text = _comboText;
            AllButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        [Category("Appearance")]
        [DefaultValue("Todas las categorías")]
        public string ComboDefaultText
        {
            get => _comboText;
            set { _comboText = value; cmbCategories.Text = value; }
        }

  

        public string SelectedCategory => cmbCategories.SelectedItem?.ToString() ?? cmbCategories.Text;
        public void SetCategories(string[] categories)
        {
            cmbCategories.Items.Clear();
            cmbCategories.Items.AddRange(categories);
            if (categories.Length > 0)
                cmbCategories.SelectedIndex = 0;
            else
                cmbCategories.Text = _comboText;
        }
        public void ResetFilter()
        {
            if (cmbCategories.Items.Count > 0)
                cmbCategories.SelectedIndex = 0;
            else
                cmbCategories.Text = _comboText;
        }
    }
}