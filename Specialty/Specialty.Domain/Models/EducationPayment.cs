using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Specialty.Domain.Models
{
    public class EducationPayment
    {
        public byte Id { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public byte GovernmentShare { get; set; }
    }
}
