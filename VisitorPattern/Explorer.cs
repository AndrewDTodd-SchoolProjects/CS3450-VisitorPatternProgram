using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
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
                        _currentDir.Accept(new ListVisitor());
                        break;

                    case "listall":
                        _currentDir.Accept(new ListAllVisitor());
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
                        _currentDir.Accept(new CountVisitor());
                        break;

                    case "countall":
                        _currentDir.Accept(new CountAllVisitor());
                        break;

                    case "find":
                        if (parts.Length != 2)
                        {
                            Console.WriteLine("invalid element search");
                            break;
                        }

                        _currentDir.Accept(new FindVisitor(parts[1]));
                        break;

                    case "listroots":
                        _currentDir.Accept(new ListRootsVisitor());
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
