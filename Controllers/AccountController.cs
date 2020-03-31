using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication8.Services;
using WebApplication8.ViewModals;

namespace WebApplication8.Controllers
{
    public class AccountController : Controller
    {
        UsersService user = new UsersService();
        // GET: Account
        public ActionResult StartPage() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Verify(UserViewModal model)
        {
            var id = user.VerifyUserAcc(model.FirstName , model.Password);

            if (id == null)
            {
                return View("Error");
            }
            else
            {
                //TempData["user"] = id.FirstName;
                Session["user"] = id.FirstName;
                return RedirectToAction("Index", "Login");
            }
        }


        // GET: Account/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Account/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Account/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Account/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Account/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Account/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
