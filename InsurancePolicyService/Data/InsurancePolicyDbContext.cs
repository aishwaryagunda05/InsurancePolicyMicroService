using InsurancePolicyService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InsurancePolicyService.Data
{
    public class InsurancePolicyDbContext : DbContext
    {
        public InsurancePolicyDbContext(DbContextOptions<InsurancePolicyDbContext> options)
            : base(options)
        {
        }

        public DbSet<PolicyNote> PolicyNotes { get; set; }
    }
}
