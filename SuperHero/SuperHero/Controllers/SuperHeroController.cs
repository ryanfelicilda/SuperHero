using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHero.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext context;
        public SuperHeroController()
        {
            context = new ApplicationDbContext();
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            var superHeroList = context.SuperHero.ToList();
            return View(superHeroList);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            var superHeroDetails = context.SuperHero.FirstOrDefault(s => s.Id == id);
            return View(superHeroDetails);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHeroModels SuperHero = new SuperHeroModels();
            return View(SuperHero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHeroModels SuperHero)
        {
            try
            {
                // TODO: Add insert logic here
                context.SuperHero.Add(SuperHero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            var superHeroEdit = context.SuperHero.FirstOrDefault(s => s.Id == id);
            return View(superHeroEdit);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                var superHeroEdit = context.SuperHero.FirstOrDefault(s => s.Id == id);
                superHeroEdit.Name = Request.Form["Name"];
                superHeroEdit.AlterEgo = Request.Form["Alter Ego"];
                superHeroEdit.PrimaryAbility = Request.Form["Primary Ability"];
                superHeroEdit.SecondaryAbility = Request.Form["Secondary Ability"];
                superHeroEdit.Catchphrase = Request.Form["Catchphrase"];
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SuperHero/Delete/5
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
