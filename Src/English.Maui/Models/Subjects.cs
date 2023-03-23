namespace English.UI.Models;

public class Subjects
{
    public List<ISubject> List { get; set; }
    public string Name { get; set; }
    protected Subjects()
    {
        List = new List<ISubject>();
    }
}
