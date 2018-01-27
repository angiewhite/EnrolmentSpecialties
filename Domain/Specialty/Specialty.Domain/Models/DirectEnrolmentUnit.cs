using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Specialty.Domain.Models
{
    public class DirectEnrolmentUnit
    {
        public int Id { get; set; }
        public byte EducationFormId { get; set; }
        public byte EducationPaymentId { get; set; }
        public byte EducationTermId { get; set; }
        public short EnrolmentGroupId { get; set; }
        public int? ParentEnrolmentUnitId { get; set; }
        public byte TypeId { get; set; }
        public short GovernmentSpecialtyId { get; set; }
        public short Year { get; set; }
        public decimal EducationFee { get; set; }

        public virtual EducationForm EducationForm { get; set; }
        public virtual EducationPayment EducationPayment { get; set; }
        public virtual EducationTerm EducationTerm { get; set; }
        public virtual EnrolmentGroup EnrolmentGroup { get; set; }
        public virtual EnrolmentUnit ParentEnrolmentUnit { get; set; }
        public virtual EnrolmentUnitType Type { get; set; }
        
        public virtual GovernmentSpecialty GovernmentSpecialty { get; set; }
    }
}
