using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal class File : IDirectoryComponent
    {
        private readonly string _name;

        public string Name { get => _name; }

        public File(string name) => _name = name;

        public void Accept(IDirectoryComponentVisitor visitor)
        {
            visitor.VisitComponent(this);
        }

        /*public string ListAll(string tabs = "   ")
        {
            return _name + Environment.NewLine;
        }*/

        public IDirectoryComponent? ChDir(string dirName)
        {
            return null;
        }

        public IDirectoryComponent? Up()
        {
            return null;
        }

        /*public int Count()
        {
            return 1;
        }*/

        public int CountAll()
        {
            return 1;
        }
    }
}
