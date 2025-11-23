using InsurancePolicyService.Models;

namespace InsurancePolicyService.Repositories
{
    public interface IPolicyNotesRepository
    {
        PolicyNote Add(PolicyNote note);
        List<PolicyNote> GetAll();
        PolicyNote? GetById(int id);
    }
}
