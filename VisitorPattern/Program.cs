namespace CompositePattern
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                FileInfo file;

                if (args.Length > 0)
                {
                    if (args.Length > 1)
                        Console.WriteLine("Can only process one file at a time. Using only first entry");

                    file = new(args[0]);
                }
                else
                {
                    Console.WriteLine("Enter a directory to a file formatted for this simulation");

                    string? path = Console.ReadLine();
                    if (path != null)
                        file = new(path);
                    else
                    {
                        Console.WriteLine("Not valid input");
                        return;
                    }
                }

                Task<Directory> task = DirectoryBuilder.BuildDirectoryTree(file);

                await task;

                Explorer exp = new(task.Result);

                exp.Process();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
    }
}