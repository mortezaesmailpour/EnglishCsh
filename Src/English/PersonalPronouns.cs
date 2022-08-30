using System.Diagnostics;

namespace English;

public class PersonalPronouns : ISubjet
{
    public Gender Gender { get; set; }
    public Person Person { get; set; }
    public override string ToString()
    {

        string result = "thisisresult";



        return result;
    }
}