/*
   DESIGNER: Juan Sebastian Garrido Pallares(ID: 100600388) & Pei Shuen Beh(ID: 100599009)
   EXERCISE: Assignment 2
   TASK: CS CLASS For CONTROLLER
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DotNetAppSqlDb.Models;
using System.Diagnostics;


namespace DotNetAppSqlDb.Controllers
{
    public class TodosController : Controller
    {


        private MyDatabaseContext db = new MyDatabaseContext();


        // ----- Views ------


        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }



        //----------Loads the list of Customer Entities saved in the Database into a View


        public ActionResult ViewCustomers()
        {
            ViewBag.Message = "Customers List";


            Trace.WriteLine("GET /Todos/ViewCustomers");
            return View(db.Todoes.ToList());

        }



        //------- Actions inside the views ------------



        //    ---------------------------------------------------------------------------------





        // GET: Todos/Details/5
        public ActionResult Details(int? id)
        {
            Trace.WriteLine("GET /Todos/Details/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }


        // POST: Todos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp([Bind(Include = "CustomerID,FirstName,LastName,Email,ConfirmEmail,Password,ConfirmPassword")] Todo todo)
        {
            Trace.WriteLine("POST /Todos/Create");
            if (ModelState.IsValid)
            {
                db.Todoes.Add(todo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(todo);
        }



        // GET: Todos/Edit/5
        public ActionResult Edit(int? id)
        {
            Trace.WriteLine("GET /Todos/Edit/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }



        // POST: Todos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,FirstName,LastName,Email")] Todo todo)
        {

            Todo todoTemp = db.Todoes.Find(todo.CustomerID);

            Trace.WriteLine("POST /Todos/Edit/" + todo.CustomerID);

            if (todoTemp != null)
            {
                todoTemp.FirstName = todo.FirstName;
                todoTemp.LastName = todo.LastName;
                todoTemp.Email = todo.Email;
                db.Entry(todoTemp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ViewCustomers");
            }
            return View(todo);
        }


        // GET: Todos/Delete/5
        public ActionResult Delete(int? id)
        {
            Trace.WriteLine("GET /Todos/Delete/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todoes.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return View(todo);
        }



        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trace.WriteLine("POST /Todos/Delete/" + id);
            Todo todo = db.Todoes.Find(id);
            db.Todoes.Remove(todo);
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














  






    


