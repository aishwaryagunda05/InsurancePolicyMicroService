using InsurancePolicyService.Models;
using InsurancePolicyService.Repositories;

namespace InsurancePolicyService.Services
{
    public class PolicyNotesService : IPolicyNotesService
    {
        private readonly IPolicyNotesRepository _repo;

        public PolicyNotesService(IPolicyNotesRepository repo)
        {
            _repo = repo;
        }

        public PolicyNote AddNote(string policyNumber, string note)
        {
            var newNote = new PolicyNote
            {
                PolicyNumber = policyNumber,
                Note = note
            };

            return _repo.Add(newNote);
        }

        public List<PolicyNote> GetNotes() => _repo.GetAll();

        public PolicyNote? GetById(int id) => _repo.GetById(id);
    }
}
