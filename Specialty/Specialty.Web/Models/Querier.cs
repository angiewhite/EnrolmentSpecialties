using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Specialty.Domain.Models;
using Specialty.Domain.Repository;

namespace Specialty.Web.Models
{
    //resolve with the year!!!!!
    public class Querier
    {
        private SpecialtyRepository repository = new SpecialtyRepository();

        public DirectEnrolmentUnit FindSpecialty(int parentId, int course, int formId, int paymentId, int termId, int nameId)
        {
            return repository.DirectEnrolmentUnits.Where(u => u.ParentEnrolmentUnitId == parentId
            && 2018 + 1 - course == u.Year && u.EducationFormId == formId && u.EducationPaymentId == paymentId
            && u.EducationTermId == termId && u.GovernmentSpecialtyId == nameId).FirstOrDefault();
        }
    }
}