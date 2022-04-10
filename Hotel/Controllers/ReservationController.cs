using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hotel.Controllers
{
    public class ReservationController : Controller
    {
        ApplicationDbContext context;
        public ReservationController()
        {
            context= new ApplicationDbContext();
        }       
        // GET: Reservation
        public ActionResult Index()
        {
            return View(context.Reservation.ToList());
        }
        public ActionResult Create()
        {
            List<SelectListItem> rooms = new List<SelectListItem>();
            rooms.Add(new SelectListItem() { Text ="Room", Value = "Room"});
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ReservationViewModel model)
        {
            if(ModelState.IsValid)
            {
                ReservationModel obj = new ReservationModel() { Name = model.Name, Email = model.Email, ArriveDateTime = model.ArriveDateTime, DepartureDateTime = model.DepartureDateTime, Room = model.Room, NumberOfPeople=model.NumberOfPeople  };
                context.Reservation.Add(obj);
                await context.SaveChangesAsync();
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
            var reservationModel = context.Reservation.Find(id);
            if (reservationModel == null)
            {
                return HttpNotFound();
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
            return View(new ReservationViewModel());
        }

        // POST: ReservationModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Email,ArriveDateTime,DepartureDateTime,Room,NumberOfPeople")] ReservationViewModel reservationModel)
        {
            if (ModelState.IsValid)
            {
                context.Entry(reservationModel).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reservationModel);
        }
    }
}