using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    internal class Explorer
    {
        private IDirectoryComponent _currentDir;

        public Explorer(Directory currentDir) => this._currentDir = currentDir;

        public void Process()
        {
            do
            {
                Console.Write(_currentDir.Name + "> ");

                string? input = Console.ReadLine();

                if (input == null)
                {
                    Console.WriteLine("unrecognized command");
                    continue;
                }

                string[] parts = input.Split();

                if(parts.Length > 2)
                {
                    Console.WriteLine("unrecognized command");
                    continue;
                }

                switch(parts[0])
                {
                    case "list":
                        Console.WriteLine(_currentDir.List());
                        break;

                    case "listall":
                        Console.WriteLine(_currentDir.ListAll());
                        break;

                    case "chdir":
                        if(parts.Length != 2)
                        {
                            Console.WriteLine("invalid directory");
                            break;
                        }
                        IDirectoryComponent? newDir = _currentDir.ChDir(parts[1]);

                        if(newDir == null)
                        {
                            Console.WriteLine("no such directory");
                            break;
                        }

                        _currentDir = newDir;
                        break;

                    case "up":
                        newDir = _currentDir.Up();

                        if (newDir != null)
                            _currentDir = newDir;
                        else
                            Console.WriteLine("already at root");
                        break;

                    case "count":
                        Console.WriteLine(_currentDir.Count());
                        break;

                    case "countall":
                        Console.WriteLine(_currentDir.CountAll());
                        break;

                    case "q":
                        return;

                    default:
                        Console.WriteLine("unrecognized command");
                        break;
                }
            }while (true);
        }
    }
}
