using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charla_Programa_3
{
    public partial class Form1 : Form
    {
        private Usuario usuarioActual;
        public Form1()
        {
            InitializeComponent();

            cmbRol.Items.Add("Administrador");
            cmbRol.Items.Add("Usuario");

            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;

            lblEstado.Text = "";

            btnVerPerfil.Enabled = false;
            btnEditarPerfil.Enabled = false;
            btnEliminarUsuarios.Enabled = false;
        }
        private void AplicarPermisos(Usuario usuario)
        {
            btnVerPerfil.Enabled = true;
            btnEditarPerfil.Enabled = true;

            if (usuario.EsAdministrador())
            {
                btnEliminarUsuarios.Enabled = true;
            }
            else
            {
                btnEliminarUsuarios.Enabled = false;
            }
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            lblEstado.Text = "";

            bool hayErrores = false;


            // VALIDAR NOMBRE
            if (!Validaciones.NombreValido(txtNombre.Text))
            {
                errorProvider1.SetError(
                    txtNombre,
                    "Debe ingresar un nombre."
                );

                hayErrores = true;
            }


            // VALIDAR EDAD
            int edad;

            if (!Validaciones.EdadValida(txtEdad.Text, out edad))
            {
                errorProvider1.SetError(
                    txtEdad,
                    "Ingrese una edad válida entre 18 y 100 años."
                );

                hayErrores = true;
            }


            // VALIDAR CORREO
            if (!Validaciones.CorreoValido(txtCorreo.Text))
            {
                errorProvider1.SetError(
                    txtCorreo,
                    "Ingrese un correo válido."
                );

                hayErrores = true;
            }


            // VALIDAR ROL
            if (cmbRol.SelectedIndex == -1)
            {
                errorProvider1.SetError(
                    cmbRol,
                    "Debe seleccionar un rol."
                );

                hayErrores = true;
            }


            // DETENER SI EXISTEN ERRORES
            if (hayErrores)
            {
                lblEstado.Text =
                    "Corrija los campos indicados antes de continuar.";

                return;
            }


            // CREAR USUARIO
            usuarioActual = new Usuario(
                txtNombre.Text.Trim(),
                edad,
                txtCorreo.Text.Trim(),
                cmbRol.SelectedItem.ToString()
            );


            // APLICAR PERMISOS
            AplicarPermisos(usuarioActual);


            lblEstado.Text =
                "Acceso concedido. Rol: " + usuarioActual.Rol;
        }

        private void btnVerPerfil_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show(
                    "No existe un usuario validado."
                );

                return;
            }

            MessageBox.Show(
                "Nombre: " + usuarioActual.Nombre +
                Environment.NewLine +
                "Edad: " + usuarioActual.Edad +
                Environment.NewLine +
                "Correo: " + usuarioActual.Correo +
                Environment.NewLine +
                "Rol: " + usuarioActual.Rol,
                "Perfil del usuario",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnEditarPerfil_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show(
                    "No existe un usuario validado."
                );

                return;
            }

            MessageBox.Show(
                "Permiso concedido para editar el perfil propio.",
                "Acceso permitido",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnEliminarUsuarios_Click(object sender, EventArgs e)
        {
            if (usuarioActual == null)
            {
                MessageBox.Show(
                    "No existe un usuario validado."
                );

                return;
            }

            if (!usuarioActual.EsAdministrador())
            {
                MessageBox.Show(
                    "Acceso denegado. Esta acción requiere privilegios de Administrador.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            MessageBox.Show(
                "Acceso permitido. El Administrador puede gestionar usuarios.",
                "Acceso autorizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtEdad.Clear();
            txtCorreo.Clear();

            cmbRol.SelectedIndex = -1;

            lblEstado.Text = "";

            errorProvider1.Clear();

            usuarioActual = null;

            btnVerPerfil.Enabled = false;
            btnEditarPerfil.Enabled = false;
            btnEliminarUsuarios.Enabled = false;

            txtNombre.Focus();
        }
    }
}
