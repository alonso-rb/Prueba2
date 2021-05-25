using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IEEE18mayo.Model;
using Microsoft.EntityFrameworkCore;

namespace IEEE18mayo
{
    public partial class frmPrincipal : Form
    {
        private Usuario usuario { get; set; }
        
        public frmPrincipal(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblBienvenida.Text = "Bienvenido: " + usuario.usuario;
            cargarCursos();
        }

        private void cargarCursos()
        {
            // Obtener las inscripciones de la BDD
            // (con todo y las referencias a usuario y curso)
            var db = new IEEEContext();
            var listaInscripciones = db.Inscripciones
                .Include(i => i.usuario)
                .Include(i => i.curso)
                .OrderBy(i => i.id)
                .ToList();

            // Filtrar solo las inscripciones de mí usuario
            var filtro = listaInscripciones
                .Where(i => i.usuario.id.Equals(usuario.id))
                .ToList();

            // Obtener los cursos de las inscripciones del paso anterior
            List<Curso> misCursos = new List<Curso>();
            foreach (Inscripción inscripción in filtro)
            {
                misCursos.Add(inscripción.curso);
            }

            // Mostrar los cursos en el Data Grid View
            dgvCursos.DataSource = null;
            dgvCursos.DataSource = misCursos;
        }

        private void inscripcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInscripciones ventana = new frmInscripciones(usuario);
            ventana.ShowDialog();
            cargarCursos();
        }
    }
}