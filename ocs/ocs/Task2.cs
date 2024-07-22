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

            StreamReader reader = new StreamReader(path);
            int kolvo = Convert.ToInt32(reader.ReadLine()); // колво наборов данных
            string answer = "";
            string number,data;
            for(int i = 0; i < kolvo; i++) 
            {
                
                number = reader.ReadLine();
                int top = 30, lowest = 15;  
                for(int j = 0; j < Convert.ToInt32(number); j++ )
                {
                    data = reader.ReadLine();
                    string [] lines = data.Split();
                    if (lowest > top)
                    {
                        answer += "-1";
                        continue;
                    }
                    if (lines[0] == "<=")
                    {
                        if (Convert.ToInt32(lines[1]) < lowest)
                        {
                            top = Convert.ToInt32(lines[1]);
                            answer += "-1";
                        }
                        else if (Convert.ToInt32(lines[1]) == lowest)
                        {
                            top = Convert.ToInt32(lines[1]);
                            answer += lines[1];
                        }
                        else if (Convert.ToInt32(lines[1]) > lowest)
                        {
                            if (Convert.ToInt32(lines[1]) >= top)
                            {
                                answer += lowest.ToString();
                            }
                            else if (Convert.ToInt32(lines[1]) < top)
                            {
                                top = Convert.ToInt32(lines[1]);
                                answer += lowest.ToString();
                            }
                        }
                    }
                    else
                    {
                        if (Convert.ToInt32(lines[1]) < lowest)
                        {
                            answer += lowest.ToString();
                        }
                        else if (Convert.ToInt32(lines[1]) == lowest)
                        {
                            answer += lines[1];
                        }
                        else if (Convert.ToInt32(lines[1]) > lowest)
                        {
                            if (Convert.ToInt32(lines[1]) > top)
                            {
                                lowest = Convert.ToInt32(lines[1]);
                                answer += "-1";
                            }
                            else if (Convert.ToInt32(lines[1]) <= top)
                            {
                                lowest = Convert.ToInt32(lines[1]);
                                answer += lowest.ToString();
                            }
                        }
                    }  
                    
                }
            }
            return answer;
        }
    }
}
