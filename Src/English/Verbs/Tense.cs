namespace English.Verbs;

[Flags]
public enum Tense
{
    Present = 1,
    Past = 2,
    Future = 4,
    Conditional = 8,

    Times = Present | Past | Future | Conditional,
    Modes = Continuous | Perfect,
    Forms = Modes | Passive,

    Continuous = 16,
    Perfect = 32,

    Passive = 64,

    PresentSimple = Present,
    PresentContinuous = Present | Continuous,
    PresentPerfect = Present | Perfect,
    PresentPerfectContinuous = Present | Perfect | Continuous,

    PastSimple = Past,
    PastContinuous = Past | Continuous,
    PastPerfect = Past | Perfect,
    PastPerfectContinuous = Past | Perfect | Continuous,

    FutureSimple = Future,
    FutureContinuous = Future | Continuous,
    FuturePerfect = Future | Perfect,
    FuturePerfectContinuous = Future | Perfect | Continuous,

    ConditionalSimple = Conditional,
    ConditionalContinuous = Conditional | Continuous,
    ConditionalPerfect = Conditional | Perfect,
    ConditionalPerfectContinuous = Conditional | Perfect | Continuous,



    PassivePresentSimple = Present | Passive,
    PassivePresentContinuous = Present | Continuous | Passive,
    PassivePresentPerfect = Present | Perfect | Passive,
    PassivePresentPerfectContinuous = Present | Perfect | Continuous | Passive,
    
    PassivePastSimple = Past | Passive,
    PassivePastContinuous = Past | Continuous | Passive,
    PassivePastPerfect = Past | Perfect | Passive,
    PassivePastPerfectContinuous = Past | Perfect | Continuous | Passive,
    
    PassiveFutureSimple = Future | Passive,
    PassiveFutureContinuous = Future | Continuous | Passive,
    PassiveFuturePerfect = Future | Perfect | Passive,
    PassiveFuturePerfectContinuous = Future | Perfect | Continuous | Passive,
    
    PassiveConditionalSimple = Conditional | Passive,
    PassiveConditionalContinuous = Conditional | Continuous | Passive,
    PassiveConditionalPerfect = Conditional | Perfect | Passive,
    PassiveConditionalPerfectContinuous = Conditional | Perfect | Continuous | Passive,
}