using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ocs
{


    public class Task1
    {
        static void Main(string[] args)
        {

            Console.WriteLine( Task3.Solver3(@"C:\Users\pan\Desktop\rep1\ocs\Task1.Tests\bin\Debug\net6.0\3\2."));
        }
        static public string Solver(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line;
            int kolvo = Convert.ToInt32(reader.ReadLine());
            string result = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] rez = line.Split(' ');
                if ((rez.Count(line1 => line1.Contains('1')) == 4) && (rez.Count(line1 => line1.Contains('2')) == 3) && (rez.Count(line1 => line1.Contains('3')) == 2) && (rez.Count(line1 => line1.Contains('4')) == 1))

                {
                    result += "YES";
                }
                else
                {
                    result += "NO";
                }
            }
            return result;

        }
    }
}
