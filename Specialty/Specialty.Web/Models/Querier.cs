using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Specialty.Domain.Models;
using Specialty.Domain.Repository;

namespace Specialty.Web.Models
{
    public class Querier
    {
        private static readonly int currentYear = 2018;
        private SpecialtyRepository repository = new SpecialtyRepository();

        public IEnumerable<int> GetAvailableCourses(IEnumerable<EnrolmentUnit> selectedUnits)
        {
            var courses = GetAvailableSpecialties(selectedUnits).Select(s => currentYear + 1 - s.Year).Distinct();
            if (courses.Contains(1)) yield return 1;
            if (courses.Contains(2)) yield return 2;
        }

        public IEnumerable<DirectEnrolmentUnit> GetAvailableSpecialties(IEnumerable<EnrolmentUnit> selectedUnits, int? course, int? formId, int? paymentId, int? termId, int? nameId)
        {
            var available = GetAvailableSpecialties(selectedUnits);
            if (available == null) return null;
            if (course != null) available = available.Where(s => s.Year == currentYear + 1 - course);
            if (formId != null) available = available.Where(s => s.EducationFormId == formId);
            if (paymentId != null) available = available.Where(s => s.EducationPaymentId == paymentId);
            if (termId != null) available = available.Where(s => s.EducationTermId == termId);
            if (nameId != null) available = available.Where(s => s.GovernmentSpecialtyId == nameId);
            return available;
        }

        public IEnumerable<DirectEnrolmentUnit> GetAvailableSpecialties(IEnumerable<EnrolmentUnit> selectedUnits)
        {
            if (selectedUnits == null) return null;
            return selectedUnits.SelectMany(unit => unit.DirectEnrolmentUnits).Distinct();
        }
    }
}