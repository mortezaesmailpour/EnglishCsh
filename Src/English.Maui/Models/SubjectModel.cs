namespace English.UI.Models;

public class SubjectModel : BaseModel
{
    public ISubject BaseSubject { get; set; }
    public SubjectModel(ISubject baseSubject, string? name=null)
    {
        BaseSubject = baseSubject;
        Name = name ?? baseSubject.ToString() ?? "NULL";
    }
}
