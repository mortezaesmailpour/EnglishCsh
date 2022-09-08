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
            var tense = SelectedTense?.Verb.Tense ?? Tense.PresentSimple;
            _ = value
                ? SelectedTense = GetTenseModel(tense | Tense.Continuous)
                : SelectedTense = GetTenseModel((tense & Tense.Times) | (tense & Tense.Passive) | (tense & Tense.Perfect));
            SetField(ref _isContinuous, value);
        }
    }
    private bool _isContinuous;
    public bool IsPerfect
    {
        get => _isPerfect;
        set
        {
            var tense = SelectedTense.Verb.Tense;
            _ = value
                ? SelectedTense = GetTenseModel(tense | Tense.Perfect)
                : SelectedTense = GetTenseModel((tense & Tense.Times) | (tense & Tense.Passive) | (tense & Tense.Continuous));
            SetField(ref _isPerfect, value);
        }
    }
    private bool _isPerfect;

    public bool IsPassive
    {
        get => _isPassive;
        set
        {
            var tense = SelectedTense.Verb.Tense;
            _ = value
                ? SelectedTense = GetTenseModel(tense | Tense.Passive)
                : SelectedTense = GetTenseModel((tense & Tense.Times) | (tense & Tense.Perfect) | (tense & Tense.Continuous));
            SetField(ref _isPassive, value);
        }
    }
    private bool _isPassive;


    public bool IsPresent
    {
        get => _isPresent;
        set
        {
            var tense = SelectedTense.Verb.Tense;
            if (value)
                SelectedTense = GetTenseModel((tense & Tense.Forms) | Tense.Present);
            SetField(ref _isPresent, value);
        }
    }
    private bool _isPresent;
    public bool IsPast
    {
        get => _isPast;
        set
        {
            var tense = SelectedTense.Verb.Tense;
            if (value)
                SelectedTense = GetTenseModel((tense & Tense.Forms) | Tense.Past);
            SetField(ref _isPast, value);
        }
    }
    private bool _isPast;
    public bool IsFuture
    {
        get => _isFuture;
        set
        {
            var tense = SelectedTense.Verb.Tense;
            if (value)
                SelectedTense = GetTenseModel((tense & Tense.Forms) | Tense.Future);
            SetField(ref _isFuture, value);
        }
    }
    private bool _isFuture;
    public bool IsConditional
    {
        get => _isConditional;
        set
        {
            var tense = SelectedTense.Verb.Tense;
            if (value)
                SelectedTense = GetTenseModel((tense & Tense.Forms) | Tense.Conditional);
            SetField(ref _isConditional, value);
        }
    }
    private bool _isConditional;

    TenseModel GetTenseModel(Tense tense) => Tenses.FirstOrDefault(x => tense == x.Verb.Tense) ?? throw new NullReferenceException($"{tense} does not contain Tenses.");

    public ObservableCollection<TenseModel> Tenses { get; init; }
    private TenseModel _selectedTense;
    public TenseModel SelectedTense
    {
        get => _selectedTense;
        set
        {
            var tense = value.Verb.Tense;
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
            SetField(ref _selectedTense, value);
        }
    }
    public ICommand UpdateCommand { get; }
    public VerbViewModel()
    {
        Tenses = new ObservableCollection<TenseModel>();
        Verb verb = new Verb("fallow");
        foreach (var item in verb.AllTenses)
            Tenses.Add(new TenseModel(item));
        SelectedTense = Tenses.FirstOrDefault();
        OnPropertyChanged(nameof(Tenses));
        OnPropertyChanged(nameof(SelectedTense));


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
        Name = SelectedTense.Verb.ToString();
    }
}
