using System;
using System.IO;
using System.Text;

namespace Helloapp.Files;

public abstract class FileBase
{
    protected string _dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    protected string _format;
    protected FileInfo _info;

    protected FileBase(string format)
    {
        _format = format;
    }

    public string Create(string filename)
    {
        var path = Path.Combine(_dir, filename + _format);
        _info = new FileInfo(path);
        using var stream = _info.Create();

        return $"Файл {filename + _format} создан успешно";
    }

    public string Delete()
    {
        if (_info == null || !_info.Exists)
            return "Файл необходимо создать перед использованием!";

        _info.Delete();
        return "Файл удален успешно";
    }

    public string Read()
    {
        if (_info == null || !_info.Exists)
            return "Файл необходимо создать перед использованием!";

        using var stream = _info.OpenRead();
        var array = new byte[stream.Length];
        stream.Read(array, 0, array.Length);
        var textFromFile = Encoding.Default.GetString(array);

        return $"Текст из файла: {textFromFile}";
    }

    public abstract string Insert(object data);
}
