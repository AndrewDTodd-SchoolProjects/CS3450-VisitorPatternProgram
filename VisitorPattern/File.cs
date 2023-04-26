using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    internal class File : IDirectoryComponent
    {
        private readonly string _name;

        public string Name { get => _name; }

        public File(string name) => _name = name;
        public string List()
        {
            return _name;
        }

        public string ListAll(string tabs = "   ")
        {
            return _name;
        }

        public IDirectoryComponent? ChDir(string dirName)
        {
            return null;
        }

        public IDirectoryComponent? Up()
        {
            return null;
        }

        public int Count()
        {
            return 1;
        }

        public int CountAll()
        {
            return 1;
        }
    }
}
