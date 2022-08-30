namespace English.Verbs;

public class BaseVerb
{
    protected string BaseForm { get; }
    protected string PastSimple { get;  }
    protected string PastParticiple { get; }
    protected string Gerund => BaseForm + "ing";
    protected BaseVerb(string baseForm, string? pastSimple = null, string? pastParticiple = null)
    {
        BaseForm = baseForm;
        PastSimple = pastSimple ?? baseForm + "ed";
        PastParticiple = pastParticiple ?? PastSimple;
    }
}