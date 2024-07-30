using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Tests
{
    internal class Task2Tests
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
                for (int i = 1; i < 12; i++)
                {
                    string output = ocs.Task2.Solver2(String.Format("2//{0}.", i)).Replace("\n", "").Replace("\r", "");

                    string input = File.ReadAllText(String.Format("2//{0}.a", i)).Replace("\n", "").Replace("\r","");

                    Assert.AreEqual(input, output);
                }
            }
        }
    }
}

