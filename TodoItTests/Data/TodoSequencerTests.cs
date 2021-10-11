using TodoIt.Data;
using Xunit;

namespace TodoItTests.Data
{
    public class TodoSequencerTests
    {
        public TodoSequencerTests()
        {
            TodoSequencer.Reset();
        }

        [Fact]
        public void NextPersonIdTest()
        {
            int todoId = TodoSequencer.NextTodoId();

            Assert.Equal(1, todoId);
        }

        [Fact]
        public void ResetTest()
        {
            TodoSequencer.NextTodoId();
            TodoSequencer.NextTodoId();
            TodoSequencer.Reset();

            Assert.Equal(1, TodoSequencer.NextTodoId());
        }
    }
}
