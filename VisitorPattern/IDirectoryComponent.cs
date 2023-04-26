using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal interface IDirectoryComponent
    {
        public string Name { get; }

        public IDirectoryComponent? ChDir(string dirName);

        public IDirectoryComponent? Up();

        public int CountAll();

        public void Accept(IDirectoryComponentVisitor visitor);
    }
}
