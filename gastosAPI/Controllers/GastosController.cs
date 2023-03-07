using gastosAPI.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gastosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GastosController : ControllerBase
    {
        private readonly GastosContext _gastosContext;
        public GastosController(GastosContext context)
        {
            this._gastosContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Gasto>>> GetGastos()
        {
            if (_gastosContext.Gastos == null)
            {
                return NotFound();
            }
            else
            {
                return await _gastosContext.Gastos.ToListAsync();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gasto>> GetGastoId(int id)
        {
            if (_gastosContext.Gastos == null)
            {
                return NotFound();
            }
            else
            {
                var gasto = await _gastosContext.Gastos.FindAsync(id);
                if (gasto == null)
                {
                    return NotFound();
                }
                return gasto;
            }
        }

        [HttpPost]

        public async Task<ActionResult<Gasto>> PostGasto(Gasto gasto)
        {
            _gastosContext.Gastos.Add(gasto);
            await _gastosContext.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGasto(int id, Gasto gasto)
        {
            _gastosContext.Entry(gasto).State = EntityState.Modified;

            try
            {
                await _gastosContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGasto(int id)
        {
            var gasto = await _gastosContext.Gastos.FindAsync(id);
            if(gasto == null)
            {
                return NotFound();
            }

            _gastosContext.Gastos.Remove(gasto);

            await _gastosContext.SaveChangesAsync();

            return Ok();
        }
    }
}
