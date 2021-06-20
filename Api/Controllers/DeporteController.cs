using Api.Resultados;
using Api.Comandos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Api.Models;
using Microsoft.AspNetCore.Cors;
using System.Linq;

namespace Controllers
{
    [ApiController]
    [EnableCors("Prog3")]

    public class DeporteController : ControllerBase
    {
        private readonly parcialProg3SociosContext db = new parcialProg3SociosContext();
        private readonly ILogger<DeporteController> _logger;
        public DeporteController(ILogger<DeporteController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("Deporte/ObtenerDeporte")]
        public ActionResult<ResultadoAPI> ObtenerDeportes()
        {
            ResultadoAPI resultado = new ResultadoAPI();

            var depor = db.Deportes.ToList();
            resultado.Ok = true;
            resultado.Return = depor;

            resultado.Ok = false;
            resultado.Error = "Algo salió mal al recuperar los deportes...";

            return resultado;
        }
    }
}