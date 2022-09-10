namespace English.UI.Models;

public class SubjectModel : BaseModel
{
    public ISubject BaseSubject { get; set; }
    public SubjectModel(ISubject baseSubject)
    {
        BaseSubject = baseSubject;
        Name = baseSubject.ToString() ?? "NULL";
    }
}
