using English.Persons;
using English.Verbs;

namespace English.UI.ViewModels;

public class VerbViewModel : BaseViewModel
{
    public bool IsContinuous
    {
        get => _isContinuous;
        set
        {
            var tense = SelectedVerb?.BaseVerb.Tense ?? Tense.PresentSimple;
            _ = value
                ? SelectedVerb = GetVerbModel(tense | Tense.Continuous)
                : SelectedVerb = GetVerbModel((tense & Tense.Times) | (tense & Tense.Passive) | (tense & Tense.Perfect));
            SetField(ref _isContinuous, value);
        }
    }
    private bool _isContinuous;
    public bool IsPerfect
    {
        get => _isPerfect;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            _ = value
                ? SelectedVerb = GetVerbModel(tense | Tense.Perfect)
                : SelectedVerb = GetVerbModel((tense & Tense.Times) | (tense & Tense.Passive) | (tense & Tense.Continuous));
            SetField(ref _isPerfect, value);
        }
    }
    private bool _isPerfect;

    public bool IsPassive
    {
        get => _isPassive;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            _ = value
                ? SelectedVerb = GetVerbModel(tense | Tense.Passive)
                : SelectedVerb = GetVerbModel((tense & Tense.Times) | (tense & Tense.Perfect) | (tense & Tense.Continuous));
            SetField(ref _isPassive, value);
        }
    }
    private bool _isPassive;

    public bool IsPresent
    {
        get => _isPresent;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            if (value)
                SelectedVerb = GetVerbModel((tense & Tense.Forms) | Tense.Present);
            SetField(ref _isPresent, value);
        }
    }
    private bool _isPresent;
    public bool IsPast
    {
        get => _isPast;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            if (value)
                SelectedVerb = GetVerbModel((tense & Tense.Forms) | Tense.Past);
            SetField(ref _isPast, value);
        }
    }
    private bool _isPast;
    public bool IsFuture
    {
        get => _isFuture;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            if (value)
                SelectedVerb = GetVerbModel((tense & Tense.Forms) | Tense.Future);
            SetField(ref _isFuture, value);
        }
    }
    private bool _isFuture;
    public bool IsConditional
    {
        get => _isConditional;
        set
        {
            var tense = SelectedVerb.BaseVerb.Tense;
            if (value)
                SelectedVerb = GetVerbModel((tense & Tense.Forms) | Tense.Conditional);
            SetField(ref _isConditional, value);
        }
    }
    private bool _isConditional;

    VerbModel GetVerbModel(Tense tense) => Tenses.FirstOrDefault(x => tense == x.BaseVerb.Tense) ?? throw new NullReferenceException($"{tense} does not contain Tenses.");

    public ObservableCollection<VerbModel> Tenses { get; init; }
    private VerbModel _SelectedVerb;
    public VerbModel SelectedVerb
    {
        get => _SelectedVerb;
        set
        {
            var tense = value.BaseVerb.Tense;
            _isContinuous = tense.Is(Tense.Continuous);
            _isPerfect = tense.Is(Tense.Perfect);
            _isPassive = tense.Is(Tense.Passive);
            _isPresent = tense.Is(Tense.Present);
            _isPast = tense.Is(Tense.Past);
            _isFuture = tense.Is(Tense.Future);
            _isConditional = tense.Is(Tense.Conditional);
            OnPropertyChanged(nameof(IsContinuous));
            OnPropertyChanged(nameof(IsPerfect));
            OnPropertyChanged(nameof(IsPassive));
            OnPropertyChanged(nameof(IsPresent));
            OnPropertyChanged(nameof(IsPast));
            OnPropertyChanged(nameof(IsFuture));
            OnPropertyChanged(nameof(IsConditional));
            SetField(ref _SelectedVerb, value);
        }
    }
    public ICommand UpdateCommand { get; }
    public VerbViewModel()
    {
        Tenses = new ObservableCollection<VerbModel>();
        Verb verb = new Verb("fallow");
        foreach (var item in verb.AllTenses)
            Tenses.Add(new VerbModel(item));
        SelectedVerb = Tenses.FirstOrDefault();
        OnPropertyChanged(nameof(Tenses));
        OnPropertyChanged(nameof(SelectedVerb));


        UpdateCommand = new CommandHandler(Update);
        Update();
    }
    public string Name
    {
        get => _name;
        set => SetField(ref _name, value);
    }
    private string _name;
    public void Update()
    {
        Name = SelectedVerb.BaseVerb.ToString();
    }
}
