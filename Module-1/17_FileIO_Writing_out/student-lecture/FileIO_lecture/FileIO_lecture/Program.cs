using System;
using System.IO;

namespace FileIO_lecture
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a file in the local folder to write result to

            // using here...
            {
                // Get a list of folders from a directory on disk
                string path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                path = Path.Combine(path, "GIT");
                Console.WriteLine($"Getting folders in {path}");
                DirectoryInfo dir1 = new DirectoryInfo(path);

                // First, write the top-level folder

                // Find all the folders in this folder

            }

            // The file is now closed.  We can open it again for append to add more lines
            // using here...
            {
                for (int i = 1; i <= 100; i++)
                {
                    //sw.Write($"{i:000} ");
                    //if (i % 10 == 0)
                    //{
                    //    sw.WriteLine();
                    //}
                }
            }

            Console.WriteLine("Press a key to exit");
            Console.ReadKey();
        }
    }
}
