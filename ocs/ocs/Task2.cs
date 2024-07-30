using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ocs
{
    public class Task2
    {

        static public string Solver2(string path)
        {

            using (StreamReader reader = new StreamReader(path))
            {
                int kolvo = int.Parse(reader.ReadLine()); // колво наборов данных
                string answer = "";
                string number, data;
                for (int i = 0; i < kolvo; i++)
                {

                    number = reader.ReadLine();
                    int top = 30, lowest = 15;
                    for (int j = 0; j < int.Parse(number); j++)
                    {
                        data = reader.ReadLine();
                        string[] lines = data.Split();
                        int currentnumber = int.Parse(lines[1]);
                        if (lines[0] == "<=")
                        {

                            if (currentnumber < top)
                            {
                                top = currentnumber;
                                if (lowest > top) answer += "-1";
                                else answer += lowest.ToString();
                            }
                            else
                            {
                                if (lowest > top) answer += "-1";
                                else answer += lowest.ToString();
                            }
                        }
                        else if (lines[0] == ">=")
                        {

                            if (currentnumber > lowest)
                            {
                                lowest = currentnumber;
                                if (lowest > top) answer += "-1";
                                else answer += lowest.ToString();

                            }
                            else
                            {
                                if (lowest > top) answer += "-1";
                                else answer += lowest.ToString();

                            }
                        }

                    }
                }

                return answer;
            }
        }
    }
}
