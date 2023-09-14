using System;
using System.IO;

namespace Helloapp.Drives;

public static class DrivesInfo
{
    public static void Print()
    {
        DriveInfo[] drives = DriveInfo.GetDrives();

        foreach (DriveInfo drive in drives)
        {
            Console.WriteLine($"Name: {drive.Name}");
            Console.WriteLine($"Type: {drive.DriveType}");
            if (drive.IsReady)
            {
                Console.WriteLine($"Copacity: {drive.TotalSize}");
                Console.WriteLine($"Free space: {drive.TotalFreeSpace}");
                Console.WriteLine($"Mark: {drive.VolumeLabel}");
            }
            Console.WriteLine();
        }
    }
}
