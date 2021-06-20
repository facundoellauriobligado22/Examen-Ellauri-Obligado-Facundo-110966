using Api.Resultados;
using Api.Models;
using Api.Comandos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;
using System.Linq;

namespace Controllers
{
    [ApiController]
    [EnableCors("Prog3")]

    public class socioController : ControllerBase
    {
        private readonly parcialProg3SociosContext db = new parcialProg3SociosContext();
        private readonly ILogger<socioController> _logger;
        public socioController(ILogger<socioController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("Socio/CargarSocio")]
        public ActionResult<ResultadoAPI> AltaSocio([FromBody] ComandoCrearSocio comando)

        {
            ResultadoAPI resultado = new ResultadoAPI();


            if (comando.nombre.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese nombre ";
                return resultado;
            }
            if (comando.apellido.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese apellido";
                return resultado;
            }
            if (comando.calle.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese calle";
                return resultado;
            }
            if (comando.numero.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese numero";
                return resultado;
            }

            if (comando.idDeporte.Equals(""))
            {
                resultado.Ok = false;
                resultado.Error = "Ingrese deporte";
                return resultado;
            }

            Socio s = new Socio();

            s.Nombre = comando.nombre;
            s.Apellido = comando.apellido;
            s.Calle = comando.calle;
            s.Numero = comando.numero;
            s.IdDeporte = comando.idDeporte;

            db.Socios.Add(s);
            db.SaveChanges();

            resultado.Ok = true;
            resultado.Return = db.Socios.ToList();

            return resultado;

        }

        [HttpGet]
        [Route("Socio/BuscarSocio")]
        public ActionResult<ResultadoAPI> BuscarSocio()
        {
            ResultadoAPI resultado = new ResultadoAPI();

            var so = db.Socios.ToList();
            resultado.Ok = true;
            resultado.Return = so;

            resultado.Ok = false;
            resultado.Error = "Algo salió mal al recuperar los deportes...";

            return resultado;
        }
    }
}