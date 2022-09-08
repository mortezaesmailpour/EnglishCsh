using English.Persons;

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

    TenseModel GetTenseModel(Tense tense) => tense switch
    {
        Tense.PresentSimple => Tenses[0],
        Tense.PresentContinuous => Tenses[1],
        Tense.PresentPerfect => Tenses[2],
        Tense.PresentPerfectContinuous => Tenses[3],
        Tense.PastSimple => Tenses[4],
        Tense.PastContinuous => Tenses[5],
        Tense.PastPerfect => Tenses[6],
        Tense.PastPerfectContinuous => Tenses[7],
        Tense.FutureSimple => Tenses[8],
        Tense.FutureContinuous => Tenses[9],
        Tense.FuturePerfect => Tenses[10],
        Tense.FuturePerfectContinuous => Tenses[11],
        Tense.ConditionalSimple => Tenses[12],
        Tense.ConditionalContinuous => Tenses[13],
        Tense.ConditionalPerfect => Tenses[14],
        Tense.ConditionalPerfectContinuous => Tenses[15],
        Tense.PassivePresentSimple => Tenses[16],
        Tense.PassivePresentContinuous => Tenses[17],
        Tense.PassivePresentPerfect => Tenses[18],
        Tense.PassivePresentPerfectContinuous => Tenses[19],
        _ => Tenses[0],
    };

    //================
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
            OnPropertyChanged(nameof(IsContinuous));
            OnPropertyChanged(nameof(IsPerfect));
            OnPropertyChanged(nameof(IsPassive));
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
