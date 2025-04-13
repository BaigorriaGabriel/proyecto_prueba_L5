namespace proyecto_prueba_L5.Domain
{
    public class Cliente
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Dni { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }

        public Cliente(string nombre, string apellido, string email, string dni, string passwordPlano)
        {
            if (string.IsNullOrWhiteSpace(nombre)) throw new ArgumentException("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(apellido)) throw new ArgumentException("El apellido es obligatorio.");
            if (string.IsNullOrWhiteSpace(dni)) throw new ArgumentException("El DNI es obligatorio.");
            if (!email.Contains("@")) throw new ArgumentException("El email no es válido.");
            if (string.IsNullOrWhiteSpace(passwordPlano)) throw new ArgumentException("La clave es obligatoria.");

            Id = Guid.NewGuid();
            Nombre = nombre;
            Apellido = apellido;
            Dni = dni;
            Email = email;
            PasswordHash = passwordPlano;
        }
    }
}
