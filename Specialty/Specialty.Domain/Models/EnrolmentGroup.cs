﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specialty.Domain.Models
{
    public class EnrolmentGroup
    {
        public EnrolmentGroup()
        {
            DirectEnrolmentUnits = new HashSet<DirectEnrolmentUnit>();
        }

        public short Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public int? AvailableSpecialties { get; set; }

        public virtual ICollection<DirectEnrolmentUnit> DirectEnrolmentUnits { get; set; }
    }
}
