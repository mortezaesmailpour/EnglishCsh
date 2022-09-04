namespace English.Verbs;

public class BaseVerb
{
    public string BaseForm { get; }
    public string PastSimple { get;  }
    public string PastParticiple { get; }
    protected string Gerund => BaseForm + "ing";
    protected BaseVerb(string baseForm, string? pastSimple = null, string? pastParticiple = null)
    {
        BaseForm = baseForm;
        PastSimple = pastSimple ?? baseForm + "ed";
        PastParticiple = pastParticiple ?? PastSimple;
    }
}