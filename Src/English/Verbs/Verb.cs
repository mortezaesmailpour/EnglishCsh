using English.SentenceElements;
using English.Verbs.Past;
using English.Verbs.Present;

namespace English.Verbs;

public abstract class Verb : BaseVerb, IVerb
{
    public Tense Tense { get; }

    public abstract string ToString(ISubject subject);

    protected Verb(string baseForm, string? pastSimple=null, string? pastParticiple = null, Tense? tense = null) : base(baseForm, pastSimple,
        pastParticiple)
    {
        Tense = tense ?? Tense.PresentSimple;
    }

    public Verb Present() => ChangeTense((Tense & Tense.Modes) | Tense.Present);
    public Verb Past() => ChangeTense((Tense & Tense.Modes) | Tense.Past);
    public Verb Future() => ChangeTense((Tense & Tense.Modes) | Tense.Future);
    public Verb Conditional() => ChangeTense((Tense & Tense.Modes) | Tense.Conditional);

    public Verb Simple() => ChangeTense(Tense & Tense.Times);
    public Verb Continuous() => ChangeTense(Tense | Tense.Continuous);
    public Verb Perfect() => ChangeTense(Tense | Tense.Perfect);
    
    private Verb ChangeTense(Tense tense) => tense switch
    {
        Tense.PresentSimple => new PresentSimple(BaseForm, PastSimple, PastParticiple),
        Tense.PresentContinuous => new PresentContinuous(BaseForm, PastSimple, PastParticiple),
        Tense.PresentPerfect => new PresentPerfect(BaseForm, PastSimple, PastParticiple),
        Tense.PresentPerfectContinuous => new PresentPerfectContinuous(BaseForm, PastSimple, PastParticiple),
        Tense.PastSimple => new PastSimple(BaseForm, PastSimple, PastParticiple),
        Tense.PastContinuous => new PastContinuous(BaseForm, PastSimple, PastParticiple),
        Tense.PastPerfect => new PastPerfect(BaseForm, PastSimple, PastParticiple),
        Tense.PastPerfectContinuous => new PastPerfectContinuous(BaseForm, PastSimple, PastParticiple),
        _ => new PresentSimple(BaseForm, PastSimple, PastParticiple),
    };
}