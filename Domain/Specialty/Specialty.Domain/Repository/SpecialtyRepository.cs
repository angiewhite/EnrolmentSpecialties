using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Specialty.Domain.Models;

namespace Specialty.Domain.Repository
{
    public class SpecialtyRepository
    {
        private SpecialtyContext context = new SpecialtyContext();

        public IQueryable<GovernmentSpecialty> GovernmentSpecialties => context.GovernmentSpecialties;
        public IQueryable<DirectEnrolmentUnit> DirectEnrollmentUnits => context.DirectEnrolmentUnits;
    }
}
