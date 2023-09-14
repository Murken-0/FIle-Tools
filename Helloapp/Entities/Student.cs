using System;

namespace Helloapp.Entities;

[Serializable]
public class Student
{
    public string Name { get; set; }
    public string Group { get; set; }

    public Student() { }

    public Student(string name, string group)
    {
        Name = name;
        Group = group;
    }
}
