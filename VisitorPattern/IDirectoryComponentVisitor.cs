using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal interface IDirectoryComponentVisitor
    {
        public void VisitComponent(Directory directory);

        public void VisitComponent(File file);
    }
}
