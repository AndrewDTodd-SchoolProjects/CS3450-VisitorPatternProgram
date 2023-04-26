using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal class ListVisitor : IDirectoryComponentVisitor
    {
        public void VisitComponent(Directory directory)
        {
            foreach(IDirectoryComponent child in directory.Children)
            {
                Console.Write(child.Name + " ");
            }

            Console.Write(Environment.NewLine);
        }

        public void VisitComponent(File file)
        {
            Console.Write(file.Name + " ");
        }
    }
}
