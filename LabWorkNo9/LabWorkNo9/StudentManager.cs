using System.Collections;

namespace LabWorkNo9;


public class StudentManager : IEnumerable<BaseStudent>
{
    private readonly List<BaseStudent> _students = new();

    public void AddStudent(BaseStudent student) => _students.Add(student);
    public BaseStudent? GetStudent(string id) => _students.FirstOrDefault(s => s.Id == id);

    public IEnumerator<BaseStudent> GetEnumerator() => _students.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
