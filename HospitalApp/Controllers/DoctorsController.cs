using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HospitalApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HospitalApp.Controllers
{
    public class DoctorsController : Controller
    {
        private hospitalContext db = new hospitalContext();

        public IActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Speciality).OrderBy(d => d.Speciality.SpecialityName);
            return View(doctors.ToList());
        }

        // GET: Doctors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return new NotFoundResult();
            }
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "SpecialityName", doctor.SpecialityId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "SpecialityName", doctor.SpecialityId);
            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "SpecialityName");
            return View();
        }

        // POST: Doctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpecialityId = new SelectList(db.Specialities, "SpecialityId", "SpecialityName", doctor.SpecialityId);
            return View(doctor);
        }
    }
}