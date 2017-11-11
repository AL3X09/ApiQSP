using ApiQSP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiQSP.Controllers
{
    public class RegistroUsuariosController : ApiController
    {
        BD_QuiensepegaConexion bd = new BD_QuiensepegaConexion();

        public RegistroUsuariosController()
        {
        }

        // POST: api/Registro/Usuarios
        [ResponseType(typeof(RegistroUsuarioModel))]
        [Route("api/Registro/Usuarios")]
        public async Task<IHttpActionResult> RegistroUsuario(RegistroUsuarioModel usuario)
        {
            IHttpActionResult respond;
            try
            {
                if (!ModelState.IsValid)
                {
                    //return BadRequest(ModelState);
                    respond = Json(ModelState);
                }

                Object result = bd.SP_Registro(usuario.Email, usuario.Password, usuario.Nombres, usuario.Apellidos, usuario.Telefono, "/img/avatar.jpg", 1, 2);

                await bd.SaveChangesAsync();
                if (result.Equals(string.Empty))
                    respond = StatusCode(HttpStatusCode.NotFound);
                else
                {
                    respond = Json(content: result);
                }

            }
            catch (DbUpdateConcurrencyException e)
            {
                respond = BadRequest(e.Message);
                //return WebResponse(HttpStatusCode.NoContent, e.Message);
            }
            return respond;
        }

    }
}
