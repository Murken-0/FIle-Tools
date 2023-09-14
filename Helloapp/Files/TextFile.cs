using System;
using System.Text;

namespace Helloapp.Files;

public class TextFile : FileBase
{
    public TextFile() : base(".txt") { }

    public override string Insert(object str)
    {
		if (str is string == false) throw new ArgumentException("Wrong type");

        if (_info == null || !_info.Exists)
            return "Файл необходимо создать перед использованием!";

        using var stream = _info.OpenWrite();
        var array = Encoding.Default.GetBytes((string)str);
        stream.Write(array, 0, array.Length);

        return $"Строка \"{(string)str}\" успешно вставлена в файл";
    }
}
