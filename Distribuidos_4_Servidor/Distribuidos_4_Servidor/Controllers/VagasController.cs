using Distribuidos.Persistence;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distribuidos.API.Controllers
{
    [Route("vagas")]
    [ApiController]
    [EnableCors]
    public class VagasController : ControllerBase
    {
        private readonly DistribuidosContext context;

        public VagasController(DistribuidosContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Empresa>> GetVagas()
        {
            List<Empresa> vagas;

            try {
                vagas = await context.Vagas.ToListAsync();
                if (vagas == null)
                    return new NotFoundResult();
                return new OkObjectResult(vagas);
            }
            catch {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Empresa>> CreateVagas([FromBody] Empresa novaEmpresa)
        {
            Empresa vaga;

            try
            {
                vaga = new Empresa()
                {
                    nomeEmpresa = novaEmpresa.nomeEmpresa,
                    areaVaga = novaEmpresa.areaVaga,
                    cargaHorariaVaga = novaEmpresa.cargaHorariaVaga,
                    emailEmpresa = novaEmpresa.emailEmpresa,
                    salarioVaga = novaEmpresa.salarioVaga
                };

                context.Vagas.Add(vaga);
                await context.SaveChangesAsync();
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
