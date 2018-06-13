using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InitEntity.Models;

namespace InitEntity.Controllers
{
    public class ClientController : Controller
    {
        // le fait de mettre le dal en static permet de ne pas réinstancier à chaque fois une instance de DAL.
        static Dal dal = new Dal();
        // GET: Client
        public ActionResult Index()
        {
            return View(dal.GetClients());
        }

        public ActionResult Create()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create(Client _client)
        {
            //Réeffectue les vérification qui ont étés définis sur le model.
            if (!ModelState.IsValid)
            {
                return View("Create", _client);
            }

            dal.AddClient(_client);

            // permet de rediriger la page, on peut mettre deux parametres si on veut aller sur un controleur en particulier
            //  return RedirectToAction("Index", "HomeController");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Client client = dal.GetClient(id);
            return View(client);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Edit(Client client)
        {

            if (!ModelState.IsValid)
            {
                return View("Edit", client);
            }

            dal.UpdateClient(client);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Client client = dal.GetClient(id);
            return View(client);
        }


        public ActionResult Delete(int id)
        {
            Client client = dal.GetClient(id);
            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            dal.DeleteClient(id);
            return RedirectToAction("Index");
        }
    }
}