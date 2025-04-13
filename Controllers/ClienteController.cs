using Microsoft.AspNetCore.Mvc;
using proyecto_prueba_L5.Domain;
using proyecto_prueba_L5.Models;
using proyecto_prueba_L5.Repositories;
using proyecto_prueba_L5.Services;

namespace proyecto_prueba_L5.Controllers
{
    public class ClienteController : Controller
    {
        // Mostrar el formulario de alta
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }

        // Recibir datos del formulario y crear cliente
        [HttpPost]
        public IActionResult Agregar(AgregarClienteViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);


            //TODA ESTA LOGICA TIENE QUE ESTAR EN UN SERVICIO DONDE AHI SE VALIDE SI LOS DATOS SON APTOS PARA UN CLIENTE
            //SI SON VALIDOS, DEVUELVE EL OBJETO COMPLETO Y EN ESTA FUNCION  SE AGREGA.
            //SI EL DIA DE MAÑANA QUIERO EMPEZAR A CARGAR LOS CLIENTES POR CONSOLA, TENGO QUE COPIAR TODA ESTA LOGICA EN EL MAIN DE LA CONSOLA
            /*
            var cliente = new Cliente(
                model.Nombre,
                model.Apellido,
                model.Email,
                model.Password
            );

            if(ClienteRepository.EmailExiste(model.Email))
            {
                ModelState.AddModelError("Email", "Ya existe un cliente con ese email");
                return View();
            }
            */



            try
            {
                var clienteServicio = new ClienteService();

                var cliente = new Cliente(
                    model.Nombre,
                    model.Apellido,
                    model.Dni,
                    model.Email,
                    model.Password
                );

                var clienteCreado = clienteServicio.AgregarCliente(cliente);

                ClienteRepository.Agregar(clienteCreado);

                return Redirect("Confirmacion");
            }

            catch (Exception ex)
            {
                //if(ex.Message.ToLower.Contains)

                ModelState.AddModelError(nameof(model.Email), ex.Message);
                return View(model);
            }
                        
        }

        public IActionResult Confirmacion()
        {
            return View();
        }

        public IActionResult Lista()
        {
            var clientes = ClienteRepository.ObtenerTodos();
            return View(clientes);
        }
    }
}
