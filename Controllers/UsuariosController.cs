using Microsoft.AspNetCore.Mvc;
using ApiCadastroUsuarios.Models;

namespace ApiCadastroUsuarios.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private static List<Usuario> usuarios = new List<Usuario>();

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            return usuarios;
        }

        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            usuario.Id = usuarios.Count + 1;
            usuarios.Add(usuario);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Usuario usuarioAtualizado)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound();

            usuario.Nome = usuarioAtualizado.Nome;
            usuario.Email = usuarioAtualizado.Email;

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null) return NotFound();

            usuarios.Remove(usuario);
            return NoContent();
        }
    }
}

