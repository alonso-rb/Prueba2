using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IEEE18mayo.Model;
using Microsoft.EntityFrameworkCore;

namespace IEEE18mayo
{
    public partial class frmInicioSesion : Form
    {
        public frmInicioSesion()
        {
            InitializeComponent();
        }

        private void btnCrearNuevo_Click(object sender, EventArgs e)
        {
            frmCrearUsuario ventana = new frmCrearUsuario();
            ventana.ShowDialog();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // obtengo todos los usuarios de mi tabla
            var db = new IEEEContext();
            List<Usuario> usuarios = db.Usuarios
                .Include(u => u.membresía)
                .ToList();

            // filtro solo el que me interesa
            string usuario = txtUsuario.Text;
            string contra = txtContraseña.Text;

            List<Usuario> resultado = usuarios
                .Where(u => u.usuario == usuario &&
                            u.contraseña == contra)
                .ToList();

            // si lo encontre, entonces pasar al siguiente formulario
            if (resultado.Count() > 0)
            {
                MessageBox.Show("Bienvenido!", "IEEE",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPrincipal ventana = new frmPrincipal(resultado[0]);
                ventana.Show();
                this.Hide();
            }
            // sino, mostrar un mensaje de error
            else
                MessageBox.Show("Usuario no existe!", "IEEE",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}