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

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult TakeSelectedNodes(int[] selectedIds)
        {
            if (selectedIds == null) return null;
            List<EnrolmentUnit> selected = new List<EnrolmentUnit>();
            TreeHandler handler = new TreeHandler();
            foreach(var id in selectedIds)
            {
                selected.Concat(handler.GetGrandestChildren(id));
            }
            selectedUnits = selected;
            return Json(selected, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetDirectChildren(int nodeId)
        {
            IEnumerable<EnrolmentUnit> children = new TreeHandler().GetDirectChildren(nodeId);
            return Json(children.Select(child => new { fullName = child.FullName, shortName = child.ShortName, id = child.Id }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourses()
        {
            return Json(new Querier().GetAvailableCourses(selectedUnits), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableCategories(int? course, int? formId, int? paymentId, int? termId, int? nameId)
        {
            selectedUnits = new List<EnrolmentUnit>(new SpecialtyRepository().EnrolmentUnits.Where(u => u.Id == 2));
            if (selectedUnits == null) return null;
            var specialties = new Querier().GetAvailableSpecialties(selectedUnits, course, formId, paymentId, termId, nameId);
            if (specialties == null) return null;

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
            }
            else if (paymentId == null)
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
                return Json(specialties.Select(s => new
                {
                    name = s.GovernmentSpecialty.ShortName,
                    form = s.EducationForm.ShortName,
                    term = s.EducationTerm.ShortName,
                    qualification = s.GovernmentSpecialty.Qualification,
                    payment = s.EducationPayment.ShortName,
                    id = s.Id,
                    year = s.Year
                }), JsonRequestBehavior.AllowGet);
            }

            var categories = specialties.Select(propertySelector).Distinct();
            return Json(categories.Select(newObjectSelector), JsonRequestBehavior.AllowGet);
        }
    }
}