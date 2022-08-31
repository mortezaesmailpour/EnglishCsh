namespace English;

[Flags]
public enum Tense
{
    Present = 1,
    Past = 2,
    Future = 4,
    Conditional = 8,
    Times = Present | Past | Future | Conditional,
    Modes = Continuous | Perfect,

    Continuous = 16,
    Perfect = 32,

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
}