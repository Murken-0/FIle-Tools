using System.IO;
using Ionic.Zip;

namespace Helloapp.Archives;

public class ZipArchive : ArchiveBase
{
	public ZipArchive() : base(".zip") { }

	public override string Create(string archiveName)
	{
		using var zip = new ZipFile();
		_info = new FileInfo(Path.Combine(_dir, archiveName + _format));
		if (_info.Exists) _info.Delete();
		zip.Save(_info.FullName);

		return $"Архив {archiveName + _format} создан успешно"; 
	}

	public override string AddFile(string fileName)
	{
		if (_info == null || !_info.Exists) return "Архив необходимо создать перед использованием";

		var fileInfo = new FileInfo(Path.Combine(_dir, fileName));
		if (fileInfo.Exists) _fileInfo = fileInfo;
		else return $"Файл с именем {fileName} не найден";

		using var zip = ZipFile.Read(_info.FullName);
		zip.AddFile(_fileInfo.FullName, "");
		zip.Save();
		_fileInfo.Delete();
		return $"Файл {_fileInfo.FullName} добавлен успешно";
	}

	public override string Unzip()
	{
		if (_info == null || !_info.Exists) return "Архив необходимо создать перед использованием";

		using var zip = ZipFile.Read(_info.FullName);
		zip.ExtractAll(_dir);
		return $"Файл {_fileInfo.Name} был успешно разархивирован";
	}
}
