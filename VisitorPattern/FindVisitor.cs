using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal class FindVisitor : IDirectoryComponentVisitor
    {

        readonly string _elementName;

        public FindVisitor(string elementToFind) => _elementName = elementToFind;

        public void VisitComponent(Directory directory)
        {
            if (directory.Name == _elementName)
            {
                Console.WriteLine($"Found Directory {_elementName}");
                directory.Accept(new ListAllVisitor());
            }

            foreach(var child in  directory.Children)
            {
                child.Accept(this);
            }
        }

        public void VisitComponent(File file)
        {
            if(file.Name == _elementName)
            {
                Console.WriteLine($"Found Leaf {_elementName}");
            }
        }
    }
}
