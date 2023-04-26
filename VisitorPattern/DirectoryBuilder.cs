using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    internal static class DirectoryBuilder
    {
        public static async Task<Directory> BuildDirectoryTree(FileInfo file)
        {
            using StreamReader stream = new(file.OpenRead());

            Task<string?> task = stream.ReadLineAsync();

            await task;

            string? line = task.Result ?? throw new InvalidOperationException("No Structure in the specified file");
            if (!line.Contains(':'))
                throw new InvalidOperationException("Root of file must be a directory, not a file");
                
            Directory root = new(line.Trim(':'), null);

            Directory current = root;

            int lastTab = line.TakeWhile(char.IsWhiteSpace).Count();
            int currentTab;

            task = stream.ReadLineAsync();

            await task;

            line = task.Result;

            while (line != null)
            {
                currentTab = line.TakeWhile(char.IsWhiteSpace).Count();

                line = line.Trim();

                if (line.Split().Length != 1)
                    throw new ArgumentException("Cannon have multiple items per line");

                if (currentTab < lastTab && current.Parent != null)
                {
                    current = current.Parent;
                }

                if (line.Contains(':'))
                {
                    Directory sub = new(line.Trim(':'), current);
                    current.Add(sub);
                    current = sub;
                }
                else
                {
                    File sub = new(line);
                    current.Add(sub);
                }

                task = stream.ReadLineAsync();

                await task;

                line = task.Result;

                lastTab = currentTab;
            }

            return root;
        }
    }
}
