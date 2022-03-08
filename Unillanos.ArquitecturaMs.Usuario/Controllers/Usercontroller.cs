using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unillanos.ArquitecturaMs.Usuario.Modelo;
using Unillanos.ArquitecturaMs.Usuario.Servicios;

namespace Unillanos.ArquitecturaMs.Usuario.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class Usercontroller : ControllerBase
    {
        private UserServicio servicio = new UserServicio();

        [HttpGet]
        [Route("LeerPerfil/{nombre}")]
        public JsonResult Get(string nombre)
        {

            Usuarios user = servicio.get(nombre);
            if (user.nombre == null)
            {
                throw new Exception("No se encontró el usuario.");
            }
            {
                return new JsonResult(user);
            }

        }

        /* [HttpGet]
         [Route("Usuarios")]
         public List<UsuariosDto> GetUsers()
         {


         }*/

        [HttpPost]
        [Route("insertarusuario")]

        public string Post(Usuarios usuarios)
        {
            return servicio.PostUsers(usuarios);

        }

        [HttpDelete]
        [Route("eliminarusuario/{username}")]

        public string Delete(string username)
        {
            return servicio.delete(username);

        }

        [HttpPut]
        [Route("actualizarusuario/{username}")]

        public string Put(string username, Usuarios usuario)
        {
            return servicio.put(username, usuario);

        }

    }
}
