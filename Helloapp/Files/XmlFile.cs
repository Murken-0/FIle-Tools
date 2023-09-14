using System;
using System.Xml.Serialization;
using Helloapp.Entities;

namespace Helloapp.Files
{
	public class XmlFile : FileBase
	{
		public XmlFile() : base(".xml") { }

		public override string Insert(object data)
		{
			if (data is Student == false) throw new ArgumentException("Wrong type");

			if (_info == null || !_info.Exists) return "Файл необходимо создать перед использованием!";

			using var fs = _info.Create();
			var serializer = new XmlSerializer(typeof(Student));
			serializer.Serialize(fs, (Student)data);

			return "Файл успешно создан";
		}
	}
}
