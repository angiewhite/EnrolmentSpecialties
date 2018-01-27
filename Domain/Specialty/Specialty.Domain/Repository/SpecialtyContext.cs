﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Specialty.Domain.Models;

namespace Specialty.Domain.Repository
{
    class SpecialtyContext: DbContext
    {
        public DbSet<DirectEnrolmentUnit> DirectEnrolmentUnits { get; set; }
        public DbSet<EducationForm> EducationForms { get; set; }
        public DbSet<EducationPayment> EducationPayments { get; set; }
        public DbSet<EducationTerm> EducationTerms { get; set; }
        public DbSet<EnrolmentGroup> EducationGroups { get; set; }
        public DbSet<EnrolmentUnit> EducationUnits { get; set; }
        public DbSet<EnrolmentUnitType> EducationUnitTypes { get; set; }
        public DbSet<GovernmentSpecialty> GovernmentSpecialties { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
