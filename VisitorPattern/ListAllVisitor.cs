using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace VisitorPattern
{
    internal class ListAllVisitor : IDirectoryComponentVisitor
    {
        string tabs = "";

        public void VisitComponent(Directory directory)
        {
            Console.Write(tabs + directory.Name + ":" + Environment.NewLine);
            string oldTabs = tabs;
            tabs += "  ";
            foreach (var child in directory.Children)
            {
                child.Accept(this);
            }

            tabs = oldTabs;
        }

        public void VisitComponent(File file)
        {
            Console.Write(tabs + file.Name + Environment.NewLine);
        }
    }
}
