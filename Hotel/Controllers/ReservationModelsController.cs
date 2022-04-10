using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hotel.Models;

namespace Hotel.Controllers
{
    public class ReservationModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReservationModels
        public ActionResult Index()
        {
            return View(db.Reservation.ToList());
        }

        // GET: ReservationModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = db.Reservation.Find(id);
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // GET: ReservationModels/Create
        public ActionResult Create()
        {
            List<SelectListItem> rooms = new List<SelectListItem>();
            rooms.Add(new SelectListItem() { Text = "Room", Value = "Room" });
            rooms.Add(new SelectListItem() { Text = "Standard Double Room", Value = "Standard Double Room" });
            rooms.Add(new SelectListItem() { Text = "Standard Family Room", Value = "Standard Family Room" });
            rooms.Add(new SelectListItem() { Text = "Garden Family Room", Value = "Garden Family Room" });
            rooms.Add(new SelectListItem() { Text = "Deluxe Double Room", Value = "Deluxe Double Room" });
            rooms.Add(new SelectListItem() { Text = "Executive Double Room", Value = "Executive Double Room" });
            rooms.Add(new SelectListItem() { Text = "Maisonette", Value = "Maisonette" });
            ViewBag.rooms = rooms;
            List<SelectListItem> peoples = new List<SelectListItem>();
            peoples.Add(new SelectListItem() { Text = "Persons", Value = "0" });
            peoples.Add(new SelectListItem() { Text = "1 Persons", Value = "1" });
            peoples.Add(new SelectListItem() { Text = "2 Persons", Value = "2" });
            peoples.Add(new SelectListItem() { Text = "3 Persons", Value = "3" });
            peoples.Add(new SelectListItem() { Text = "4 Persons", Value = "4" });
            peoples.Add(new SelectListItem() { Text = "5 Persons", Value = "5" });
            peoples.Add(new SelectListItem() { Text = "More", Value = "6" });
            ViewBag.peoples = peoples;
            return View(new ReservationViewModel());
        }

        // POST: ReservationModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Email,ArriveDateTime,DepartureDateTime,Room,NumberOfPeople")] ReservationModel reservationModel, ReservationViewModel model)
        {
            if (ModelState.IsValid)
            {
                db.Reservation.Add(reservationModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            List<SelectListItem> rooms = new List<SelectListItem>();
            rooms.Add(new SelectListItem() { Text = "Room", Value = "Room" });
            rooms.Add(new SelectListItem() { Text = "Standard Double Room", Value = "Standard Double Room" });
            rooms.Add(new SelectListItem() { Text = "Standard Family Room", Value = "Standard Family Room" });
            rooms.Add(new SelectListItem() { Text = "Garden Family Room", Value = "Garden Family Room" });
            rooms.Add(new SelectListItem() { Text = "Deluxe Double Room", Value = "Deluxe Double Room" });
            rooms.Add(new SelectListItem() { Text = "Executive Double Room", Value = "Executive Double Room" });
            rooms.Add(new SelectListItem() { Text = "Maisonette", Value = "Maisonette" });
            ViewBag.rooms = rooms;
            List<SelectListItem> peoples = new List<SelectListItem>();
            peoples.Add(new SelectListItem() { Text = "Persons", Value = "0" });
            peoples.Add(new SelectListItem() { Text = "1 Persons", Value = "1" });
            peoples.Add(new SelectListItem() { Text = "2 Persons", Value = "2" });
            peoples.Add(new SelectListItem() { Text = "3 Persons", Value = "3" });
            peoples.Add(new SelectListItem() { Text = "4 Persons", Value = "4" });
            peoples.Add(new SelectListItem() { Text = "5 Persons", Value = "5" });
            peoples.Add(new SelectListItem() { Text = "More", Value = "6" });
            ViewBag.peoples = peoples;
            return View(model);
        }

        // GET: ReservationModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = db.Reservation.Find(id);
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // POST: ReservationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,ArriveDateTime,DepartureDateTime,Room,NumberOfPeople")] ReservationModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservationModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservationModel);
        }

        // GET: ReservationModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservationModel reservationModel = db.Reservation.Find(id);
            if (reservationModel == null)
            {
                return HttpNotFound();
            }
            return View(reservationModel);
        }

        // POST: ReservationModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservationModel reservationModel = db.Reservation.Find(id);
            db.Reservation.Remove(reservationModel);
            db.SaveChanges();
            return RedirectToAction("Index");
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
