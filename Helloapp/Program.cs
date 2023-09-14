using Helloapp.Files;
using Helloapp.Archives;
using Helloapp.Entities;
using Helloapp.Drives;
using System;

namespace Helloapp;

class Program
{
	static readonly FileBase fileTxt = new TextFile();
	static readonly FileBase fileJson = new JsonFile();
	static readonly FileBase fileXml = new XmlFile();
	static readonly ArchiveBase archive = new ZipArchive();

	public static void Main()
	{
		while (true)
		{
			ChooseAction();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
		}
	}

	public static void ChooseAction()
	{
		Console.Clear();
		Console.WriteLine("| File Utils |");
		Console.WriteLine("--------------");
		Console.WriteLine("0 - Drives Info");
		Console.WriteLine("1 - Text");
		Console.WriteLine("2 - Json");
		Console.WriteLine("3 - Xml");
		Console.WriteLine("4 - Zip");
		var key = Console.ReadKey();
		switch (key.Key)
		{
			case ConsoleKey.D1:
				PrintTextMenu();
				break;
			case ConsoleKey.D2:
				PrintJsonMenu();
				break;
			case ConsoleKey.D3:
				PrintXmlMenu();
				break;
			case ConsoleKey.D4:
				PrintZipMenu();
				break;
			case ConsoleKey.D0:
				PrintDrivesInfo();
				break;
			default:
				Console.WriteLine("Wrong key!");
				break;
		}
	}

	public static void PrintDrivesInfo()
	{
		Console.Clear();
		DrivesInfo.Print();
	}

	public static void PrintTextMenu()
	{
		Console.Clear();
		Console.WriteLine("| File Utils / Text |");
		Console.WriteLine("---------------------");
		Console.WriteLine("1 - Create file");
		Console.WriteLine("2 - Insert string into file");
		Console.WriteLine("3 - Read file");
		Console.WriteLine("4 - Delete file");
		var key = Console.ReadKey();
		Console.Clear();
		switch (key.Key)
		{
			case ConsoleKey.D1:
				Console.WriteLine(fileTxt.Create(Input("File name: ")));
				break;
			case ConsoleKey.D2:
				Console.WriteLine(fileTxt.Insert(Input("String: ")));
				break;
			case ConsoleKey.D3:
				Console.WriteLine(fileTxt.Read());
				break;
			case ConsoleKey.D4:
				Console.WriteLine(fileTxt.Delete());
				break;
			default:
				Console.WriteLine("Wrong key!");
				break;
		}
	}

	public static void PrintJsonMenu()
	{
		Console.Clear();
		Console.WriteLine("| File Utils / Json |");
		Console.WriteLine("---------------------");
		Console.WriteLine("1 - Create file");
		Console.WriteLine("2 - Insert Student into file");
		Console.WriteLine("3 - Read file");
		Console.WriteLine("4 - Delete file");
		var key = Console.ReadKey();
		Console.Clear();
		switch (key.Key)
		{
			case ConsoleKey.D1:
				Console.WriteLine(fileJson.Create(Input("File name: ")));
				break;
			case ConsoleKey.D2:
				Console.WriteLine(fileJson.Insert(
					new Student(Input("Student name: "), Input("Student group: "))));
				break;
			case ConsoleKey.D3:
				Console.WriteLine(fileJson.Read());
				break;
			case ConsoleKey.D4:
				Console.WriteLine(fileJson.Delete());
				break;
			default:
				Console.WriteLine("Wrong key!");
				break;
		}
	}

	public static void PrintXmlMenu()
	{
		Console.Clear();
		Console.WriteLine("| File Utils / Xml |");
		Console.WriteLine("--------------------");
		Console.WriteLine("1 - Create file");
		Console.WriteLine("2 - Insert Student into file");
		Console.WriteLine("3 - Read file");
		Console.WriteLine("4 - Delete file");
		var key = Console.ReadKey();
		Console.Clear();
		switch (key.Key)
		{
			case ConsoleKey.D1:
				Console.WriteLine(fileXml.Create(Input("File name: ")));
				break;
			case ConsoleKey.D2:
				Console.WriteLine(fileXml.Insert(
					new Student(Input("Student name: "), Input("Student group: "))));
				break;
			case ConsoleKey.D3:
				Console.WriteLine(fileXml.Read());
				break;
			case ConsoleKey.D4:
				Console.WriteLine(fileXml.Delete());
				break;
			default:
				Console.WriteLine("Wrong key!");
				break;
		}
	}

	public static void PrintZipMenu()
	{
		Console.Clear();
		Console.WriteLine("| File Utils / Zip |");
		Console.WriteLine("--------------------");
		Console.WriteLine("1 - Create archive");
		Console.WriteLine("2 - Insert file into archive");
		Console.WriteLine("3 - Extract file from archive");
		Console.WriteLine("4 - Delete archive and file");
		var key = Console.ReadKey();
		Console.Clear();
		switch (key.Key)
		{
			case ConsoleKey.D1:
				Console.WriteLine(archive.Create(Input("Archive name: ")));
				break;
			case ConsoleKey.D2:
				Console.WriteLine(archive.AddFile(Input("File name: ")));
				break;
			case ConsoleKey.D3:
				Console.WriteLine(archive.Unzip());
				break;
			case ConsoleKey.D4:
				Console.WriteLine(archive.Delete());
				break;
			default:
				Console.WriteLine("Wrong key!");
				break;
		}
	}

	public static string Input(string message)
	{
		Console.Write(message);
		return Console.ReadLine();
	}
}