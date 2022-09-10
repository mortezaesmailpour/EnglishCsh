namespace English.UI.Models;

public class VerbModel : BaseModel
{
    public IVerb BaseVerb { get; set; }
    public VerbModel(IVerb verb)
    {
        BaseVerb = verb;
        Name = verb.Tense.ToString() ?? "NULL";
    }
}