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

            
        }
        static public string Solver(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string currentshipsString;
                int kolvo = int.Parse(reader.ReadLine());
                string result = "";
                while ((currentshipsString = reader.ReadLine()) != null)
                {
                    Dictionary<int, int> numberOfShips = new Dictionary<int, int>() { { 1, 4 }, { 2, 3 } , {3, 2 } , {4, 1 } };

                    foreach(var c in currentshipsString.Split(' ')) 
                    {
                        numberOfShips[int.Parse(c)]--;
                    }
                    if ((numberOfShips[1] == 0 ) && (numberOfShips[2] == 0 )&&( numberOfShips[3] == 0) && (numberOfShips[4] == 0))
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
}
