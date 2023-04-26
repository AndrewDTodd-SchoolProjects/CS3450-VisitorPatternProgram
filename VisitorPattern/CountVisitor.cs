using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal class CountVisitor : IDirectoryComponentVisitor
    {
        public void VisitComponent(Directory directory)
        {
            int count = 0;

            foreach (var child in directory.Children)
            {
                if (child is File)
                    count++;
            }

            Console.WriteLine(count);
        }

        public void VisitComponent(File file)
        {
            Console.WriteLine(1);
        }
    }
}
