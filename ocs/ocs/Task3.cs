using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ocs
{
    public class Task3
    {

        public class Terminal
        {
            public List<string> list = new List<string>();

            public int currentCursorPosition = 0;
            public int currentNumberOfString = 0;

            public void Lmethod(string currentstringparam)
            {
                if (currentCursorPosition > 0)
                {
                    currentCursorPosition--;
                }
            }

            public void Rmethod(string currentstringparam)
            {
                if (currentCursorPosition < list[currentNumberOfString].Length)
                {
                    currentCursorPosition++;
                }
            }

            public void Umethod(string currentstringparam)
            {
                if (currentNumberOfString > 0)
                {
                    currentNumberOfString--;
                    if (list[currentNumberOfString].Length < currentCursorPosition)
                    {
                        currentCursorPosition = list[currentNumberOfString].Length;
                    }
                }
            }

            public void Dmethod(string currentstringparam)
            {
                if (currentNumberOfString < list.Count - 1)
                {
                    currentNumberOfString++;
                    if (list[currentNumberOfString].Length < currentCursorPosition)
                    {
                        currentCursorPosition = list[currentNumberOfString].Length;
                    }
                }
            }

            public void Bmethod(string currentstringparam)
            {
                currentCursorPosition = 0;
            }

            public void Emethod(string currentstringparam)
            {
                currentCursorPosition = list[currentNumberOfString].Length;
            }

            public void Nmethod(string currentstringparam)
            {
                if (currentCursorPosition == list[currentNumberOfString].Length)
                {
                    list.Insert(currentNumberOfString + 1, "");
                    currentNumberOfString++;
                    currentCursorPosition = 0;
                }
                else
                {
                    string newString = currentstringparam.Substring(currentCursorPosition);
                    list[currentNumberOfString] = currentstringparam.Substring(0, currentCursorPosition);
                    list.Insert(currentNumberOfString + 1, newString);
                    currentCursorPosition = 0;
                    currentNumberOfString++;
                }
            }

            public void append(string currentstring, string element)
            {
                string newString = currentstring.Insert(currentCursorPosition, element);
                list[currentNumberOfString] = newString;
                currentCursorPosition ++;
            }
        }


        public static string Solver3(string path)
        {
            StreamReader reader = new StreamReader(path);
            int kolvo = Convert.ToInt32(reader.ReadLine()); // колво наборов
            string answer = "";

            for (int i = 0; i < kolvo; i++)
            {
                if(i != 0) answer += "\n";
                Terminal currentTerminal = new Terminal();
                
                
                
                string line = reader.ReadLine();
                currentTerminal.list.Add("");
                for (int j = 0; j < (line.Length); j++)
                {
                    
                    switch (line[j]) {
                        case 'L':
                            currentTerminal.Lmethod(currentTerminal.list[currentTerminal.currentNumberOfString]);
                            break;
                        case 'R':
                            currentTerminal.Rmethod(currentTerminal.list[currentTerminal.currentNumberOfString]);
                            break;
                        case 'U':
                            currentTerminal.Umethod(currentTerminal.list[currentTerminal.currentNumberOfString]);
                            break;
                        case 'D':
                            currentTerminal.Dmethod(currentTerminal.list[currentTerminal.currentNumberOfString]);
                            break;
                        case 'B':
                            currentTerminal.Bmethod(currentTerminal.list[currentTerminal.currentNumberOfString]);
                            break;
                        case 'E':
                            currentTerminal.Emethod(currentTerminal.list[currentTerminal.currentNumberOfString]);
                            break;  
                        case 'N':
                            currentTerminal.Nmethod(currentTerminal.list[currentTerminal.currentNumberOfString]);
                            break;
                        default:
                            currentTerminal.append(currentTerminal.list[currentTerminal.currentNumberOfString], line[j].ToString());
                            break;
                    }


                }
                for (int k = 0; k < currentTerminal.list.Count; k++)
                {
                    answer += currentTerminal.list[k];
                    answer += "\n";
                }
                answer += "-";
            }
                return answer;
        }
    }
}


