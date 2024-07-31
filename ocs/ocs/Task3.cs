using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;



namespace ocs
{
    public class Task3
    {
        public interface ICommand
        {
            void Execute(Terminal terminal, string currentStringParam);
        }

        public class Terminal
        {
            public List<string> list = new List<string>();

            public int currentCursorPosition = 0;
            public int currentNumberOfString = 0;
            public class LeftCommand : ICommand
            {
                public void Execute(Terminal terminal, string currentStringParam)
                {

                    if (terminal.currentCursorPosition > 0)
                    {
                        terminal.currentCursorPosition--;
                    }
                }
            }

            public class RightCommand : ICommand
            {
                public void Execute(Terminal terminal, string currentStringParam)
                {
                    if (terminal.currentCursorPosition < terminal.list[terminal.currentNumberOfString].Length)
                    {
                        terminal.currentCursorPosition++;
                    }
                }
            }

            public class UpCommand : ICommand
            {
                public void Execute(Terminal terminal, string currentStringParam)
                {
                    if (terminal.currentNumberOfString > 0)
                    {
                        terminal.currentNumberOfString--;
                        if (terminal.list[terminal.currentNumberOfString].Length < terminal.currentCursorPosition)
                        {
                            terminal.currentCursorPosition = terminal.list[terminal.currentNumberOfString].Length;
                        }
                    }
                }
            }

            public class DownCommand : ICommand
            {
                public void Execute(Terminal terminal, string currentStringParam)
                {
                    if (terminal.currentNumberOfString < terminal.list.Count - 1)
                    {
                        terminal.currentNumberOfString++;
                        if (terminal.list[terminal.currentNumberOfString].Length < terminal.currentCursorPosition)
                        {
                            terminal.currentCursorPosition = terminal.list[terminal.currentNumberOfString].Length;
                        }
                    }
                }
            }

            public class BeginCommand : ICommand
            {
                public void Execute(Terminal terminal, string currentStringParam)
                {
                    terminal.currentCursorPosition = 0;
                }
            }

            public class EndCommand : ICommand
            {
                public void Execute(Terminal terminal, string currentStringParam)
                {
                    terminal.currentCursorPosition = terminal.list[terminal.currentNumberOfString].Length;
                }
            }

            public class NewLineCommand : ICommand
            {
                public void Execute(Terminal terminal, string currentStringParam)
                {
                    if (terminal.currentCursorPosition == terminal.list[terminal.currentNumberOfString].Length)
                    {
                        terminal.list.Insert(terminal.currentNumberOfString + 1, "");
                        terminal.currentNumberOfString++;
                        terminal.currentCursorPosition = 0;
                    }

                    else
                    {
                        string newString = currentStringParam.Substring(terminal.currentCursorPosition);
                        terminal.list[terminal.currentNumberOfString] = currentStringParam.Substring(0, terminal.currentCursorPosition);
                        terminal.list.Insert(terminal.currentNumberOfString + 1, newString);
                        terminal.currentCursorPosition = 0;
                        terminal.currentNumberOfString++;
                    }
                }

            }
            public class AppendCommand : ICommand
            {
                private string _element;

                public AppendCommand(string element)
                {
                    _element = element;
                }

                public void Execute(Terminal terminal, string currentStringParam)
                {
                    string newString = currentStringParam.Insert(terminal.currentCursorPosition, _element);
                    terminal.list[terminal.currentNumberOfString] = newString;
                    terminal.currentCursorPosition++;
                }
            }
        }
    



        public static string Solver3(string path)
        {
            using StreamReader reader = new StreamReader(path);
            int kolvo = Convert.ToInt32(reader.ReadLine()); // колво наборов
            string answer = "";

            for (int i = 0; i < kolvo; i++)
            {
                if (i != 0) answer += "\n";
                Terminal currentTerminal = new Terminal();
                string line = reader.ReadLine();
                currentTerminal.list.Add("");

                Dictionary<char, ICommand> commandDict = new Dictionary<char, ICommand>
            {
                {'L', new Terminal.LeftCommand()},
                {'R', new Terminal.RightCommand()},
                {'U', new Terminal.UpCommand()},
                {'D', new Terminal.DownCommand()},
                {'B', new Terminal.BeginCommand()},
                {'E', new Terminal.EndCommand()},
                {'N', new Terminal.NewLineCommand()}
            };

                for (int j = 0; j < line.Length; j++)
                {
                    char currentChar = line[j];
                    if (commandDict.ContainsKey(currentChar))
                    {
                        commandDict[currentChar].Execute(currentTerminal, currentTerminal.list[currentTerminal.currentNumberOfString]);
                    }
                    else
                    {
                        new Terminal.AppendCommand(currentChar.ToString()).Execute(currentTerminal, currentTerminal.list[currentTerminal.currentNumberOfString]);
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
