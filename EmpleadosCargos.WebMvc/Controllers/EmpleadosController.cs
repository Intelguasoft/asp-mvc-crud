using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpleadosCargos.Core;
using EmpleadosCargos.DAL.EntityFramework;
using System.Globalization;

namespace EmpleadosCargos.WebMvc.Controllers
{
    public class EmpleadosController : Controller
    {
        private EmpleadosCargosDbContext db = new EmpleadosCargosDbContext();

        // GET: Empleados/Listar
        public ActionResult Listar()
        {
            var empleados = db.Empleados.Include(e => e.Cargo);
            return PartialView("_Listar", empleados.ToList());
        }

        // GET: Empleados/Cargar
        public ActionResult Cargar()
        {
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoID", "Nombre");
            return PartialView("_Cargar");
        }

        // POST: Empleados/Cargar
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cargar([Bind(Include = "EmpleadoID,Nombre,Apellido,FechaNacimiento,CargoId")] Empleado empleado)
        {
            empleado.FechaNacimiento.ToString("d", new CultureInfo("es-ES"));

            if (ModelState.IsValid)
            {
                db.Empleados.Add(empleado);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.CargoId = new SelectList(db.Cargos, "CargoID", "Nombre", empleado.CargoId);
            return RedirectToAction("Index", "Home");
        }

        // GET: Empleados/Detalles/5
        public ActionResult Detalles(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Include(e => e.Cargo).Where(e => e.EmpleadoID == (int)id).First();
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Detalles", empleado);
        }

        // GET: Empleados/Eliminar/5
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Eliminar", empleado);
        }

        // POST: Empleados/Eliminar/5
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmado(int id)
        {
            Empleado empleado = db.Empleados.Find(id);
            db.Empleados.Remove(empleado);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empleado empleado = db.Empleados.Find(id);
            if (empleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoID", "Nombre", empleado.CargoId);
            return View(empleado);
        }

        // POST: Empleados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpleadoID,Nombre,Apellido,FechaNacimiento,CargoId")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CargoId = new SelectList(db.Cargos, "CargoID", "Nombre", empleado.CargoId);
            return View(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
