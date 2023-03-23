namespace English.UI.Models;

public class VerbModel : BaseModel
{
    public IVerb BaseVerb { get; set; }
    public string Tense { get; set; }
    public VerbModel(IVerb verb)
    {
        BaseVerb = verb;
        Name = verb.ToStringFor(SubjectPersonalPronouns.I);
        Tense = verb.Tense.ToString();
    }
}