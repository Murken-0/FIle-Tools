namespace Helloapp.Entities;

public class Student
{
    public string Name { get; set; }
    public int Course { get; set; }
    public string Group { get; set; }

    public Student(string name, int course, string group)
    {
        Name = name;
        Course = course;
        Group = group;
    }
}
