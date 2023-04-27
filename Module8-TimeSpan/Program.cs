using System;
using System.IO;

namespace DirectoryManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DirectoryInfo dirClean = new DirectoryInfo(@"C:\Users\balak\OneDrive\Рабочий стол\папка");
                TimeSpan timeSpan = TimeSpan.FromMinutes(30);
                if (dirClean.Exists)
                {
                    DirectoryInfo[] dirs = dirClean.GetDirectories();
                    foreach (DirectoryInfo dir in dirs)
                    {
                       if (dir.LastAccessTime + timeSpan < DateTime.Now)
                        {
                            dir.Delete(true);
                        }
                    }

                    FileInfo[] files = dirClean.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        if (file.LastAccessTime + timeSpan < DateTime.Now)
                        {
                            file.Delete();
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Такой папки не существует");
                }
                
            }
                catch(Exception ex)
            {
               Console.WriteLine($"Could not find {ex.Message}");
            }

        }
    }
}