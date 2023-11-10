using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hopital.Model;

    public class GHContext : DbContext
    {
        public GHContext (DbContextOptions<GHContext> options)
            : base(options)
        {
        }

        public DbSet<Hopital.Model.Medecin>? Medecin { get; set; }

        public DbSet<Hopital.Model.Consultation>? Consultation { get; set; }

        public DbSet<Hopital.Model.DossierPatient>? DossierPatient { get; set; }

        public DbSet<Hopital.Model.Prescription>? Prescription { get; set; }

       

    }
