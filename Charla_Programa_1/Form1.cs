using System;
using System.Windows.Forms;

namespace Charla_Programa_1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();

            txtContrasena.UseSystemPasswordChar = true;
            txtConfirmarContrasena.UseSystemPasswordChar = true;

            txtContrasena.MaxLength = 20;
            txtConfirmarContrasena.MaxLength = 20;

            txtHash.ReadOnly = true;

            lblEstado.Text = "";
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Limpiar errores anteriores
            errorProvider1.Clear();
            lblEstado.Text = "";
            txtHash.Clear();

            bool hayError = false;

            // Validar usuario
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                errorProvider1.SetError(
                    txtUsuario,
                    "Debe ingresar un nombre de usuario."
                );

                hayError = true;
            }

            // Validar contraseña
            if (string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                errorProvider1.SetError(
                    txtContrasena,
                    "Debe ingresar una contraseña."
                );

                hayError = true;
            }
            else if (txtContrasena.Text.Length < 6)
            {
                errorProvider1.SetError(
                    txtContrasena,
                    "La contraseña debe tener al menos 6 caracteres."
                );

                hayError = true;
            }

            // Validar confirmación
            if (string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                errorProvider1.SetError(
                    txtConfirmarContrasena,
                    "Debe confirmar la contraseña."
                );

                hayError = true;
            }
            else if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                errorProvider1.SetError(
                    txtConfirmarContrasena,
                    "Las contraseñas no coinciden."
                );

                hayError = true;
            }

            // Si existe algún error, detener el registro
            if (hayError)
            {
                lblEstado.Text = "Corrija los campos indicados.";
                return;
            }

            try
            {
                // Convertir contraseña a Hash utilizando BCrypt
                string hash = BCrypt.Net.BCrypt.HashPassword(
                    txtContrasena.Text
                );

                // Crear usuario
                Usuario usuario = new Usuario
                {
                    NombreUsuario = txtUsuario.Text.Trim(),
                    PasswordHash = hash
                };

                // Mostrar solamente el hash
                txtHash.Text = usuario.PasswordHash;

                lblEstado.Text = "Usuario registrado correctamente.";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "Ocurrió un error durante el registro.";

                MessageBox.Show(
                    ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
            txtHash.Clear();

            lblEstado.Text = "";

            errorProvider1.Clear();

            txtUsuario.Focus();
        }
    }
}