using ocs;
namespace Task1.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Task1TestWithFiles()
        {
            //arrange
            for (int i = 1; i < 16; i++)
            {
            string input = ocs.Task1.Solver(String.Format("1//{0}.",i));
            
            string output = File.ReadAllText(String.Format("1//{0}.a",i)).Replace("\n","");

            Assert.AreEqual(input,output);
            }
            


            
          
        }
    }
}