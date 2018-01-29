using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specialty.Domain.Models
{
    public class EnrolmentUnit
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int? ParentId { get; set; }
        public byte EnrolmentUnitTypeId { get; set; }

        public virtual EnrolmentUnit Parent { get; set; }
        public virtual EnrolmentUnitType EnrolmentUnitType { get; set; }
    }
}
