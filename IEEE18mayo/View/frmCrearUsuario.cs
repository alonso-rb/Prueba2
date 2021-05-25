using System;
using System.Linq;
using System.Windows.Forms;
using IEEE18mayo.Model;
using Microsoft.EntityFrameworkCore;

namespace IEEE18mayo
{
    public partial class frmCrearUsuario : Form
    {
        public frmCrearUsuario()
        {
            InitializeComponent();
        }

        private void frmCrearUsuario_Load(object sender, EventArgs e)
        {
            var db = new IEEEContext();
            cmbMembresía.DataSource = db.Membresías.ToList();
            cmbMembresía.DisplayMember = "nombre";
            cmbMembresía.ValueMember = "id";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCrearUsuario_Click(object sender, EventArgs e)
        {
            bool validaciones =
                txtUsuario.Text.Length > 5 &&
                txtContra1.Text.Length > 5 &&
                (txtContra1.Text == txtContra2.Text);

            if (validaciones) //procedo a crear usuario
            {
                // Obtengo datos y la membresía de referencia
                string usuario = txtUsuario.Text.Trim();
                string contra = txtContra1.Text;
                Membresía mref = (Membresía) cmbMembresía.SelectedItem;

                // Teniendo como base la membresía de referencia
                // obtener la membresía que está en la BDD
                var db = new IEEEContext();
                Membresía mbdd = db.Set<Membresía>()
                    .SingleOrDefault(m => m.id == mref.id);
                
                // Crear usuario y almacenar en la BDD
                Usuario u = new Usuario(usuario, contra, mbdd);
                db.Add(u);
                db.SaveChanges();
                
                // Notificar al usuario
                MessageBox.Show("Usuario creado exitosamente!", "IEEE",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else//datos no válidos
                MessageBox.Show("Datos inválidos!", "IEEE",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}