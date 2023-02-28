namespace English.UI.Models;

public class ObjectModel : BaseModel
{
    public IObject BaseObject { get; set; }
    public ObjectModel(IObject baseObject, string? name = null)
    {
        BaseObject = baseObject;
        Name = name ?? baseObject.ToString() ?? "NULL";
    }

}
