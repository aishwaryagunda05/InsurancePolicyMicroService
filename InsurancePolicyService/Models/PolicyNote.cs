namespace InsurancePolicyService.Models
{
    public record PolicyNote
    {
        public int Id { get; set; }
        public string PolicyNumber { get; set; }
        public string Note { get; set; }
    }
}