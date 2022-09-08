using English.PersonGenderNumbers;
using English.Persons;
using English.SentenceElements;
using English.Verbs.Conditional;
using English.Verbs.Future;
using English.Verbs.Past;
using English.Verbs.Present;

namespace English.Verbs;

public class Verb : BaseVerb, IVerb
{
    public Tense Tense { get; }

    public virtual string ToStringFor(IPersons subject) => ChangeTense(Tense).ToStringFor(subject);

    public Verb(string baseForm, string? pastSimple=null, string? pastParticiple = null, Tense? tense = null) : base(baseForm, pastSimple,
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
        Tense.PresentSimple => SimplePresent(),
        Tense.PresentContinuous => PresentContinuous(),
        Tense.PresentPerfect => PresentPerfect(),
        Tense.PresentPerfectContinuous => PresentPerfectContinuous(),
        Tense.PastSimple => SimplePast(),
        Tense.PastContinuous => PastContinuous(),
        Tense.PastPerfect => PastPerfect(),
        Tense.PastPerfectContinuous => PastPerfectContinuous(),
        Tense.FutureSimple => SimpleFuture(),
        Tense.FutureContinuous => FutureContinuous(),
        Tense.FuturePerfect => FuturePerfect(),
        Tense.FuturePerfectContinuous => FuturePerfectContinuous(),
        Tense.ConditionalSimple => SimpleConditional(),
        Tense.ConditionalContinuous => ConditionalContinuous(),
        Tense.ConditionalPerfect => ConditionalPerfect(),
        Tense.ConditionalPerfectContinuous => ConditionalPerfectContinuous(),
        Tense.PassivePresentSimple => PassiveSimplePresent(),
        Tense.PassivePresentContinuous => PassivePresentContinuous(),
        Tense.PassivePresentPerfect => PassivePresentPerfect(),
        Tense.PassivePresentPerfectContinuous => PassivePresentPerfectContinuous(),
        Tense.PassivePastSimple => SimplePast(),
        Tense.PassivePastContinuous => PastContinuous(),
        Tense.PassivePastPerfect => PastPerfect(),
        Tense.PassivePastPerfectContinuous => PastPerfectContinuous(),
        Tense.PassiveFutureSimple => SimpleFuture(),
        Tense.PassiveFutureContinuous => FutureContinuous(),
        Tense.PassiveFuturePerfect => FuturePerfect(),
        Tense.PassiveFuturePerfectContinuous => FuturePerfectContinuous(),
        Tense.PassiveConditionalSimple => SimpleConditional(),
        Tense.PassiveConditionalContinuous => ConditionalContinuous(),
        Tense.PassiveConditionalPerfect => ConditionalPerfect(),
        Tense.PassiveConditionalPerfectContinuous => ConditionalPerfectContinuous(),
        _ => SimplePresent(),
    };

    public List<Verb> AllTenses => new()
    {
        SimplePresent(), PresentContinuous(), PresentPerfect(), PresentPerfectContinuous(),
        SimplePast(), PastContinuous(), PastPerfect(), PastPerfectContinuous(),
        SimpleFuture(), FutureContinuous(), FuturePerfect(), FuturePerfectContinuous(),
        SimpleConditional(), ConditionalContinuous(), ConditionalPerfect(), ConditionalPerfectContinuous(),
        PassiveSimplePresent(), PassivePresentContinuous(), PassivePresentPerfect(), PassivePresentPerfectContinuous(),
    };
    public PresentSimple SimplePresent() => new(BaseForm, PastSimple, PastParticiple);
    public PresentContinuous PresentContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PresentPerfect PresentPerfect() => new(BaseForm, PastSimple, PastParticiple);
    public PresentPerfectContinuous PresentPerfectContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PastSimple SimplePast() => new(BaseForm, PastSimple, PastParticiple);
    public PastContinuous PastContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PastPerfect PastPerfect() => new(BaseForm, PastSimple, PastParticiple);
    public PastPerfectContinuous PastPerfectContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public FutureSimple SimpleFuture() => new(BaseForm, PastSimple, PastParticiple);
    public FutureContinuous FutureContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public FuturePerfect FuturePerfect() => new(BaseForm, PastSimple, PastParticiple);
    public FuturePerfectContinuous FuturePerfectContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public ConditionalSimple SimpleConditional() => new(BaseForm, PastSimple, PastParticiple);
    public ConditionalContinuous ConditionalContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public ConditionalPerfect ConditionalPerfect() => new(BaseForm, PastSimple, PastParticiple);
    public ConditionalPerfectContinuous ConditionalPerfectContinuous() => new(BaseForm, PastSimple, PastParticiple);


    public PassivePresentSimple PassiveSimplePresent() => new(BaseForm, PastSimple, PastParticiple);
    public PassivePresentContinuous PassivePresentContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PassivePresentPerfect PassivePresentPerfect() => new(BaseForm, PastSimple, PastParticiple);
    public PassivePresentPerfectContinuous PassivePresentPerfectContinuous() => new(BaseForm, PastSimple, PastParticiple);
}