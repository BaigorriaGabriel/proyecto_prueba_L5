using proyecto_prueba_L5.Domain;
using proyecto_prueba_L5.Repositories;
using System.Reflection;

namespace proyecto_prueba_L5.Services
{
    public class ClienteService
    {
        public Cliente AgregarCliente(Cliente cliente)
        {
            if (ClienteRepository.DniExiste(cliente.Dni))
            {
                throw new Exception("El DNI ya está registrado.");
            }


            if (ClienteRepository.EmailExiste(cliente.Email))
            {
                throw new Exception("El email ya está registrado.");
            }

            return cliente;
        }
    }
}
