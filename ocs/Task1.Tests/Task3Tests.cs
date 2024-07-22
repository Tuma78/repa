using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3.Tests
{
    internal class Task3Tests
    {
        public class Tests
        {
            [SetUp]
            public void Setup()
            {
            }

            [Test]
            public void Task2TestWithFiles()
            {
                //arrange
                for (int i = 2; i < 16; i++)
                {
                    string output = ocs.Task3.Solver3(String.Format("3//{0}.", i));

                    string input = File.ReadAllText(String.Format("3//{0}.a", i));

                    Assert.AreEqual(input, output);
                }
            }
        }
    }
}
