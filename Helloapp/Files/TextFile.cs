using System;
using System.IO;
using System.Text;

namespace Helloapp.Files;

public class TextFile : FileBase
{
    public TextFile() : base(".txt") { }

    public override string Insert(string filename, object str)
    {
		if (str is string == false) throw new ArgumentException();


        var path = Path.Combine(_dir, filename);
        var fileInfo = new FileInfo(path);

        if (!fileInfo.Exists)
            return "Файл с данным именем не найден!";

        using var stream = fileInfo.OpenWrite();
        var array = Encoding.Default.GetBytes((string)str);
        stream.Write(array, 0, array.Length);

        return "Строка успешно вставлена в файл";
    }
}
