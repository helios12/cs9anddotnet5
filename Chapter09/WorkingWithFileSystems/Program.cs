using System;
using System.IO;

using static System.Console;
using static System.Environment;
using static System.IO.Directory;
using static System.IO.Path;

namespace WorkingWithFileSystems
{
    class Program
    {
        static void Main(string[] args)
        {
            // OutputFileSystemInfo();
            // WorkWithDrives();
            WorkWithDirectories();            
        }

        static void OutputFileSystemInfo()
        {
            WriteLine("{0,-33} {1}", "Path.Separator", PathSeparator);
            WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);
            WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory()", GetCurrentDirectory());
            WriteLine("{0,-33} {1}", "Environment.CurrentDirectory", CurrentDirectory);
            WriteLine("{0,-33} {1}", "Environment.SystemDirectory", SystemDirectory);
            WriteLine("{0,-33} {1}", "Path.GetTempPath()", GetTempPath());
            WriteLine("GetFolderPath(SpecialFolder");
            WriteLine("\t{0,-33} {1}", ".System", GetFolderPath(SpecialFolder.System));
            WriteLine("\t{0,-33} {1}", ".ApplicationData", GetFolderPath(SpecialFolder.ApplicationData));
            WriteLine("\t{0,-33} {1}", ".MyDocuments", GetFolderPath(SpecialFolder.MyDocuments));
            WriteLine("\t{0,-33} {1}", ".Personal", GetFolderPath(SpecialFolder.Personal));
        }

        static void WorkWithDrives()
        {
            WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}", "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
                        drive.Name, drive.DriveType, drive.DriveFormat,
                        drive.TotalSize, drive.AvailableFreeSpace
                    );
                }
                else
                {
                    WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
                }
            }
        }

        static void WorkWithDirectories()
        {
            string newFolder = Combine(GetFolderPath(SpecialFolder.Personal), "Code", "Chapter09", "NewFolder");
            WriteLine($"Working with {newFolder}");
            WriteLine($"Does it exist? {Exists(newFolder)}");
            WriteLine("Creating it...");
            CreateDirectory(newFolder);
            WriteLine($"Does it exist? {Exists(newFolder)}");
            Write("Confirm that directory exists and press ENTER: ");
            //ReadLine();
            WriteLine("Delete it...");
            Delete(newFolder, recursive: true);
            WriteLine($"Does it exist? {Exists(newFolder)}");
        }
    }
}
