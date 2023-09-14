using System;
using System.IO;
using System.Text;

namespace Helloapp.Files;

public abstract class FileBase
{
    protected string _dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    protected string _format;

    protected FileBase(string format)
    {
        _format = format;
    }

    public string Create(string filename)
    {
        var path = Path.Combine(_dir, filename + _format);
        var fileInfo = new FileInfo(path);
        using var stream = fileInfo.Create();

        return "Файл создан успешно";
    }

    public string Delete(string filename)
    {
        var path = Path.Combine(_dir, filename + _format);
        var fileInfo = new FileInfo(path);

        if (!fileInfo.Exists)
            return "Файл с данным именем не найден!";

        fileInfo.Delete();
        return "Файл удален успешно";
    }

    public string Read(string filename)
    {
        var path = Path.Combine(_dir, filename + _format);
        var fileInfo = new FileInfo(path);

        if (!fileInfo.Exists)
            return "Файл с данным именем не найден!";

        using var stream = fileInfo.OpenRead();
        var array = new byte[stream.Length];
        stream.Read(array, 0, array.Length);
        var textFromFile = Encoding.Default.GetString(array);

        return $"Текст из файла: {textFromFile}";
    }

    public abstract string Insert(string filename, object data);
}
