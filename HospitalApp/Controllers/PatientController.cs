using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalApp.Models;

namespace HospitalApp.Controllers
{
    [Route("api/patients")]
    public class PatientController : Controller
    {
        hospitalContext db;

        public PatientController(hospitalContext context)
        {
            db = context;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return db.Patients.ToList();
        }

        [HttpGet("{id}")]
        public Patient Get(int id)
        {
            Patient patient = db.Patients.FirstOrDefault(x => x.PatientId == id);
            return patient;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return Ok(patient);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Update(patient);
                db.SaveChanges();
                return Ok(patient);
            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Patient patient = db.Patients.FirstOrDefault(x => x.PatientId == id);
            if (patient != null)
            {
                db.Patients.Remove(patient);
                db.SaveChanges();
            }
            return Ok(patient);
        }
    }
}