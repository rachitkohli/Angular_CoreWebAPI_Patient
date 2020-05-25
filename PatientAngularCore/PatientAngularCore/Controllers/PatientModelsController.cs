using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientAngularCore.Model;

namespace PatientAngularCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientModelsController : ControllerBase
    {
        private readonly PatientDBContext _context;

        public PatientModelsController(PatientDBContext context)
        {
            _context = context;
        }

        [HttpGet("PatientQuery/{code}")]
        //[ActionName("PatientQuery")]
        //[Route("api/PatientQuery/{code}")]
        public async Task<ActionResult<IEnumerable<PatientModel>>> GetPatientByDisease(string code)
        {
            PatientQuery patientQuery = _context.PatientQueries.Where(qry => qry.disease.Code == code).FirstOrDefault();
            if (patientQuery == null) return null;
            return await _context.PatientModels.FromSqlRaw(patientQuery.Query).ToListAsync();
        }

        // GET: api/PatientModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientModel>>> GetPatientModels()
        {
            return await _context.PatientModels.ToListAsync();
        }

        // GET: api/PatientModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientModel>> GetPatientModel(int id)
        {
            var patientModel = await _context.PatientModels.FindAsync(id);

            if (patientModel == null)
            {
                return NotFound();
            }

            return patientModel;
        }

        // PUT: api/PatientModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientModel(int id, PatientModel patientModel)
        {
            if (id != patientModel.MRN)
            {
                return BadRequest();
            }

            _context.Entry(patientModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PatientModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<PatientModel>> PostPatientModel(PatientModel patientModel)
        {
            _context.PatientModels.Add(patientModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientModel", new { id = patientModel.MRN }, patientModel);
        }

        // DELETE: api/PatientModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PatientModel>> DeletePatientModel(int id)
        {
            var patientModel = await _context.PatientModels.FindAsync(id);
            if (patientModel == null)
            {
                return NotFound();
            }

            _context.PatientModels.Remove(patientModel);
            await _context.SaveChangesAsync();

            return patientModel;
        }

        private bool PatientModelExists(int id)
        {
            return _context.PatientModels.Any(e => e.MRN == id);
        }
    }
}
