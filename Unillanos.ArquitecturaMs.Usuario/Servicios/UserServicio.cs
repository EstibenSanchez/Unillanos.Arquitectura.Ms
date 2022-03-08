using Newtonsoft.Json;
using System.Security.Authentication;
using Unillanos.ArquitecturaMs.Usuario.Modelo;

namespace Unillanos.ArquitecturaMs.Usuario.Servicios
{
    public class UserServicio
    {
        public Usuarios get(string username)
        {
            var fileName = "Usuarios.json";
            var json = System.IO.File.ReadAllText(fileName);
            var users = JsonConvert.DeserializeObject<List<Usuarios>>(json);
            var result = new Usuarios();
            foreach (var x in users)
            {
                if (x.nombre == username)
                {
                    result = x;
                    break;
                }
            }
            return result;
        }

        public List<Usuarios> GetUsers()
        {

            var fileName = "Usuarios.json";
            var json = System.IO.File.ReadAllText(fileName);
            var users = JsonConvert.DeserializeObject<List<Usuarios>>(json);
            return users;

        }

        public string PostUsers(Usuarios usuario)
        {
            var fileName = "Usuarios.json";
            var json = System.IO.File.ReadAllText(fileName);
            var usuarios = JsonConvert.DeserializeObject<List<Usuarios>>(json);
            usuarios.Add(usuario);
            var users = JsonConvert.SerializeObject(usuarios);
            System.IO.File.WriteAllText(fileName, users);
            return usuario.nombre;

        }

        public String delete(string username)
        {
            Usuarios existe = get(username);
            if (existe.nombre != null)
            {
                var fileName = "Usuarios.json";
                var json = System.IO.File.ReadAllText(fileName);
                var users = JsonConvert.DeserializeObject<List<Usuarios>>(json);
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].nombre == username)
                    {
                        users.RemoveAt(i);
                        break;
                    }
                }
                System.IO.File.WriteAllText(fileName, JsonConvert.SerializeObject(users));
                return "Se eliminó correctamente";
            }

            {
                throw new Exception("El usuario no se ecuentra en la BD.");
            }

        }

        public string put(string username, Usuarios usuario)
        {
            Usuarios existe = get(username);
            if (existe.nombre != null)
            {
                var fileName = "Usuarios.json";
                var json = System.IO.File.ReadAllText(fileName);
                var users = JsonConvert.DeserializeObject<List<Usuarios>>(json);
                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].nombre == username)
                    {
                        users[i].nombre = usuario.nombre;
                        users[i].apellido = usuario.apellido;
                        users[i].sexo = usuario.sexo;
                        users[i].correo = usuario.correo;
                        users[i].telefono = usuario.telefono;
                        users[i].edad = usuario.edad;
                        break;
                    }
                }
                System.IO.File.WriteAllText(fileName, JsonConvert.SerializeObject(users));
                return "Se actualizó correctamnte el usuario.";
            }
            {
                throw new AuthenticationException("El usuario no se ecuentra en la BD.");
            }

        }
    }
}
