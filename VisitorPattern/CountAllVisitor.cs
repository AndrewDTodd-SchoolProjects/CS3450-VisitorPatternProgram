using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal class CountAllVisitor : IDirectoryComponentVisitor
    {
        public void VisitComponent(Directory directory)
        {
            Console.WriteLine(directory.CountAll());
        }

        public void VisitComponent(File file)
        {
            Console.WriteLine(file.CountAll());
        }
    }
}
