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
    [Route("curriculos")]
    [ApiController]
    [EnableCors]
    public class CurriculosController : ControllerBase
    {
        private readonly DistribuidosContext context;

        public CurriculosController(DistribuidosContext context)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Curriculo>> GetVagas()
        {
            List<Curriculo> curriculos;

            try
            {
                curriculos = await context.Curriculos.ToListAsync();
                if (curriculos == null)
                    return new NotFoundResult();
                return new OkObjectResult(curriculos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Curriculo>> CreateVagas([FromBody] Curriculo novoCurriculo)
        {
            Curriculo curriculo;

            try
            {
                curriculo = new Curriculo()
                {
                    nome = novoCurriculo.nome,
                    area = novoCurriculo.area,
                    carga_horaria = novoCurriculo.carga_horaria,
                    contato = novoCurriculo.contato,
                    salario_pretendido = novoCurriculo.salario_pretendido
                };

                context.Curriculos.Add(curriculo);
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
