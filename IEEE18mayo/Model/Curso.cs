namespace IEEE18mayo.Model
{
    public class Curso
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }

        public Curso()
        {
        }

        public Curso(string nombre, string descripcion)
        {
            this.nombre = nombre;
            this.descripcion = descripcion;
        }
    }
}