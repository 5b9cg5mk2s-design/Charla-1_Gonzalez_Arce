using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Charla_Programa_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInsegura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show(
                    "Ingrese un valor para realizar la prueba.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string entrada = txtUsuario.Text;

            string consulta =
                "SELECT * FROM Usuarios WHERE NombreUsuario = '"
                + entrada + "'";

            txtConsulta.Text = consulta;

            lblResultado.Text =
                "Consulta construida mediante concatenación. " +
                "La entrada del usuario forma parte directamente del código SQL, " +
                "por lo que este método es vulnerable.";
        }

        private void btnSegura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show(
                    "Ingrese un valor para realizar la prueba.",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            string consulta =
                "SELECT * FROM Usuarios WHERE NombreUsuario = @usuario";

            string parametro = txtUsuario.Text.Trim();

            txtConsulta.Text =
                "CONSULTA PARAMETRIZADA:" +
                Environment.NewLine +
                Environment.NewLine +
                consulta +
                Environment.NewLine +
                Environment.NewLine +
                "VALOR DEL PARÁMETRO @usuario:" +
                Environment.NewLine +
                parametro;

            lblResultado.Text =
                "Consulta segura. La entrada del usuario se maneja como un dato " +
                "independiente y no se concatena directamente al código SQL.";
        }

        private void btnAtaque_Click(object sender, EventArgs e)
        {
            txtUsuario.Text = "admin' OR '1'='1' --";

            txtConsulta.Clear();

            lblResultado.Text =
                "Se cargó una entrada típica utilizada para demostrar SQL Injection.";
        }
    }
}
