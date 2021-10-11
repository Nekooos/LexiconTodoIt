
namespace TodoIt.Data
{
    public class TodoSequencer
    {
        private static int todoId = 0;

        public static int NextTodoId()
        {
            return todoId = todoId+1;
        }

        public static void Reset()
        {
            todoId = 0;
        }
    }
}
