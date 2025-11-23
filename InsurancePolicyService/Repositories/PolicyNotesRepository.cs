using InsurancePolicyService.Data;
using InsurancePolicyService.Models;

namespace InsurancePolicyService.Repositories
{
    public class PolicyNotesRepository : IPolicyNotesRepository
    {
        private readonly InsurancePolicyDbContext _context;

        public PolicyNotesRepository(InsurancePolicyDbContext context)
        {
            _context = context;
        }

        public PolicyNote Add(PolicyNote note)
        {
            _context.PolicyNotes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public List<PolicyNote> GetAll()
        {
            return _context.PolicyNotes.ToList();
        }

        public PolicyNote? GetById(int id)
        {
            return _context.PolicyNotes.Find(id);
        }
    }
}
