namespace English.UI.Models;

public class ObjectModel : BaseModel
{
    public IObject BaseObject { get; set; }
    public ObjectModel(IObject baseObject)
    {
        BaseObject = baseObject;
        Name = baseObject.ToString() ?? "NULL";
    }

}
