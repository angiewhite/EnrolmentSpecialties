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

        public JsonResult TakeSelectedNodes(int[] selectedIds)
        {
            if (selectedIds == null) return Json(null);
            List<EnrolmentUnit> selected = new List<EnrolmentUnit>();
            TreeHandler handler = new TreeHandler();
            foreach(var id in selectedIds)
            {
                selected.Concat(handler.GetGrandestChildren(id));
            }
            Session["selected"] = selected;
            return Json(selected, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDirectChildren(int nodeId)
        {
            IEnumerable<EnrolmentUnit> children = new TreeHandler().GetDirectChildren(nodeId);
            return Json(children.Select(child => new { fullName = child.FullName, shortName = child.ShortName, id = child.Id }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourses()
        {
            //Session["selected"] = new List<EnrolmentUnit>(new SpecialtyRepository().EnrolmentUnits.Where(u => u.Id == 9 || u.Id == 10));
            if (Session["selected"] == null) return Json(null);
            return Json(new Querier().GetAvailableCourses((IEnumerable<EnrolmentUnit>)Session["selected"]), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSpecialties(int course, int formId, int paymentId, int termId, int nameId)
        {
            if (Session["selected"] == null) return Json(null);
            var specialties = new Querier().GetAvailableSpecialties((IEnumerable<EnrolmentUnit>)Session["selected"], course, formId, paymentId, termId, nameId);
            return Json(specialties, JsonRequestBehavior.AllowGet);
        }
    }
}