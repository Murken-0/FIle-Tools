using Helloapp.Entities;
using System;
using System.IO;
using System.Text.Json;

namespace Helloapp.Files;

public class JsonFile : FileBase
{
    public JsonFile() : base(".json") { }

    public override string Insert(string filename, object data)
    {
        if (data is Student == false) throw new ArgumentException();

        var path = Path.Combine(_dir, filename + _format);
        var fileInfo = new FileInfo(path);
        if (!fileInfo.Exists) return "Файл с данным именем не найден";

        using var fs = fileInfo.Create();
        JsonSerializer.Serialize(fs, (Student)data);

        return "Файл успешно создан";
    }
}
