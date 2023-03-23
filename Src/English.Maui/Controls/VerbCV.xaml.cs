using English.UI.Models;
using System.Linq;

namespace English.Maui.Controls;

public partial class VerbCV : ContentView, INotifyPropertyChanged
{
    public event EventHandler ModelChanged;

    public VerbCV()
	{
		InitializeComponent();
        BindingContext = this;
        Tenses = new ObservableCollection<VerbModel>();
        Verbs = new ObservableCollection<VerbModel>();
        foreach (var item in Irregulars.List)
            Verbs.Add(new VerbModel(item));
        var verb = new Verb("do", "did", "done");
        foreach (var item in verb.AllTenses)
            Tenses.Add(new VerbModel(item));
        _selectedTense = Tenses.First();
        _selectedVerb = Verbs.First(v=>v.Name == "tell");
        OnPropertyChanged(nameof(Tenses));
        OnPropertyChanged(nameof(SelectedTense));
        OnPropertyChanged(nameof(Verbs));
        OnPropertyChanged(nameof(SelectedVerb));
    }

    public ObservableCollection<VerbModel> Tenses { get; init; }
    public ObservableCollection<VerbModel> Verbs { get; init; }
    public VerbModel SelectedTense
    {
        get => _selectedTense;
        set
        {
            if (_selectedTense != value)
            {
                _selectedTense = value;
                OnPropertyChanged(nameof(SelectedTense));
                UpdateView();
            }
        }
    }
    public VerbModel _selectedTense;
    public VerbModel SelectedVerb
    {
        get => _selectedVerb;
        set
        {
            if (_selectedVerb != value)
            {
                _selectedVerb = value;
                OnPropertyChanged(nameof(SelectedVerb));
                UpdateView();
            }
        }
    }
    public VerbModel _selectedVerb;

    public IVerb GetVerb() => SelectedVerb.BaseVerb.ChangeTense(SelectedTense.BaseVerb.Tense);
    public void UpdateView()
    {
        ModelChanged?.Invoke(this, EventArgs.Empty);
        var tense = _selectedTense.BaseVerb.Tense;
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
    }

    protected VerbModel GetVerbModel(Tense tense) => Tenses.FirstOrDefault(x => tense == x.BaseVerb.Tense) ?? throw new NullReferenceException($"{tense} does not contain Tenses.");
    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }

    public bool IsContinuous
    {
        get => _isContinuous;
        set
        {
            var tense = SelectedTense?.BaseVerb.Tense ?? Tense.PresentSimple;
            _ = value
                ? SelectedTense = GetVerbModel(tense | Tense.Continuous)
                : SelectedTense = GetVerbModel((tense & Tense.Times) | (tense & Tense.Passive) | (tense & Tense.Perfect));
            SetField(ref _isContinuous, value);
        }
    }
    private bool _isContinuous;
    public bool IsPerfect
    {
        get => _isPerfect;
        set
        {
            var tense = SelectedTense.BaseVerb.Tense;
            _ = value
                ? SelectedTense = GetVerbModel(tense | Tense.Perfect)
                : SelectedTense = GetVerbModel((tense & Tense.Times) | (tense & Tense.Passive) | (tense & Tense.Continuous));
            SetField(ref _isPerfect, value);
        }
    }
    private bool _isPerfect;

    public bool IsPassive
    {
        get => _isPassive;
        set
        {
            var tense = SelectedTense.BaseVerb.Tense;
            _ = value
                ? SelectedTense = GetVerbModel(tense | Tense.Passive)
                : SelectedTense = GetVerbModel((tense & Tense.Times) | (tense & Tense.Perfect) | (tense & Tense.Continuous));
            SetField(ref _isPassive, value);
        }
    }
    private bool _isPassive;

    public bool IsPresent
    {
        get => _isPresent;
        set
        {
            var tense = SelectedTense.BaseVerb.Tense;
            if (value)
                SelectedTense = GetVerbModel((tense & Tense.Forms) | Tense.Present);
            SetField(ref _isPresent, value);
        }
    }
    private bool _isPresent;
    public bool IsPast
    {
        get => _isPast;
        set
        {
            var tense = SelectedTense.BaseVerb.Tense;
            if (value)
                SelectedTense = GetVerbModel((tense & Tense.Forms) | Tense.Past);
            SetField(ref _isPast, value);
        }
    }
    private bool _isPast;
    public bool IsFuture
    {
        get => _isFuture;
        set
        {
            var tense = SelectedTense.BaseVerb.Tense;
            if (value)
                SelectedTense = GetVerbModel((tense & Tense.Forms) | Tense.Future);
            SetField(ref _isFuture, value);
        }
    }
    private bool _isFuture;
    public bool IsConditional
    {
        get => _isConditional;
        set
        {
            var tense = SelectedTense.BaseVerb.Tense;
            if (value)
                SelectedTense = GetVerbModel((tense & Tense.Forms) | Tense.Conditional);
            SetField(ref _isConditional, value);
        }
    }
    private bool _isConditional;

}