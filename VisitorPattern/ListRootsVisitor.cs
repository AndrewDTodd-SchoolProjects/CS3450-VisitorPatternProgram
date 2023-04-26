using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal class ListRootsVisitor : IDirectoryComponentVisitor
    {
        public void VisitComponent(Directory directory)
        {
            Console.WriteLine(directory.Name + ":");

            foreach(var child in  directory.Children)
            {
                child.Accept(this);
            }
        }

        public void VisitComponent(File file)
        {
        }
    }
}
