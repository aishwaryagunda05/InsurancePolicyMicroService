using InsurancePolicyService.Models;
using InsurancePolicyService.Repositories;
using InsurancePolicyService.Services;
using Moq;

namespace InsurancePolicyService.UnitTests
{
    public class PolicyNotesServiceUnitTests
    {
        [Theory]
        [InlineData("P100", "Test Note")]
        public void AddNote_Should_Add_Successfully(string policy, string note)
        {
            var mockRepo = new Mock<IPolicyNotesRepository>();

            mockRepo.Setup(r => r.Add(It.IsAny<PolicyNote>()))
                .Returns((PolicyNote n) => new PolicyNote
                {
                    Id = 1,
                    PolicyNumber = n.PolicyNumber,
                    Note = n.Note
                });

            var service = new PolicyNotesService(mockRepo.Object);

            var result = service.AddNote(policy, note);

            Assert.Equal(policy, result.PolicyNumber);
            Assert.Equal(note, result.Note);
        }

        [Fact]
        public void GetNotes_Should_Return_All()
        {
            var mockRepo = new Mock<IPolicyNotesRepository>();

            mockRepo.Setup(r => r.GetAll())
                .Returns(new List<PolicyNote>
                {
                    new(){ Id = 1, PolicyNumber = "P1", Note = "Note1" },
                    new(){ Id = 2, PolicyNumber = "P2", Note = "Note2" }
                });

            var service = new PolicyNotesService(mockRepo.Object);

            var result = service.GetNotes();

            Assert.Equal(2, result.Count);
        }
    }
}
