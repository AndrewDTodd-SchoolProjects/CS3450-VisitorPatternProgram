using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    internal interface IDirectoryComponent
    {
        public string Name { get; }

        public string List();

        public string ListAll(string tabs = "  ");

        public IDirectoryComponent? ChDir(string dirName);

        public IDirectoryComponent? Up();

        public int Count();

        public int CountAll();

        //public void Quit();
    }
}
