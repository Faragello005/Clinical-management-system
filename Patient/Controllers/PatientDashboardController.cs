using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatientDashboardAPI.Data;
using PatientDashboardAPI.Models;

namespace PatientDashboardAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientDashboardController : ControllerBase
    {
        private readonly PatientDashboardContext _context;

        public PatientDashboardController(PatientDashboardContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetPatientDashboard(int id)
        {
            var patient = _context.Patients
                .Include(p => p.Appointments)
                .Include(p => p.MedicalRecords)
                .FirstOrDefault(p => p.Id == id);

            if (patient == null)
                return NotFound();

            return Ok(patient);
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePatientInfo(int id, Patient updated)
        {
            var patient = _context.Patients.Find(id);
            if (patient == null)
                return NotFound();

            patient.Phone = updated.Phone;
            patient.Address = updated.Address;

            _context.SaveChanges();
            return Ok(patient);
        }
    }
}
