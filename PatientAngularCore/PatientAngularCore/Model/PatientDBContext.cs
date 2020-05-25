using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Options;

namespace PatientAngularCore.Model
{
    public class PatientDBContext : DbContext
    {
        public PatientDBContext(DbContextOptions<PatientDBContext> options) : base(options)
        {
            
        }

        //public IEnumerable<PatientModel> GetPatientListByQuery(string qry)
        //{
            
        //}

        public DbSet<PatientModel> PatientModels { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<PatientQuery> PatientQueries { get; set; }
        public DbSet<User> User { get; set; }
    }
}   
