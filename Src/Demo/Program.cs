using English.PersonGenderNumbers;
using English.Pronouns;
using English.SentenceElements;
using English.Verbs;


ISubject subject = new SubjectPersonalPronouns(Person.Third,Number.Singular,Gender.Female);
IObject obj = new ObjectPersonalPronouns(Person.First,Number.Singular);
IObject obj2 = new ObjectPersonalPronouns(Person.Third,Number.Singular,Gender.Neuter);
var verb = new Verb("write","wrote","written").Past().Perfect();

Console.WriteLine(subject + verb + obj + obj2);
