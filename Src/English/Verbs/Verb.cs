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

    public IVerb Present() => ChangeTense((Tense & Tense.Modes) | Tense.Present);
    public IVerb Past() => ChangeTense((Tense & Tense.Modes) | Tense.Past);
    public IVerb Future() => ChangeTense((Tense & Tense.Modes) | Tense.Future);
    public IVerb Conditional() => ChangeTense((Tense & Tense.Modes) | Tense.Conditional);

    public IVerb Simple() => ChangeTense(Tense & Tense.Times);
    public IVerb Continuous() => ChangeTense(Tense | Tense.Continuous);
    public IVerb Perfect() => ChangeTense(Tense | Tense.Perfect);
    
    public IVerb ChangeTense(Tense tense) => tense switch
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
        Tense.PassivePastSimple => PassiveSimplePast(),
        Tense.PassivePastContinuous => PassivePastContinuous(),
        Tense.PassivePastPerfect => PassivePastPerfect(),
        Tense.PassivePastPerfectContinuous => PassivePastPerfectContinuous(),
        Tense.PassiveFutureSimple => PassiveSimpleFuture(),
        Tense.PassiveFutureContinuous => PassiveFutureContinuous(),
        Tense.PassiveFuturePerfect => PassiveFuturePerfect(),
        Tense.PassiveFuturePerfectContinuous => PassiveFuturePerfectContinuous(),
        Tense.PassiveConditionalSimple => PassiveSimpleConditional(),
        Tense.PassiveConditionalContinuous => PassiveConditionalContinuous(),
        Tense.PassiveConditionalPerfect => PassiveConditionalPerfect(),
        Tense.PassiveConditionalPerfectContinuous => PassiveConditionalPerfectContinuous(),
        _ => SimplePresent(),
    };

    public List<Verb> AllTenses => new()
    {
        SimplePresent(), PresentContinuous(), PresentPerfect(), PresentPerfectContinuous(),
        SimplePast(), PastContinuous(), PastPerfect(), PastPerfectContinuous(),
        SimpleFuture(), FutureContinuous(), FuturePerfect(), FuturePerfectContinuous(),
        SimpleConditional(), ConditionalContinuous(), ConditionalPerfect(), ConditionalPerfectContinuous(),
        PassiveSimplePresent(), PassivePresentContinuous(), PassivePresentPerfect(), PassivePresentPerfectContinuous(),
        PassiveSimplePast(), PassivePastContinuous(), PassivePastPerfect(), PassivePastPerfectContinuous(),
        PassiveSimpleFuture(), PassiveFutureContinuous(), PassiveFuturePerfect(), PassiveFuturePerfectContinuous(),
        PassiveSimpleConditional(), PassiveConditionalContinuous(), PassiveConditionalPerfect(), PassiveConditionalPerfectContinuous(),
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
    public PassivePastSimple PassiveSimplePast() => new(BaseForm, PastSimple, PastParticiple);
    public PassivePastContinuous PassivePastContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PassivePastPerfect PassivePastPerfect() => new(BaseForm, PastSimple, PastParticiple);
    public PassivePastPerfectContinuous PassivePastPerfectContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PassiveFutureSimple PassiveSimpleFuture() => new(BaseForm, PastSimple, PastParticiple);
    public PassiveFutureContinuous PassiveFutureContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PassiveFuturePerfect PassiveFuturePerfect() => new(BaseForm, PastSimple, PastParticiple);
    public PassiveFuturePerfectContinuous PassiveFuturePerfectContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PassiveConditionalSimple PassiveSimpleConditional() => new(BaseForm, PastSimple, PastParticiple);
    public PassiveConditionalContinuous PassiveConditionalContinuous() => new(BaseForm, PastSimple, PastParticiple);
    public PassiveConditionalPerfect PassiveConditionalPerfect() => new(BaseForm, PastSimple, PastParticiple);
    public PassiveConditionalPerfectContinuous PassiveConditionalPerfectContinuous() => new(BaseForm, PastSimple, PastParticiple);
}