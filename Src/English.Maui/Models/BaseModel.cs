namespace English.UI.Models;

public class BaseModel
{
    public string Name { get; set; }
    public override string ToString()
    {
        return Name;
    }
}
