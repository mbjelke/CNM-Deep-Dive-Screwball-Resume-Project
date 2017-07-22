using Microsoft.EntityFrameworkCore;
using ScrewballResume.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Data
{
    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions<ResumeContext> options) : base(options)
        {
        }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Accomplishment> Accomplishments { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Affiliation> Affiliations { get; set; }
        public DbSet<Certification> Certifications { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Reference> References { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Applicant>().ToTable("Applicants");
            modelBuilder.Entity<Job>().ToTable("Jobs");
            modelBuilder.Entity<Accomplishment>().ToTable("Accomplishments");
            modelBuilder.Entity<Qualification>().ToTable("Qualifications");
            modelBuilder.Entity<Affiliation>().ToTable("Affiliations");
            modelBuilder.Entity<Certification>().ToTable("Certifications");
            modelBuilder.Entity<Education>().ToTable("Educations");
            modelBuilder.Entity<Reference>().ToTable("References");
        }
    }
     
}
