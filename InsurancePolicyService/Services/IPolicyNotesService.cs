using InsurancePolicyService.Models;

namespace InsurancePolicyService.Services
{
    public interface IPolicyNotesService
    {
        PolicyNote AddNote(string policyNumber, string note);
        List<PolicyNote> GetNotes();
        PolicyNote GetById(int id);
    }
}
