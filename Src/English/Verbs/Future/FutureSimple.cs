namespace English.Verbs.Future;

public class FutureSimple : Verb
{
    public FutureSimple(string baseForm, string? pastSimple = null, string? pastParticiple = null)
        : base(baseForm, pastSimple, pastParticiple, Tense.FutureSimple)
    {
    }

    public override string ToStringFor(IPersons  subject) => "will " + BaseForm;
}