using proyecto_prueba_L5.Domain;

namespace proyecto_prueba_L5.Repositories
{
    public static class ClienteRepository
    {
        public static List<Cliente> _clientes = new List<Cliente>();

        public static void Agregar(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public static List<Cliente> ObtenerTodos()
        {
            return _clientes;
        }

        public static bool DniExiste(string dni)
        {
            return _clientes.Any(c => c.Dni == dni);
        }

        public static bool EmailExiste(string email)
        {
            return _clientes.Any(c=>c.Email == email);
        }
    }
}
