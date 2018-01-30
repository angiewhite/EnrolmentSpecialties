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
        private static IEnumerable<EnrolmentUnit> selectedUnits;

        private Func<DirectEnrolmentUnit, object> selector = s => new
        {
            name = s.GovernmentSpecialty.ShortName,
            form = s.EducationForm.ShortName,
            term = s.EducationTerm.ShortName,
            qualification = s.GovernmentSpecialty.Qualification,
            payment = s.EducationPayment.ShortName,
            id = s.Id,
            year = s.Year
        };
        private Func<EnrolmentUnit, object> unitSelector = child => new { fullName = child.FullName, shortName = child.ShortName, id = child.Id, count = new TreeHandler().GetDirectChildren(child.Id).Count() };

        public ActionResult Index()
        {
            return View();
        } 
        
        public JsonResult TakeSelectedNodes(int[] selectedIds)
        {
            if (selectedIds == null || selectedIds.Length == 0)
            {
                selectedUnits = null;
                return Json(Enumerable.Empty<EnrolmentUnit>(), JsonRequestBehavior.AllowGet);
            }
            IEnumerable<EnrolmentUnit> selected = new List<EnrolmentUnit>();
            TreeHandler handler = new TreeHandler();
            foreach(var id in selectedIds)
            {
                selected = selected.Concat(handler.GetGrandestChildren(id));
            }
            selectedUnits = selected;
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDirectChildren(int nodeId)
        {
            TreeHandler handler = new TreeHandler();
            IEnumerable<EnrolmentUnit> children = handler.GetDirectChildren(nodeId);
            return Json(children.Select(unitSelector), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourses()
        {
            var result = new Querier().GetAvailableCourses(selectedUnits);
            return Json(result == null ? Enumerable.Empty<int>() : result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGroupedSpecialties(int groupId)
        {
            var specialties = new Querier().GetGroupedSpecialties(groupId);
            return Json(specialties == null ? Enumerable.Empty<object>() : specialties.Select(selector), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableCategories(int? course, int? formId, int? paymentId, int? termId, int? nameId)
        {
            if (selectedUnits == null) return Json(Enumerable.Empty<object>(), JsonRequestBehavior.AllowGet);
            var specialties = new Querier().GetAvailableSpecialties(selectedUnits, course, formId, paymentId, termId, nameId);
            if (specialties == null) return Json(Enumerable.Empty<object>(), JsonRequestBehavior.AllowGet);

            Func<DirectEnrolmentUnit, object> propertySelector = null;
            Func<object, object> newObjectSelector = (o) => new
            {
                fullName = ((dynamic)o).FullName,
                shortName = ((dynamic)o).ShortName,
                id = ((dynamic)o).Id
            };
            if (course == null) return GetCourses();
            else if (formId == null)
            {
                propertySelector = (u) => u.EducationForm;
            } else if (paymentId == null)
            {
                propertySelector = (u) => u.EducationPayment;
            } else if (termId == null)
            {
                propertySelector = (u) => u.EducationTerm;
            } else if (nameId == null)
            {
                propertySelector = (u) => u.GovernmentSpecialty;
                newObjectSelector = (n) => new
                {
                    fullName = ((GovernmentSpecialty)n).FullName,
                    shortName = ((GovernmentSpecialty)n).ShortName,
                    id = ((GovernmentSpecialty)n).Id,
                    qualification = ((GovernmentSpecialty)n).Qualification
                };
            } else
            {
                return Json(specialties.Select(selector), JsonRequestBehavior.AllowGet);
            }

            var categories = specialties.Select(propertySelector).Distinct();
            return Json(categories.Select(newObjectSelector), JsonRequestBehavior.AllowGet);
        }
    }
}