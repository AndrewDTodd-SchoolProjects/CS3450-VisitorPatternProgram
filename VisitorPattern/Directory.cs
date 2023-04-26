using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    internal class Directory : IDirectoryComponent
    {
        private readonly string _name;

        private readonly Directory? _parent;

        private readonly List<IDirectoryComponent> _children = new();

        public string Name { get => _name; }

        public Directory? Parent { get => _parent; }

        public Directory(string name, Directory? parent) => 
            (_name, _parent) = (name,parent);

        public void Add(IDirectoryComponent component)
        {
            _children.Add(component);
        }

        public void Remove(IDirectoryComponent component)
        {
            _children.Remove(component);
        }

        public string List()
        {
            StringBuilder sb = new();

            foreach (var component in _children)
            {
                if (component is File)
                    sb.Append(component.List() + ' ');
                else
                    sb.Append(component.Name + ' ');
            }

            return sb.ToString();
        }

        public string ListAll(string tabs = "  ")
        {
            StringBuilder sb = new();

            sb.Append(_name + ":" + Environment.NewLine);

            foreach (var component in _children)
            {
                sb.Append(tabs + component.ListAll(tabs + "  ") + Environment.NewLine);
            }

            return sb.Remove(sb.Length - 1, 1).ToString();
        }

        public IDirectoryComponent? ChDir(string dirName)
        {
            string[] pathComponents = dirName.Split('/');

            if (pathComponents.Length == 1)
            {
                if (pathComponents[0] == "..")
                    return this._parent;

                if (pathComponents[0] == _name)
                    return this;

                IDirectoryComponent? subdirectory = _children.Find(child => child.Name == pathComponents[0]);

                if (subdirectory != null)
                    return subdirectory.ChDir(pathComponents[0]);

                return null;
            }
            else
            {
                IDirectoryComponent? subdirectory = _children.Find(child => child.Name == pathComponents[0]);

                if (subdirectory != null)
                    return subdirectory.ChDir(string.Join('/', pathComponents[1..]));

                return null;
            }
        }

        public IDirectoryComponent? Up()
        {
            return this._parent;
        }

        public int Count()
        {
            int count = 0;

            foreach(var component in _children)
            {
                if (component is File)
                    count += component.Count();
            }

            return count;
        }

        public int CountAll()
        {
            int count = 0;

            foreach(var component in _children)
            {
                count += component.CountAll();
            }

            return count;
        }
    }
}
