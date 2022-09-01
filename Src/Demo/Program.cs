

using English.Words;

Word w1 = new (){Name = "first"};
Word w2 = new (){Name = "Second"};
Word w3 = Word.Plus( w1,w2);
var w4 = w1- w2;
Console.WriteLine(w3);
Console.WriteLine(w4);