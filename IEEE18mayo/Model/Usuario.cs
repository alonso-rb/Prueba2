namespace IEEE18mayo.Model
{
    public class Usuario
    {
        public int id { get; set; }
        public string usuario { get; set; }
        public string contraseña { get; set; }
        public virtual Membresía membresía { get; set; }

        public Usuario()
        {
        }

        public Usuario(string usuario, string contraseña, Membresía membresía)
        {
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.membresía = membresía;
        }
    }
}