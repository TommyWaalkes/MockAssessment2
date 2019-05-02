using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MockAssessment2
{
    public class MockAssessmentTests
    {
        [Fact]
        public void Test1_Tasks()
        {
            //The whole project relies on tasks being here
            List<string> tasks = new List<string>() { "get a haircut", "walk the trash", "clean up the dog", "cheat on my taxes", "put down Spartacus' slave rebellion with swift and extreme prejudice"};
            Program.tasks.Clear();
            Program.tasks = tasks;

            Assert.Equal(tasks, Program.tasks);
        }

        [Fact]
        public void Test2_AddTasks()
        {
            Program.tasks.Clear();
            List<string> tasks = new List<string>();

            string[] inputs = { "screetch at the moon", "clean fridge", "organize books" };
        
            foreach(string input in inputs)
            {
                Program.AddTask(input);
                tasks.Add(input);
            }

            Assert.Equal(tasks.Count, Program.tasks.Count);
            for (int i = 0; i < Program.tasks.Count; i++)
            {
                Assert.Equal(tasks[i], Program.tasks[i]);
            }
        }

        [Theory]
        [InlineData(1)]
        [InlineData(-1)]
        public void Test3_GetTest(int index)
        {
            Program.tasks.Clear();
            List<string> tasks = new List<string>();
            string[] inputs = { "screetch at the moon", "clean fridge", "organize books" };

            foreach (string input in inputs)
            {
                Program.AddTask(input);
                tasks.Add(input);
            }
            string expected;
            string actual = Program.GetTask(index);
            if (index >= 0)
            {
                 expected = tasks[index];
                
            }
            else
            {
                expected = "error";
            }

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("clean fridge")]
        [InlineData("eat cheese")]
        [InlineData("nothing")]
        public void Test5_FinishTask(string task)
        {
            Program.tasks.Clear();
            List<string> tasks = new List<string>();
            string[] inputs = { "screetch at the moon", "clean fridge", "organize books" };

            foreach (string input in inputs)
            {
                Program.AddTask(input);
                tasks.Add(input);
            }
            bool expected, actual;
            actual = Program.FinishTask(task);
            if (tasks.Contains(task))
            {
                tasks.Remove(task);
                 expected = true;
            }
            else
            {
                expected = false;
            }

            Assert.Equal(expected, actual);

            for (int i = 0; i < Program.tasks.Count; i++)
            {
                Assert.Equal(tasks[i], Program.tasks[i]);
            }
        }
    }
}
