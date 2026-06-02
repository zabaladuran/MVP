using System;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace csharp_app.Views
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            // Suscribir eventos de validación y cancelación
            btnGuardar.Click += BtnGuardar_Click;
            btnCancelar.Click += (s, e) => this.Close();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios (solo visual, sin SQL)
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                MessageBox.Show("El apellido es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtApellido.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                MessageBox.Show("El documento es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDocumento.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("El correo electrónico es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }
            if (txtPassword.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarPassword.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtNomenclatura.Text))
            {
                MessageBox.Show("La nomenclatura de la dirección es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomenclatura.Focus();
                return;
            }
            if (cmbDepartamento.SelectedItem == null || cmbDepartamento.Text == "Seleccionar departamento")
            {
                MessageBox.Show("Debe seleccionar un departamento.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDepartamento.Focus();
                return;
            }
            if (cmbMunicipio.SelectedItem == null || cmbMunicipio.Text == "Seleccionar municipio")
            {
                MessageBox.Show("Debe seleccionar un municipio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMunicipio.Focus();
                return;
            }
            // Validar datos de la tienda
            if (string.IsNullOrWhiteSpace(txtNombreComercial.Text))
            {
                MessageBox.Show("El nombre comercial de la tienda es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreComercial.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtCorreoTienda.Text))
            {
                MessageBox.Show("El correo de atención de la tienda es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreoTienda.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTelefonoTienda.Text))
            {
                MessageBox.Show("El teléfono de atención de la tienda es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefonoTienda.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtRazonSocial.Text))
            {
                MessageBox.Show("La razón social de la tienda es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRazonSocial.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTiendaNomenclatura.Text))
            {
                MessageBox.Show("La nomenclatura de la dirección de la tienda es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTiendaNomenclatura.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTiendaBarrio.Text))
            {
                MessageBox.Show("El barrio de la dirección de la tienda es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTiendaBarrio.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtTiendaCodigoPostal.Text))
            {
                MessageBox.Show("El código postal de la tienda es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTiendaCodigoPostal.Focus();
                return;
            }
            if (cmbTiendaDepartamento.SelectedItem == null || cmbTiendaDepartamento.Text == "Departamento *")
            {
                MessageBox.Show("Debe seleccionar un departamento para la tienda.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTiendaDepartamento.Focus();
                return;
            }
            if (cmbTiendaMunicipio.SelectedItem == null || cmbTiendaMunicipio.Text == "Municipio *")
            {
                MessageBox.Show("Debe seleccionar un municipio para la tienda.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTiendaMunicipio.Focus();
                return;
            }
            if (cmbPlan.SelectedItem == null || cmbPlan.Text == "Plan de suscripción")
            {
                MessageBox.Show("Debe seleccionar un plan de suscripción.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPlan.Focus();
                return;
            }

            // Si todo está correcto, mostrar mensaje de éxito (simulación)
            MessageBox.Show("Registro completado (simulación). Los datos se guardarán en la base de datos.",
                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}