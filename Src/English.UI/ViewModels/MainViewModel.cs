namespace English.UI.ViewModels;

public class MainViewModel : BaseViewModel
{
    public SubjectModel Subject
    {
        get => _subject;
        set
        {
            SetField(ref _subject, value);
            UpdateResult();
        }
        
    }
    private SubjectModel _subject;
    public ObjectModel Object
    {
        get => _object;
        set
        {
            SetField(ref _object, value);
            UpdateResult();
        }
    }
    private ObjectModel _object;
    public VerbModel Verb
    {
        get => _verb;
        set
        {
            SetField(ref _verb, value);
            UpdateResult();
        }
    }
    public VerbModel _verb;
    public ICommand UpdateCommand { get; }
    public string Result { get; private set; }
    public MainViewModel()
    {
        UpdateCommand = new CommandHandler(UpdateResult);
        var verb = new Verb("fallow");
        Subject = new( SubjectPersonalPronouns.She);   
        Object = new(ObjectPersonalPronouns.Him);
        Verb = new(verb);
        UpdateResult();
    }

    public void UpdateResult()
    {
        var sbj = Subject?.BaseSubject;
        var obj = Object?.BaseObject;
        var vrb = Verb?.BaseVerb;
        if (vrb != null)
        {
            Result = $"{sbj} {vrb.ToStringFor(sbj)} {obj}";
            OnPropertyChanged(nameof(Result));
        }
    }
}
