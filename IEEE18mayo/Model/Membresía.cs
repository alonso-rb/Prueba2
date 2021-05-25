namespace IEEE18mayo.Model
{
    public class Membresía
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }

        public Membresía()
        {
        }

        public Membresía(string nombre, double precio)
        {
            this.nombre = nombre;
            this.precio = precio;
        }
    }
}