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

        public IEnumerable<GovernmentSpecialty> GovernmentSpecialties => context.GovernmentSpecialties;
        public IEnumerable<DirectEnrolmentUnit> DirectEnrolmentUnits => context.DirectEnrolmentUnits;
        public IEnumerable<EnrolmentUnit> EnrolmentUnits => context.EnrolmentUnits;
    }
}
