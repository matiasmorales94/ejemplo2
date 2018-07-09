using Prueba_de_Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prueba_de_Api.Controllers
{
    public class CompaniaController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult getCompanias()
        {


            Compania com = new Compania();

            try
            {
                List<Compania> listComania = com.allCompania();



                return Json(new { data = listComania }, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {

                Console.WriteLine("Error obtener companias: " + ex.Message);
                return null;
            }
        }

        public ActionResult crearCompania()
        {


            return View();
        }

        [HttpPost]
        public ActionResult crearCompania(Compania compania)
        {

            if (ModelState.IsValid)
            {

                if (compania.crearCompania(compania) != false)
                {


                    return RedirectToAction("Index");

                }

                else
                {


                    return RedirectToAction("crearCompania");
                }
            }

            else
            {


                return RedirectToAction("crearCompania");
            }


        }
    }
}