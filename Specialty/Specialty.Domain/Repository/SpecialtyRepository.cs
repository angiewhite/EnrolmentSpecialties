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

        public IQueryable<DirectEnrolmentUnit> DirectEnrolmentUnits => context.DirectEnrolmentUnits;
        public IQueryable<EnrolmentUnit> EnrolmentUnits => context.EnrolmentUnits;
        public IQueryable<GovernmentSpecialty> GovernmentSpecialties => context.GovernmentSpecialties;
        public IQueryable<EnrolmentGroup> EnrolmentGroups => context.EnrolmentGroups;
    }
}
