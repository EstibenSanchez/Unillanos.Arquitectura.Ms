using System.Text.Json;

namespace Unillanos.ArquitecturaMs.Usuario.Modelo
{
    public class Usuarios
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string sexo { get; set; }
        public string correo { get; set; }
        public int telefono { get; set; }
        public int edad { get; set; }


        public string Json()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
