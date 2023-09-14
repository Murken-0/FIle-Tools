using Helloapp.Entities;
using System;
using System.Text.Json;

namespace Helloapp.Files;

public class JsonFile : FileBase
{
    public JsonFile() : base(".json") { }

    public override string Insert(object data)
    {
        if (data is Student == false) throw new ArgumentException("Wrong type");

        if (_info == null || !_info.Exists) return "Файл необходимо создать перед использованием!";

        using var fs = _info.Create();
        JsonSerializer.Serialize(fs, (Student)data);

        return "Файл успешно изменен";
    }
}
