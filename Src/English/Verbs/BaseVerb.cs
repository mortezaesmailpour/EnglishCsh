namespace English.Verbs;

public class BaseVerb
{
    public string BaseForm { get; }
    public string PastSimple { get;  }
    public string PastParticiple { get; }
    protected string Gerund => (BaseForm.EndsWith("e")? BaseForm.Substring(0,BaseForm.Length-1): BaseForm )+ "ing";
    protected BaseVerb(string baseForm, string? pastSimple = null, string? pastParticiple = null)
    {
        BaseForm = baseForm;
        PastSimple = pastSimple ?? (BaseForm.EndsWith("e") ? BaseForm.Substring(0, BaseForm.Length - 1) : BaseForm) + "ed";
        PastParticiple = pastParticiple ?? PastSimple;
    }
}