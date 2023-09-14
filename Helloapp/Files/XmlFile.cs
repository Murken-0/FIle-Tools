using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Helloapp.Entities;

namespace Helloapp.Files
{
	public class XmlFile : FileBase
	{
		public XmlFile() : base(".xml") { }

		public override string Insert(string filename, object data)
		{
			if (data is Student == false) throw new ArgumentException();

			var path = Path.Combine(_dir, filename + _format);
			var fileInfo = new FileInfo(path);
			if (!fileInfo.Exists) return "Файл с данным именем не найден";

			using var fs = fileInfo.Create();
			var serializer = new XmlSerializer(typeof(Student));
			serializer.Serialize(fs, (Student)data);

			return "Файл успешно создан";
		}
	}
}
