using TodoIt.Data;
using Xunit;

namespace TodoItTests.Data
{
    public class PersonSequencerTests
    {
        public PersonSequencerTests()
        {
            PersonSequencer.Reset();
        }

        [Fact]
        public void NextPersonIdTest()
        {
            int personId = PersonSequencer.NextPersonId();

            Assert.Equal(1, personId);
        }

        [Fact]
        public void ResetTest()
        {
            PersonSequencer.NextPersonId();
            PersonSequencer.NextPersonId();
            PersonSequencer.Reset();

            Assert.Equal(1, PersonSequencer.NextPersonId());
        }
    }
}
