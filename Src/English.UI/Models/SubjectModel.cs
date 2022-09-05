using English.SentenceElements;

namespace English.UI.Models;

public class SubjectModel
{
    public ISubject BaseSubject { get; set; }
    public string Name { get; set; }
    public SubjectModel(ISubject baseSubject)
    {
        BaseSubject = baseSubject;
        Name = BaseSubject.ToString() ?? "NULL";
    }
    public override string ToString()
    {
        return Name;
    }
}
