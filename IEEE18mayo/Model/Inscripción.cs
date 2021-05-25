namespace IEEE18mayo.Model
{
    public class Inscripción
    {
        public int id { get; set; }
        public virtual Usuario usuario { get; set; }
        public virtual Curso curso { get; set; }

        public Inscripción()
        {
        }

        public Inscripción(Usuario usuario, Curso curso)
        {
            this.usuario = usuario;
            this.curso = curso;
        }
    }
}