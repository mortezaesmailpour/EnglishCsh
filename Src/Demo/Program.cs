using English.PersonGenderNumbers;
using English.Pronouns;
using English.SentenceElements;
using English.Verbs.Past;



ISubject s = new SubjectPersonalPronouns(Person.First);
var v = new PastPerfectContinuous("write","wrote","written");

Console.WriteLine(s + v);





//
//
// Word i = new("I");
// Word am = new("am");
// var book = new ObjectWord("book");
// var box = new ObjectWord("box");
// var he = new SubjectWord(new SubjectPersonalPronouns(Person.Third, Number.Singular, Gender.Male));
// var hadwriteen = new VerbWord(new PastPerfect("write", "wrote", "written"));
// var w3 = i + am;
// var w4 = i - am + w3 - (-i);
// Console.WriteLine(w3);
// Console.WriteLine(+book);
// Console.WriteLine(+box);
// hadwriteen.Verb = hadwriteen.Verb.Continuous();
// Console.WriteLine(he+hadwriteen+(+book));