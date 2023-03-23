using English.Persons;
using English.Pronouns;
using English.SentenceElements;
using English.Verbs;

ISubject subject = new SubjectPersonalPronouns(Person.Third, Number.Singular, Gender.Female);
IObject obj = new ObjectPersonalPronouns(Person.First, Number.Singular);
var verb = new Verb("fallow").PastPerfectContinuous();

Console.WriteLine(subject + verb + obj);


Console.WriteLine("for all personal pronouns :");
foreach (var pronoun in SubjectPersonalPronouns.All)
    Console.WriteLine((pronoun as ISubject) + verb + obj);
foreach (var pronoun in ObjectPersonalPronouns.All)
    Console.WriteLine(subject + verb + pronoun);

Console.WriteLine("for all tenses :");
foreach (var v in verb.AllTenses)
    Console.WriteLine(subject + v + obj);



//void main(object arg[])
//{
//    Console.WriteLine("hey");
//}

