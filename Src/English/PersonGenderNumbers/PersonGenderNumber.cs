namespace English.PersonGenderNumbers;

public enum PersonGenderNumber
{
    First = 1,
    Second = 2,
    Third = 3,

    Singular = 0,
    Plural = 4,

    Male = 8,
    Female = 16,
    Neuter = 24,

    FirstSingular = First | Singular,
    FirstPlural = First | Plural,
    ThirdSingularMale = Third | Singular | Male,
    ThirdSingularFemale = Third | Singular | Female,
    ThirdSingularNeuter = Third | Singular | Neuter,
    ThirdPlural = Third | Plural,
}