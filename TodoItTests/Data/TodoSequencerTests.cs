using TodoIt.Data;
using Xunit;
using System;

namespace TodoItTests.Data
{
    public class TodoSequencerTests : IDisposable
    {
        public TodoSequencerTests()
        {
            TodoSequencer.Reset();
        }
        public void Dispose()
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
