using System;
using System.Linq;
using System.Windows.Forms;
using IEEE18mayo.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace IEEE18mayo
{
    public partial class frmInscripciones : Form
    {
        private Usuario usuario { get; set; }
        
        public frmInscripciones(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void frmInscripciones_Load(object sender, EventArgs e)
        {
            var db = new IEEEContext();
            cmbCursos.DataSource = db.Cursos.ToList();
            cmbCursos.DisplayMember = "nombre";
            cmbCursos.ValueMember = "id";
        }

        private void cmbCursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblDescripción.Text =
                ((Curso) cmbCursos.SelectedItem).descripcion;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnInscribir_Click(object sender, EventArgs e)
        {
            //Obtener el curso y el usuario "de referencia"
            // No son los objetos existentes en mi base
            // Si los utilizo, tal cual, EF querrá hacer
            // dos insert's adicionales
            Usuario uref = usuario;
            Curso cref = (Curso) cmbCursos.SelectedItem;
            
            //A partir de mis objetos de referencia
            // obtener los objetos existentes en mi BDD
            var db = new IEEEContext();
            Usuario ubdd = db.Set<Usuario>()
                .SingleOrDefault(u => u.id == uref.id);
            Curso cbdd = db.Set<Curso>()
                .SingleOrDefault(c => c.id == cref.id);

            //Crear nueva inscripción
            // y almacenarla en la base de datos
            Inscripción i = new Inscripción(ubdd, cbdd);
            db.Add(i);
            db.SaveChanges();

            //Notificarle al usuario y cerrar el formulario
            MessageBox.Show("Inscripción exitosa!", "IEEE",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
        }
    }
}