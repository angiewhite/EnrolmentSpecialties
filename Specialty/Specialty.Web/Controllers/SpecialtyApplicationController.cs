using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Specialty.Domain.Models;
using Specialty.Domain.Repository;
using Specialty.Web.Models;

namespace Specialty.Web.Controllers
{
    public class SpecialtyApplicationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDirectChildren(int nodeId)
        {
            return Json(new TreeHandler().GetDirectChildren(nodeId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGrandestChildren(int nodeId)
        {
            return Json(new TreeHandler().GetGrandestChildren(nodeId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSpecialty(int parentId, int course, int formId, int paymentId, int termId, int nameId)
        {
            var specialty = new Querier().FindSpecialty(parentId, course, formId, paymentId, termId, nameId);
            return Json(specialty, JsonRequestBehavior.AllowGet);
        }
    }
}