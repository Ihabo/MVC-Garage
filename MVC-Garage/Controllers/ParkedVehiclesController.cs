using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_Garage.DataAccessLayer;
using MVC_Garage.Models;

namespace MVC_Garage.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private GarageContext db = new GarageContext();
      
        // GET: ParkedVehicles



        public ActionResult Index()
        {
            

            List<Overview> ov = new List<Overview>();
            foreach (ParkedVehicle o in db.ParkedVehicles.ToList())
            {
                ov.Add(new Overview(o));
            }
            return View(ov);
        }


        public ActionResult Index1(string sortOrder)
        {


            ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            ViewBag.RegNrSortParm = String.IsNullOrEmpty(sortOrder) ? "RegNr_desc" : "RegNr";
            ViewBag.ColorSortParm = String.IsNullOrEmpty(sortOrder) ? "Color_desc" : "Color";
            ViewBag.TimeSortParm = sortOrder == "Time" ? "time_desc" : "Time";

            var vehicle = from v in db.ParkedVehicles
                          select v;

            switch (sortOrder)

            {
                case "type_desc":
                    vehicle = vehicle.OrderByDescending(v => v.VehicleType);
                    break;
                case "Time":
                    vehicle = vehicle.OrderBy(v => v.ParkedTime);
                    break;
                case "time_desc":
                    vehicle = vehicle.OrderByDescending(v => v.ParkedTime);
                    break;
                case "RegNr":
                    vehicle = vehicle.OrderBy(v => v.RegNum);
                    break;
                case "RegNr_desc":
                    vehicle = vehicle.OrderByDescending(v => v.RegNum);
                    break;

                case "Color":
                    vehicle = vehicle.OrderBy(v => v.Color);
                    break;
                case "Color_desc":
                    vehicle = vehicle.OrderByDescending(v => v.Color);
                    break;
                default:
                    vehicle = vehicle.OrderBy(v => v.VehicleType);
                    break;
            }

            return View(vehicle.ToList());

        }

        public ActionResult Search(string search,string sortOrder)
        {
          
            //ViewBag.TypeSortParm = String.IsNullOrEmpty(sortOrder) ? "type_desc" : "";
            //ViewBag.RegNrSortParm = String.IsNullOrEmpty(sortOrder) ? "RegNr_desc" : "RegNr";
            //ViewBag.ColorSortParm = String.IsNullOrEmpty(sortOrder) ? "Color_desc" : "Color";
            //ViewBag.TimeSortParm = sortOrder == "Time" ? "time_desc" : "Time";

            var vehicle = from v in db.ParkedVehicles
                          select v;
            vehicle= vehicle.Where(v => v.RegNum.Contains(search) || search == null);
           
            //switch (sortOrder)

            //{
            //    case "type_desc":
            //        vehicle = vehicle.OrderByDescending(v => v.VehicleType);
            //        break;
            //    case "Time":
            //        vehicle = vehicle.OrderBy(v => v.ParkedTime);
            //        break;
            //    case "time_desc":
            //        vehicle = vehicle.OrderByDescending(v => v.ParkedTime);
            //        break;
            //    case "RegNr":
            //        vehicle = vehicle.OrderBy(v => v.RegNum);
            //        break;
            //    case "RegNr_desc":
            //        vehicle = vehicle.OrderByDescending(v => v.RegNum);
            //        break;

            //    case "Color":
            //        vehicle = vehicle.OrderBy(v => v.Color);
            //        break;
            //    case "Color_desc":
            //        vehicle = vehicle.OrderByDescending(v => v.Color);
            //        break;
            //    default:
            //        vehicle = vehicle.OrderBy(v => v.VehicleType);
            //        break;
            //}

            return View(vehicle.ToList());

        }


   

        // GET: ParkedVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Create
        public ActionResult Create()
        {          
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleType,RegNum,Color,Brand,Model,NumOfWheels,ParkedTime")] ParkedVehicle parkedVehicle)
        {
            
            if (ModelState.IsValid)
            {
                parkedVehicle.ParkedTime = DateTime.Now;
                db.ParkedVehicles.Add(parkedVehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleType,RegNum,Color,Brand,Model,NumOfWheels,ParkedTime")] ParkedVehicle parkedVehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkedVehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            if (parkedVehicle == null)
            {
                return HttpNotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

           
            ParkedVehicle parkedVehicle = db.ParkedVehicles.Find(id);
            
            db.ParkedVehicles.Remove(parkedVehicle);
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
