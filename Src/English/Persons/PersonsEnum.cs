namespace English.Persons;

[Flags]
public enum PersonsEnum
{
    First = 1,
    Second = 2,
    Third = 3,

    Singular = 4,
    Plural = 8,

    FirstSingular = First | Singular,
    FirstPlural = First | Plural,
    //Seconds = Second | Singular | Plural,
    ThirdSingular = Third | Singular,
    ThirdPlural = Third | Plural,
}