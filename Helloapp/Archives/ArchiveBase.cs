using System;
using System.IO;

namespace Helloapp.Archives
{
	public abstract class ArchiveBase
	{
		protected string _dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		protected string _format;
		protected FileInfo _fileInfo;
		protected FileInfo _info;

		protected ArchiveBase(string format)
		{
			_format = format;
		}

		public abstract string Create(string archiveName);

		public abstract string AddFile(string fileName);

		public abstract string Unzip();

		public string Delete()
		{
			if (_info == null || !_info.Exists)
				return "Архив необходимо создать перед удалением!";
			if (_fileInfo == null || !_fileInfo.Exists)
				return "Файл необходимо разархифировать перед удалением!";

			_info.Delete();
			_fileInfo.Delete();
			return "Архив и файл удалены успешно";
		}

	}
}
